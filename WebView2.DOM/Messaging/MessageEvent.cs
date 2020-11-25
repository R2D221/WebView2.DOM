using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	[Obsolete("not tested")]
	public class MessageEvent : Event
	{
		protected internal MessageEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public dynamic data => Get<any>();
		public string origin => Get<string>();
		public string lastEventId => Get<string>();
		public EventTarget? source => Get<EventTarget?>(); //MessageEventSource
		public IReadOnlyList<MessagePort> ports => Get<ImmutableArray<MessagePort>>();
		public UserActivation? userActivation => Get<UserActivation?>();
	}
}