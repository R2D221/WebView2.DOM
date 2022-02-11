using Microsoft.Web.WebView2.Core;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace WebView2.DOM
{
	public class EventTarget : JsObject
	{
		protected internal EventTarget(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
			var events = References.events.GetOrAdd(referenceId, _ => new());
			_ = events.AddOrUpdate(@event,
				addValueFactory: _ =>
				{
					coreWebView.Coordinator().Call(new()
					{
						referenceId = referenceId,
						memberType = "addevent",
						memberName = @event,
					});
					return value;
				},
				updateValueFactory: (_, prev) =>
				{
					return ((EventHandler<T>?)prev) + value;
				});
		}

		internal void RaiseEvent(string @event, Event args)
		{
			var events = References.events.GetOrAdd(referenceId, _ => new());
			_ = events.TryGetValue(@event, out var value);
			if (value != null)
			{
				try
				{
					_ = value.DynamicInvoke(this, args);
				}
				catch (TargetInvocationException ex)
				{
					ExceptionDispatchInfo
						.Capture(ex.InnerException!)
						.Throw();

					throw;
				}
			}
		}

		internal void RemoveEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
			var events = References.events.GetOrAdd(referenceId, _ => new());
			_ = events.AddOrUpdate(@event,
				addValueFactory: _ =>
				{
					return default(EventHandler<T>?);
				},
				updateValueFactory: (_, prev) =>
				{
					var @new = ((EventHandler<T>?)prev) - value;
					if (@new == null)
					{
						coreWebView.Coordinator().Call(new()
						{
							referenceId = referenceId,
							memberType = "removeevent",
							memberName = @event,
						});
					}
					return @new;
				});
		}
	}
}