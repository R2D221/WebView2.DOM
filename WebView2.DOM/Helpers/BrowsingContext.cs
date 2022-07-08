using Microsoft.Web.WebView2.Core;
using OneOf;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Windows.Documents;
using System.Windows.Threading;
using WebView2.DOM.Helpers;
using static WebView2.DOM.BrowsingContext;

namespace WebView2.DOM
{
	public static class Flow
	{
		public static object? CSharpStart { get; }
		public static object? JavaScriptStart { get; }
		public static object? CSharpEnd { get; }
		public static object? JavaScriptEnd { get; }
	}



	public sealed record @null()
	{
		public static readonly @null Value = new();
	}

	public sealed class DuplexChannel : IDisposable
	{
		public static readonly ThreadLocal<DuplexChannel?> ThreadLocal = new();

		// TODO: I'm trying to get rid of this dict, since
		// only one run can be active at any given time,
		// but so far I've only been able to ensure consistency
		// if I add a run ID and a corresponding dict that
		// takes the run IDs as keys.

		private static long currentRunId;
		//private static ConcurrentDictionary<long, DuplexChannel> duplexChannels = new();





		private static Channel<T> CreateChannel<T>() => Channel.CreateBounded<T>(options: new(capacity: 1) { SingleReader = true, SingleWriter = true, AllowSynchronousContinuations = true });




		private readonly DispatcherFrame? dispatcherFrame;
		internal readonly CancellationTokenSource cts = new();
		private Channel<Request> requests = CreateChannel<Request>();
		private Channel<OneOf<string, Exception, @null>> responses = CreateChannel<OneOf<string, Exception, @null>>();

		public long RunId { get; }



		public DuplexChannel(SynchronizationContext uiSyncContext)
		{
			RunId = Interlocked.Increment(ref currentRunId);

			dispatcherFrame =
				uiSyncContext is DispatcherSynchronizationContext
				? new DispatcherFrame()
				: null
				;

			//if (duplexChannels.TryAdd(RunId, this) == false)
			//{
			//	throw new InvalidOperationException("Threads are in an inconsistent state.");
			//}
		}




		//public static DuplexChannel FromRunId(long runId) => duplexChannels[runId];








		internal void SetDispatcherFrameContinueFalse()
		{
			if (dispatcherFrame is null)
			{
				Debugger.Break();
				return;
			}

			//dispatcherFrameCount--;

			//if (Math.Abs(dispatcherFrameCount) > 1)
			//{
			//	Debugger.Break();
			//}

			dispatcherFrame.Continue = false;
		}

		internal void DispatcherPushFrame()
		{
			if (dispatcherFrame is null) { return; }

			//dispatcherFrameCount++;

			//if (Math.Abs(dispatcherFrameCount) > 1)
			//{
			//	Debugger.Break();
			//}

			Dispatcher.PushFrame(dispatcherFrame);
			dispatcherFrame.Continue = true;
		}











		//private bool csharpAlreadyRequested = false;
		public DuplexChannel_CSharp GetCSharpChannel()
		{
			//if (csharpAlreadyRequested) { throw new InvalidOperationException("Inconsistent thread"); }
			//csharpAlreadyRequested = true;

			return new(requests.Writer, responses.Reader);
		}

		//private bool javascriptAlreadyRequested = false;
		public DuplexChannel_JavaScript GetJavaScriptChannel()
		{
			//if (javascriptAlreadyRequested) { throw new InvalidOperationException("Inconsistent thread"); }
			//javascriptAlreadyRequested = true;

			return new(requests.Reader, responses.Writer);
		}

		public void Dispose()
		{
			_ = requests.Writer.TryComplete();
			_ = responses.Writer.TryComplete();
		}
	}

	public sealed class DuplexChannel_CSharp : IDisposable
	{
		public ChannelWriter<Request> Requests { get; }
		public ChannelReader<OneOf<string, Exception, @null>> Responses { get; }

		public DuplexChannel_CSharp(ChannelWriter<Request> requests, ChannelReader<OneOf<string, Exception, @null>> responses)
		{
			this.Requests = requests;
			this.Responses = responses;
		}

		public void Dispose()
		{
			_ = Requests.TryComplete();
		}
	}

	public sealed class DuplexChannel_JavaScript : IDisposable
	{
		public ChannelReader<Request> Requests { get; }
		public ChannelWriter<OneOf<string, Exception, @null>> Responses { get; }

		public DuplexChannel_JavaScript(ChannelReader<Request> requests, ChannelWriter<OneOf<string, Exception, @null>> responses)
		{
			this.Requests = requests;
			this.Responses = responses;
		}

		public void Dispose()
		{
			_ = Responses.TryComplete();
		}
	}

	public sealed partial class BrowsingContext : IDisposable
	{
		#region static
		private static ConditionalWeakTable<CoreWebView2, BrowsingContext> instances = new();

		public static void Set(CoreWebView2 webView, BrowsingContext coordinator)
		{
			_ = instances.Remove(webView);
			instances.Add(webView, coordinator);
		}

		public static BrowsingContext? For(CoreWebView2 webView) => instances.TryGetValue(webView, out var coordinator) ? coordinator : null;

		private static ThreadLocal<BrowsingContext?> threadLocalBrowsingContext = new(() => null);
		#endregion

		internal readonly CoreWebView2 coreWebView;
		internal readonly SynchronizationContext uiSyncContext;
		internal readonly InnerSyncContext innerSyncContext;
		//internal readonly DispatcherFrame? dispatcherFrame;
		//internal int dispatcherFrameCount = 1;
		//internal readonly CancellationTokenSource cts = new();

		internal readonly Channel<(SendOrPostCallback d, object? state)> callbacksChannel =
			Channel.CreateBounded<(SendOrPostCallback d, object? state)>(options: new(capacity: 1) { SingleReader = true, SingleWriter = true, AllowSynchronousContinuations = true });



		internal DuplexChannel NewDuplexChannel()
		{
			return new DuplexChannel(uiSyncContext);
		}

		//private ConcurrentDictionary<string, (Channel<Request> requests, Channel<OneOf<string, Exception, @null>> responses)?>
		//	channels = new();

		//private (ChannelWriter<Request> request, ChannelReader<OneOf<string, Exception, @null>> response) GetCsharpChannels(string runId)
		//{
		//	var result = channels.GetOrAdd(runId, _ => (CreateChannel<Request>(), CreateChannel<OneOf<string, Exception, @null>>()));

		//	switch (result)
		//	{
		//	case { } resultNotNull:
		//	{
		//		return (resultNotNull.requests.Writer, resultNotNull.responses.Reader);
		//	}
		//	default: throw new InvalidOperationException("Threads are in an inconsistent state.");
		//	}
		//}

		//private (ChannelReader<Request> request, ChannelWriter<OneOf<string, Exception, @null>> response) GetJavaScriptChannels(string runId)
		//{
		//	var result = channels.GetOrAdd(runId, _ => (CreateChannel<Request>(), CreateChannel<OneOf<string, Exception, @null>>()));

		//	switch (result)
		//	{
		//	case { } resultNotNull:
		//	{
		//		return (resultNotNull.requests.Reader, resultNotNull.responses.Writer);
		//	}
		//	default: throw new InvalidOperationException("Threads are in an inconsistent state.");
		//	}
		//}

		public ulong NavigationId { get; }
		public Window Window { get; } = new Window();

		public BrowsingContext(CoreWebView2 coreWebView, ulong navigationId)
		{
			this.coreWebView = coreWebView;

			this.NavigationId = navigationId;

			uiSyncContext = SynchronizationContext.Current ?? throw new InvalidOperationException();
			innerSyncContext = new InnerSyncContext(this);

			var id = Guid.NewGuid().ToString();
			References2.SetId(Window, id);
		}

		internal sealed class InnerSyncContext : SynchronizationContext
		{
			private readonly BrowsingContext browsingContext;

			private readonly BlockingCollection<(Action<object?>, object?)>
				actions = new();

			private readonly Thread thread;

			public InnerSyncContext(BrowsingContext browsingContext)
			{
				this.browsingContext = browsingContext;

				this.thread = new Thread(loop) { Name = "WebView2.DOM", IsBackground = true };
				this.thread.Start();
			}

			private void loop()
			{
				SynchronizationContext.SetSynchronizationContext(this);
				threadLocalBrowsingContext.Value = browsingContext;

				foreach (var item in actions.GetConsumingEnumerable())
				{
					try
					{
						var (action, state) = item;

						action(state);
					}
					catch (Exception ex)
					{
						//browsingContext.uiSyncContext.Post(ex =>
						//{
						//	ExceptionDispatchInfo
						//		.Capture((Exception)ex!)
						//		.Throw();
						//}, ex);
					}
				}
			}

			public override void Post(SendOrPostCallback d, object? state)
			{
				object? param = Pool.Box((browsingContext, d, state));

				actions.Add((action2, param));

				static void action2(object? param)
				{
					_ = Flow.CSharpStart;

					var (browsingContext, d, state) = Pool.UnboxAndReturn<(BrowsingContext, SendOrPostCallback, object?)>(param);

					var success = browsingContext.callbacksChannel.Writer.TryWrite((d, state));

					if (!success) { throw new Exception(); }

					browsingContext.uiSyncContext.Post(
						state: browsingContext,
						d: static obj =>
						{
							if (obj is not BrowsingContext browsingContext) { throw new Exception(); }

							_ = browsingContext.coreWebView.ExecuteScriptAsync($@"
								(() => {{
									Coordinator.{nameof(BrowsingContext._HostObject.Run)}();
									WebView2DOM.EventLoop();
								}})()
							");
						});
				}
			}

			internal DuplexChannel RunJsCallback(SendOrPostCallback d, object? state)
			{
				var channel = browsingContext.NewDuplexChannel();

				object? param = Pool.Box((browsingContext, d, state, channel));

				actions.Add((action, param));

				static void action(object? param)
				{
					_ = Flow.CSharpStart;

					var (browsingContext, d, state, channel) = Pool.UnboxAndReturn<(BrowsingContext, SendOrPostCallback, object?, DuplexChannel)>(param);

					DuplexChannel.ThreadLocal.Value = channel;

					try
					{
						d(state);
					}
					catch
					{
						throw;
					}
					finally
					{
						_ = channel.GetCSharpChannel().Requests.TryComplete();
						channel.SetDispatcherFrameContinueFalse();

						channel.Dispose();
						DuplexChannel.ThreadLocal.Value = null;
					}
				}

				return channel;
			}

			public void Dispose()
			{
				actions.CompleteAdding();
			}
		}

		public void Dispose()
		{
			//_ = nameof(Coordinator2222.CancelRunningThreads);
			throw new NotImplementedException();
			_ = "";

			innerSyncContext.Dispose();

			//cts.Cancel();
			//duplexChannel?.Dispose();
			//duplexChannel = null;
		}
	}

}