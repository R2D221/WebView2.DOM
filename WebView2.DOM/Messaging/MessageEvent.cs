using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	[Obsolete("not tested")]
	public class MessageEvent : Event
	{
		public dynamic data => Get<any>();
		public string origin => Get<string>();
		public string lastEventId => Get<string>();
		public EventTarget? source => Get<EventTarget?>(); //MessageEventSource
		public IReadOnlyList<MessagePort> ports => Get<ImmutableArray<MessagePort>>();
		public UserActivation? userActivation => Get<UserActivation?>();
	}
}