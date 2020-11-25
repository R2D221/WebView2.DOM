using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public class EventTarget : JsObject
	{
		protected internal EventTarget(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		internal ConcurrentDictionary<string, Delegate?> events { get; set; } =
			new ConcurrentDictionary<string, Delegate?>();

		internal void AddEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
			events.AddOrUpdate(@event,
				addValueFactory: _ =>
				{
					coreWebView.Coordinator().AddEvent(referenceId, @event);
					return value;
				},
				updateValueFactory: (_, prev) =>
				{
					return ((EventHandler<T>?)prev) + value;
				});
		}

		internal void RaiseEvent(string @event, Event args)
		{
			events.TryGetValue(@event, out var value);
			if (value != null)
			{
				value.DynamicInvoke(this, args);
			}
		}

		internal void RemoveEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
		{
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
						coreWebView.Coordinator().RemoveEvent(referenceId, @event);
					}
					return @new;
				});
		}
	}
}