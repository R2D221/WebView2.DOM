using Microsoft.Web.WebView2.Core;
using System;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public class EventTarget : JsObject
	{
		protected internal EventTarget(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		internal void AddEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
			var events = References.events.GetOrAdd(referenceId, _ => new());
			events.AddOrUpdate(@event,
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
			events.TryGetValue(@event, out var value);
			if (value != null)
			{
				value.DynamicInvoke(this, args);
			}
		}

		internal void RemoveEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
			var events = References.events.GetOrAdd(referenceId, _ => new());
			events.AddOrUpdate(@event,
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