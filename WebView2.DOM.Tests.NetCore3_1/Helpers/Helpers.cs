using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebView2.DOM.Tests
{
	public static class Helpers
	{
		public static Task<T> RunSTATask<T>(Func<T> function)
		{
			var task = new Task<T>(function, TaskCreationOptions.DenyChildAttach);
			var thread = new Thread(task.RunSynchronously);
			//thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return task;
		}

		public static Task RunSTATask(Action action)
		{
			var task = new Task(action, TaskCreationOptions.DenyChildAttach);
			var thread = new Thread(task.RunSynchronously);
			//thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return task;
		}
	}
}
