using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	public sealed class MessageEvent : Event
	{
		private MessageEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public dynamic data => Get<any>();
		public string origin => Get<string>();
		public string lastEventId => Get<string>();
		public EventTarget? source => Get<EventTarget?>(); //MessageEventSource
		public IReadOnlyList<MessagePort> ports => Get<ImmutableArray<MessagePort>>();
		public UserActivation? userActivation => Get<UserActivation?>();
	}
}