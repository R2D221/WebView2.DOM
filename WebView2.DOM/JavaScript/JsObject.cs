using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public class JsObject
	{
		private protected JsObject() { }

		private protected static JsExecutionContext.CSharpSide executionContext =>
			BrowsingContext.Current.RunningExecutionContext?.CSharp
			??
			throw new InvalidOperationException();

		internal void Construct(params object?[] args)
		{
			executionContext.Construct(this, GetType().Name, args);
		}

		private static class Cache<T>
		{
			public static ConditionalWeakTable<JsObject, ConcurrentDictionary<string, T>> caches = new();
		}

		internal T GetCached<T>([CallerMemberName] string property = "")
		{
			return Cache<T>.caches
				.GetValue(this, _ => new())
				.GetOrAdd(property, _property => Get<T>(_property));
		}

		internal T Get<T>([CallerMemberName] string property = "")
		{
			return executionContext.Get<T>(this, property);
		}

		internal void Set<T>(T value, [CallerMemberName] string property = "")
		{
			executionContext.Set(this, property, value);
		}

		internal T IndexerGet<T>(string index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal T IndexerGet<T>(uint index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal T IndexerGet<T>(int index)
		{
			return executionContext.Get<T>(this, index);
		}

		internal void IndexerSet<T>(string index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerSet<T>(uint index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerSet<T>(int index, T value)
		{
			executionContext.Set(this, index, value);
		}

		internal void IndexerDelete(string index)
		{
			executionContext.Delete(this, index);
		}

		internal void IndexerDelete(uint index)
		{
			executionContext.Delete(this, index);
		}

		internal void IndexerDelete(int index)
		{
			executionContext.Delete(this, index);
		}

		internal Invoker Method([CallerMemberName] string method = "")
			=> new Invoker(this, method);

		internal struct Invoker
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public void Invoke(params object?[] args)
			{
				executionContext.InvokeVoid(@this, method, args);
			}
		}

		internal Invoker<T> Method<T>([CallerMemberName] string method = "")
			=> new Invoker<T>(this, method);

		internal struct Invoker<T>
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public T Invoke(params object?[] args)
			{
				return executionContext.Invoke<T>(@this, method, args);
			}
		}

		internal SymbolInvoker<T> SymbolMethod<T>([CallerMemberName] string method = "")
			=> new SymbolInvoker<T>(this, method);

		internal struct SymbolInvoker<T>
		{
			public SymbolInvoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public T Invoke(params object?[] args)
			{
				return executionContext.SymbolInvoke<T>(@this, method, args);
			}
		}
	}
}
