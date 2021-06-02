#if !NET5_0_OR_GREATER
using System.Collections.Generic;

namespace System.Threading.Tasks
{
	internal class TaskCompletionSource
	{
		private readonly TaskCompletionSource<object?> tcs;

		public TaskCompletionSource() =>
			tcs = new TaskCompletionSource<object?>();

		public TaskCompletionSource(TaskCreationOptions creationOptions) =>
			tcs = new TaskCompletionSource<object?>(creationOptions);

		public TaskCompletionSource(object? state) =>
			tcs = new TaskCompletionSource<object?>(state);

		public TaskCompletionSource(object? state, TaskCreationOptions creationOptions) =>
			tcs = new TaskCompletionSource<object?>(state, creationOptions);

		public Task Task => tcs.Task;

		public void SetException(Exception exception) =>
			tcs.SetException(exception);

		public void SetException(IEnumerable<Exception> exceptions) =>
			tcs.SetException(exceptions);

		public bool TrySetException(Exception exception) =>
			tcs.TrySetException(exception);

		public bool TrySetException(IEnumerable<Exception> exceptions) =>
			tcs.TrySetException(exceptions);

		public void SetResult() =>
			tcs.SetResult(null);

		public bool TrySetResult() =>
			tcs.TrySetResult(null);

		public void SetCanceled() =>
			tcs.SetCanceled();

		//public void SetCanceled(CancellationToken cancellationToken) =>
		//	tcs.SetCanceled(cancellationToken);

		public void TrySetCanceled() =>
			tcs.TrySetCanceled();

		public void TrySetCanceled(CancellationToken cancellationToken) =>
			tcs.TrySetCanceled(cancellationToken);
	}
}
#endif
