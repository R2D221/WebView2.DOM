using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Tact.Reflection;

// https://github.com/tdupont750/tact.net/

namespace Tact
{
	public static class TypeExtensions
	{
		internal static readonly ConcurrentDictionary<MethodBase, IReadOnlyList<Type>> ParameterMap =
			new ConcurrentDictionary<MethodBase, IReadOnlyList<Type>>();

		public static EfficientInvoker GetMethodInvoker(this Type type, string methodName)
		{
			return EfficientInvoker.ForMethod(type, methodName);
		}

		public static EfficientInvoker GetPropertyInvoker(this Type type, string propertyName)
		{
			return EfficientInvoker.ForProperty(type, propertyName);
		}
	}

	public static class MethodBaseExtensions
	{
		public static IReadOnlyList<Type> GetParameterTypes(this MethodBase method)
		{
			return TypeExtensions.ParameterMap.GetOrAdd(method, c => c.GetParameters().Select(p => p.ParameterType).ToArray());
		}
	}

	public static class TaskExtensions
	{
		private const string CompleteTaskMessage = "Task must be complete";

		private const string ResultPropertyName = "Result";

		private static readonly Type GenericTaskType = typeof(Task<>);

		private static readonly ConcurrentDictionary<Type, bool> GenericTaskTypeMap = new ConcurrentDictionary<Type, bool>();

		public static Task IgnoreCancellation(this Task task, CancellationToken token)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			// ReSharper disable once MethodSupportsCancellation
			return task
				.ContinueWith(t =>
				{
					if (t.IsCanceled && token.IsCancellationRequested)
						return Task.CompletedTask;

					if (t.IsFaulted
						&& token.IsCancellationRequested
						&& t.Exception is { } exception
						&& exception.InnerExceptions.All(e => e is TaskCanceledException))
						return Task.CompletedTask;

					return t;
				})
				.Unwrap();
		}

		public static Task IgnoreCancellation(this Task task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			return task
				.ContinueWith(t =>
				{
					if (t.IsCanceled)
						return Task.CompletedTask;

					if (t.IsFaulted
						&& t.Exception is { } exception
						&& exception.InnerExceptions.All(e => e is TaskCanceledException))
						return Task.CompletedTask;

					return t;
				})
				.Unwrap();
		}

		public static Task<T> IgnoreCancellation<T>(this Task<T> task, CancellationToken token)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			// ReSharper disable once MethodSupportsCancellation
			return task
				.ContinueWith(t =>
				{
					if (t.IsCanceled && token.IsCancellationRequested)
						return GenericTask<T>.CompletedTask;

					if (t.IsFaulted
						&& token.IsCancellationRequested
						&& t.Exception is { } exception
						&& exception.InnerExceptions.All(e => e is TaskCanceledException))
						return GenericTask<T>.CompletedTask;

					return t;
				})
				.Unwrap();
		}

		public static Task<T> IgnoreCancellation<T>(this Task<T> task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			return task
				.ContinueWith(t =>
				{
					if (t.IsCanceled)
						return GenericTask<T>.CompletedTask;

					if (t.IsFaulted
						&& t.Exception is { } exception
						&& exception.InnerExceptions.All(e => e is TaskCanceledException))
						return GenericTask<T>.CompletedTask;

					return t;
				})
				.Unwrap();
		}

		public static T? GetResult<T>(this Task task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			if (!task.IsCompleted)
				throw new ArgumentException(CompleteTaskMessage, nameof(task));

			var type = task.GetType();
			return type == typeof(Task<T>)
				? (T?)type.GetPropertyInvoker(ResultPropertyName).Invoke(task)
				: default(T);
		}

		public static object? GetResult(this Task task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			if (!task.IsCompleted)
				throw new ArgumentException(CompleteTaskMessage, nameof(task));

			var type = task.GetType();
			var isGenericTaskType = GenericTaskTypeMap.GetOrAdd(type,
				t => t.GetGenericTypeDefinition() == GenericTaskType);

			return isGenericTaskType
				? type.GetPropertyInvoker(ResultPropertyName).Invoke(task)
				: null;
		}

		public static void WaitIfNeccessary(this Task task)
		{
			if (!task.IsCompleted || task.IsFaulted || task.IsCanceled)
				task.Wait();
		}

		private static class GenericTask<T>
		{
#nullable disable
			public static readonly Task<T> CompletedTask = Task.FromResult(default(T));
#nullable enable
		}
	}
}

namespace Tact.Reflection
{
	public sealed class EfficientInvoker
	{
		private static readonly ConcurrentDictionary<ConstructorInfo, Func<object[], object>> ConstructorToWrapperMap
			= new ConcurrentDictionary<ConstructorInfo, Func<object[], object>>();

		private static readonly ConcurrentDictionary<Type, EfficientInvoker> TypeToWrapperMap
			= new ConcurrentDictionary<Type, EfficientInvoker>();

		private static readonly ConcurrentDictionary<MethodKey, EfficientInvoker> MethodToWrapperMap
			= new ConcurrentDictionary<MethodKey, EfficientInvoker>(MethodKeyComparer.Instance);

		private readonly Func<object?, object?[], object?> _func;

		private EfficientInvoker(Func<object?, object?[], object?> func)
		{
			_func = func;
		}

		public static Func<object[], object> ForConstructor(ConstructorInfo constructor)
		{
			if (constructor == null)
				throw new ArgumentNullException(nameof(constructor));

			return ConstructorToWrapperMap.GetOrAdd(constructor, t =>
			{
				CreateParamsExpressions(constructor, out ParameterExpression argsExp, out Expression[] paramsExps);

				var newExp = Expression.New(constructor, paramsExps);
				var resultExp = Expression.Convert(newExp, typeof(object));
				var lambdaExp = Expression.Lambda(resultExp, argsExp);
				var lambda = lambdaExp.Compile();
				return (Func<object[], object>)lambda;
			});
		}

		public static EfficientInvoker ForDelegate(Delegate del)
		{
			if (del == null)
				throw new ArgumentNullException(nameof(del));

			var type = del.GetType();
			return TypeToWrapperMap.GetOrAdd(type, t =>
			{
				var method = del.GetMethodInfo();
				if (method is null) { throw new NullReferenceException(); }
				var wrapper = CreateMethodWrapper(t, method, true);
				return new EfficientInvoker(wrapper);
			});
		}

		public static EfficientInvoker ForMethod(Type type, string methodName)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (methodName == null)
				throw new ArgumentNullException(nameof(methodName));

			var key = new MethodKey(type, methodName);
			return MethodToWrapperMap.GetOrAdd(key, k =>
			{
				var method = k.Type.GetTypeInfo().GetMethod(k.Name);
				if (method is null) { throw new NullReferenceException(); }
				var wrapper = CreateMethodWrapper(k.Type, method, false);
				return new EfficientInvoker(wrapper);
			});
		}

		public static EfficientInvoker ForProperty(Type type, string propertyName)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (propertyName == null)
				throw new ArgumentNullException(nameof(propertyName));

			var key = new MethodKey(type, propertyName);
			return MethodToWrapperMap.GetOrAdd(key, k =>
			{
				var wrapper = CreatePropertyWrapper(type, propertyName);
				return new EfficientInvoker(wrapper);
			});
		}

		public object? Invoke(object? target, params object?[] args)
		{
			return _func(target, args);
		}

		public async Task<object?> InvokeAsync(object target, params object[] args)
		{
			var result = _func(target, args);
			var task = result as Task;
			if (task == null)
				return result;

			if (!task.IsCompleted)
				await task.ConfigureAwait(false);

			return task.GetResult();
		}

		private static Func<object?, object?[], object?> CreateMethodWrapper(Type type, MethodInfo method, bool isDelegate)
		{
			CreateParamsExpressions(method, out ParameterExpression argsExp, out Expression[] paramsExps);

			var targetExp = Expression.Parameter(typeof(object), "target");
			var castTargetExp = Expression.Convert(targetExp, type);
			var invokeExp = isDelegate
				? (Expression)Expression.Invoke(castTargetExp, paramsExps)
				: Expression.Call(castTargetExp, method, paramsExps);

			LambdaExpression lambdaExp;

			if (method.ReturnType != typeof(void))
			{
				var resultExp = Expression.Convert(invokeExp, typeof(object));
				lambdaExp = Expression.Lambda(resultExp, targetExp, argsExp);
			}
			else
			{
				var constExp = Expression.Constant(null, typeof(object));
				var blockExp = Expression.Block(invokeExp, constExp);
				lambdaExp = Expression.Lambda(blockExp, targetExp, argsExp);
			}

			var lambda = lambdaExp.Compile();
			return (Func<object?, object?[], object?>)lambda;
		}

		private static void CreateParamsExpressions(MethodBase method, out ParameterExpression argsExp, out Expression[] paramsExps)
		{
			var parameters = method.GetParameterTypes();

			argsExp = Expression.Parameter(typeof(object[]), "args");
			paramsExps = new Expression[parameters.Count];

			for (var i = 0; i < parameters.Count; i++)
			{
				var constExp = Expression.Constant(i, typeof(int));
				var argExp = Expression.ArrayIndex(argsExp, constExp);
				paramsExps[i] = Expression.Convert(argExp, parameters[i]);
			}
		}

		private static Func<object?, object?[], object?> CreatePropertyWrapper(Type type, string propertyName)
		{
			var property = type.GetRuntimeProperty(propertyName);
			if (property is null) { throw new NullReferenceException(); }
			var targetExp = Expression.Parameter(typeof(object), "target");
			var argsExp = Expression.Parameter(typeof(object[]), "args");
			var castArgExp = Expression.Convert(targetExp, type);
			var propExp = Expression.Property(castArgExp, property);
			var castPropExp = Expression.Convert(propExp, typeof(object));
			var lambdaExp = Expression.Lambda(castPropExp, targetExp, argsExp);
			var lambda = lambdaExp.Compile();
			return (Func<object?, object?[], object?>)lambda;
		}

		private class MethodKeyComparer : IEqualityComparer<MethodKey>
		{
			public static readonly MethodKeyComparer Instance = new MethodKeyComparer();

			public bool Equals(MethodKey x, MethodKey y)
			{
				return x.Type == y.Type &&
					   StringComparer.Ordinal.Equals(x.Name, y.Name);
			}

			public int GetHashCode(MethodKey key)
			{
				var typeCode = key.Type.GetHashCode();
				var methodCode = key.Name.GetHashCode();
				return CombineHashCodes(typeCode, methodCode);
			}

			// From System.Web.Util.HashCodeCombiner
			private static int CombineHashCodes(int h1, int h2)
			{
				return ((h1 << 5) + h1) ^ h2;
			}
		}

		private struct MethodKey
		{
			public MethodKey(Type type, string name)
			{
				Type = type;
				Name = name;
			}

			public readonly Type Type;
			public readonly string Name;
		}
	}
}