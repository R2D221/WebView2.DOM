using System;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public abstract class Promise : JsObject { }

	public class VoidPromise : Promise
	{
		public delegate void Executor(Action<object?> resolve, Action<Exception> reject);

		private protected VoidPromise() { }

		public VoidPromise(Executor executor)
		{
			throw new NotImplementedException();
			//Construct(executor);
		}

		public VoidPromise @then(Action? onFulfilled = null, Action<Exception>? onRejected = null) =>
			Method<VoidPromise>().Invoke(onFulfilled, onRejected);

		public Promise<TNewResult> @then<TNewResult>(Func<TNewResult>? onFulfilled = null, Func<Exception, TNewResult>? onRejected = null) =>
			Method<Promise<TNewResult>>().Invoke(onFulfilled, onRejected);

		//public Promise @catch(Action<Exception> onRejected) =>
		//	Method<Promise>().Invoke(onRejected);

		public VoidPromise @finally(Action onFinally) =>
			Method<VoidPromise>().Invoke(onFinally);

		private bool isPending() =>
			Method<bool>().Invoke();

		private void getResult() =>
			Method().Invoke();

		public Awaiter GetAwaiter() => new(this);

		public struct Awaiter : INotifyCompletion
		{
			private readonly VoidPromise promise;

			public Awaiter(VoidPromise promise)
			{
				this.promise = promise;
			}

			public bool IsCompleted => !promise.isPending();

			public void GetResult() => promise.getResult();

			public void OnCompleted(Action continuation) => promise.@finally(continuation);
		}
	}

	public class Promise<TResult> : Promise
	{
		public delegate void Executor(Action<TResult> resolve, Action<Exception> reject);

		public Promise(Executor executor)
		{
			throw new NotImplementedException();
			//Construct(executor);
		}

		public VoidPromise @then(Action<TResult>? onFulfilled = null, Action<Exception>? onRejected = null) =>
			Method<VoidPromise>().Invoke(onFulfilled, onRejected);

		public Promise<TNewResult> @then<TNewResult>(Func<TResult, TNewResult>? onFulfilled = null, Func<Exception, TNewResult>? onRejected = null) =>
			Method<Promise<TNewResult>>().Invoke(onFulfilled, onRejected);

		//public Promise @catch(Action<Exception> onRejected) =>
		//	Method<Promise>().Invoke(onRejected);

		public Promise<TResult> @finally(Action onFinally) =>
			Method<Promise<TResult>>().Invoke(onFinally);

		private bool isPending() =>
			Method<bool>().Invoke();

		private TResult getResult() =>
			Method<TResult>().Invoke();

		public Awaiter GetAwaiter() => new(this);

		public struct Awaiter : INotifyCompletion
		{
			private readonly Promise<TResult> promise;

			public Awaiter(Promise<TResult> promise)
			{
				this.promise = promise;
			}

			public bool IsCompleted => !promise.isPending();

			public TResult GetResult() => promise.getResult();

			public void OnCompleted(Action continuation) => promise.@finally(continuation);
		}
	}
}
