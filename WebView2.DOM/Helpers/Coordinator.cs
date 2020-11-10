﻿using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	struct CoordinatorCall
	{
		//public string windowId { get; set; }
		public string referenceId { get; set; }
		public string memberType { get; set; }
		public string memberName { get; set; }
		public object?[] parameters { get; set; }
	}

	public sealed class Coordinator
	{
		//private BlockingCollection<string> calls;
		//private readonly BlockingCollection<object?> objects = new BlockingCollection<object?>();
		//private IEnumerator<string> enumerator;

		private readonly ConcurrentDictionary<string, BlockingCollection<string>> callsDict =
			new ConcurrentDictionary<string, BlockingCollection<string>>();

		private readonly ConcurrentDictionary<string, BlockingCollection<object?>> objectsDict =
			new ConcurrentDictionary<string, BlockingCollection<object?>>();

		private readonly ConcurrentDictionary<string, IEnumerator<string>> enumeratorDict =
			new ConcurrentDictionary<string, IEnumerator<string>>();

		private readonly CoreWebView2 coreWebView;
		private CancellationTokenSource cts;
		private readonly AsyncLocal<CancellationTokenSource?> asyncLocalCts = new AsyncLocal<CancellationTokenSource?>();

		private CancellationToken CancellationToken =>
			asyncLocalCts.Value?.Token ?? throw new OperationCanceledException();

		private BlockingCollection<string> Calls(string windowId) =>
			callsDict.GetOrAdd(windowId, _ => throw new OperationCanceledException());

		private BlockingCollection<object?> Objects(string windowId) =>
			objectsDict.GetOrAdd(windowId, _ => throw new OperationCanceledException());

		internal Coordinator(CoreWebView2 coreWebView)
		{
			//calls = new BlockingCollection<string>();
			//enumerator = calls.GetConsumingEnumerable().GetEnumerator();
			cts = new CancellationTokenSource();
			this.coreWebView = coreWebView;
		}

		internal void CancelRunningThreads()
		{
			cts.Cancel();
			callsDict.Clear();
			objectsDict.Clear();
			enumeratorDict.Clear();
		}

		#region Called from JavaScript: Entry points
		public event Action? DOMContentLoaded;
		private ConcurrentDictionary<string, Action<Window>> runHandlers =
			new ConcurrentDictionary<string, Action<Window>>();

		public void OnDOMContentLoaded(string windowId)
		{
			Reset(windowId);
			Task.Run(() =>
			{
				try
				{
					asyncLocalCts.Value = cts;
					var w = References.Get<Window>(windowId);
					window.SetInstance(w);
					DOMContentLoaded?.Invoke();
				}
				finally
				{
					window.SetInstance(null);
					Calls(windowId).CompleteAdding();
				}
			});
		}

		public void RaiseEvent(string windowId, string eventTargetId, string eventName, string eventId)
		{
			Reset(windowId);
			Task.Run(() =>
			{
				try
				{
					asyncLocalCts.Value = cts;
					window.SetInstance(References.Get<Window>(windowId));
					var eventTarget = References.Get<EventTarget>(eventTargetId);
					var eventObject = References.Get<Event>(eventId);
					eventTarget.RaiseEvent(eventName, eventObject);
				}
				finally
				{
					window.SetInstance(null);
					Calls(windowId).CompleteAdding();
				}
			});
		}

		public void FulfillPromise(string windowId, string promiseId, string json, bool isComplete)
		{
			json ??= "null";
			var tcs = References.GetTaskCompletionSource(promiseId);
			if (isComplete)
			{
				tcs.SetResult(json);
			}
			else
			{
				Reset(windowId);
				Task.Run(() =>
				{
					try
					{
						asyncLocalCts.Value = cts;
						window.SetInstance(References.Get<Window>(windowId));
						tcs.SetResult(json);
					}
					finally
					{
						window.SetInstance(null);
						Calls(windowId).CompleteAdding();
					}
				});
			}
		}

		public void RejectPromise(string windowId, string promiseId, string json, bool isComplete)
		{
			json ??= "null";
			var tcs = References.GetTaskCompletionSource(promiseId);
			var errorWrapper = JsonSerializer.Deserialize<ErrorWrapper>(json, coreWebView.Options());
			var ex = errorWrapper.GetException();

			if (isComplete)
			{
				tcs.SetException(ex);
			}
			else
			{
				Reset(windowId);
				Task.Run(() =>
				{
					try
					{
						asyncLocalCts.Value = cts;
						window.SetInstance(References.Get<Window>(windowId));
						tcs.SetException(ex);
					}
					finally
					{
						window.SetInstance(null);
						Calls(windowId).CompleteAdding();
					}
				});
			}
		}

		public void OnRun(string windowId, string runId)
		{
			Reset(windowId);
			Task.Run(() =>
			{
				try
				{
					asyncLocalCts.Value = cts;
					var w = References.Get<Window>(windowId);
					window.SetInstance(w);
					if (runHandlers.TryRemove(runId, out var action))
					{
						action(w);
					}
					else
					{
						throw new InvalidOperationException();
					}
				}
				finally
				{
					window.SetInstance(null);
					Calls(windowId).CompleteAdding();
				}
			});
		}

		public void OnCallback(string windowId, string callbackId, string json)
		{
			json ??= "null";
			if (Calls(windowId).IsCompleted)
			{
				Reset(windowId);
				Task.Run(() =>
				{
					try
					{
						asyncLocalCts.Value = cts;
						window.SetInstance(References.Get<Window>(windowId));
						func();
					}
					finally
					{
						window.SetInstance(null);
						Calls(windowId).CompleteAdding();
					}
				});
			}
			else
			{
				func();
			}

			void func()
			{
				var callback = References.GetCallback(callbackId);

				var parameters = JsonSerializer.Deserialize<ImmutableArray<JsonElement>>(json, coreWebView.Options());

				var parametersInfo = callback.Method.GetParameters();

				if (parametersInfo.Length != parameters.Length)
				{
					throw new InvalidOperationException("Error invoking callback: number of parameters doesn't match");
				}

				var final = Enumerable.Zip(parameters, parametersInfo,
					(p, i) => JsonSerializer.Deserialize(p.GetRawText(), i.ParameterType, coreWebView.Options()))
					.ToArray<object?>();

				callback.DynamicInvoke(args: final);
			}
		}
		#endregion

		#region Called from JavaScript: IEnumerator
		public string Current(string windowId) => enumeratorDict.GetOrAdd(windowId, _ => throw new InvalidOperationException()).Current;

		public bool MoveNext(string windowId) => enumeratorDict.GetOrAdd(windowId, _ => throw new InvalidOperationException()).MoveNext();

		public void Reset(string windowId)
		{
			var calls = callsDict.AddOrUpdate(windowId,
				_ => new BlockingCollection<string>(),
				(_, __) => new BlockingCollection<string>());
			//calls = new BlockingCollection<string>();
			enumeratorDict.AddOrUpdate(windowId,
				_ => calls.GetConsumingEnumerable().GetEnumerator(),
				(_, __) => calls.GetConsumingEnumerable().GetEnumerator());
			//enumerator = calls.GetConsumingEnumerable().GetEnumerator();

			objectsDict.GetOrAdd(windowId,
				_ => new BlockingCollection<object?>());

			cts = new CancellationTokenSource();
		}
		#endregion

		#region Called from JavaScript: Return to C#
		public void ReturnVoid(string windowId)
		{
			Objects(windowId).Add(null);
		}

		public void ReturnValue(string windowId, string json)
		{
			Objects(windowId).Add(json ?? "null");
		}

		public void Throw(string windowId, string json)
		{
			var errorWrapper = JsonSerializer.Deserialize<ErrorWrapper>(json ?? "null", coreWebView.Options());
			Objects(windowId).Add(errorWrapper.GetException());
		}
		#endregion

		#region Called from C#
		internal string Get(string referenceId, string property)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "getter",
					memberName = property,
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case string json: return json;
			default: throw new InvalidOperationException();
			}
		}

		internal void Set(string referenceId, string property, object? value)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "setter",
					memberName = property,
					parameters = new[] { value },
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case null: break;
			default: throw new InvalidOperationException();
			}
		}

		internal string IndexerGet(string referenceId, object? index)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "indexerGetter",
					parameters = new[] { index },
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case string json: return json;
			default: throw new InvalidOperationException();
			}
		}

		internal void IndexerSet(string referenceId, object? index, object? value)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "indexerSetter",
					parameters = new[] { index, value },
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case null: break;
			default: throw new InvalidOperationException();
			}
		}

		internal void IndexerDelete(string referenceId, object? index)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "indexerDeleter",
					parameters = new[] { index },
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case null: break;
			default: throw new InvalidOperationException();
			}
		}

		internal string Invoke(string referenceId, string method, object?[] args)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "invoke",
					memberName = method,
					parameters = args,
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case string json: return json;
			case null: return "";
			default: throw new InvalidOperationException();
			}
		}

		internal string InvokeSymbol(string referenceId, string method, object?[] args)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "invokeSymbol",
					memberName = method,
					parameters = args,
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case string json: return json;
			default: throw new InvalidOperationException();
			}
		}

		internal void AddEvent(string referenceId, string @event)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "addevent",
					memberName = @event,
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case null: break;
			default: throw new InvalidOperationException();
			}
		}

		internal void RemoveEvent(string referenceId, string @event)
		{
			Debugger.NotifyOfCrossThreadDependency();
			CancellationToken.ThrowIfCancellationRequested();
			var windowId = window.Instance.referenceId;
			try
			{
				Calls(windowId).Add(JsonSerializer.Serialize(new CoordinatorCall
				{
					//windowId = windowId,
					referenceId = referenceId,
					memberType = "removeevent",
					memberName = @event,
				}, coreWebView.Options()), CancellationToken);
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Collections.Concurrent")
			{
				throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");
			}

			switch (Objects(windowId).Take(CancellationToken))
			{
			case Exception ex: throw ex;
			case null: break;
			default: throw new InvalidOperationException();
			}
		}

		internal string AddRunHandler(Action<Window> action)
		{
			var id = System.Guid.NewGuid().ToString();
			runHandlers.TryAdd(id, action);
			return id;
		}
		#endregion
	}
}