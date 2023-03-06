using System;

namespace WebView2.DOM
{
	public partial class Window : WindowEventHandlers
	{
		public event EventHandler<Event/*	*/> onafterprint/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onbeforeprint/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<HashChangeEvent/*	*/> onhashchange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onlanguagechange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<MessageEvent/*	*/> onmessage/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<MessageEvent/*	*/> onmessageerror/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onoffline/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> ononline/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PageTransitionEvent/*	*/> onpagehide/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PageTransitionEvent/*	*/> onpageshow/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PopStateEvent/*	*/> onpopstate/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PromiseRejectionEvent/*	*/> onrejectionhandled/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<StorageEvent/*	*/> onstorage/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PromiseRejectionEvent/*	*/> onunhandledrejection/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onunload/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
	}
}
