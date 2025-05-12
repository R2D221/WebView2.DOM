using System;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public partial class EventTarget
	{
		internal void AddEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
			=>
			executionContext.AddEvent(this, @event, value);

		internal void RemoveEvent<T>(EventHandler<T>? value, [CallerMemberName] string @event = "")
			where T : Event
			=>
			executionContext.RemoveEvent(this, @event, value);
	}
}
