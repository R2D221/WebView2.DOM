using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window_event_handlers.idl

	public interface WindowEventHandlers
	{
		event EventHandler<Event/*	*/> onafterprint/*	*/;
		event EventHandler<Event/*	*/> onbeforeprint/*	*/;
		//event OnBeforeUnloadEventHandler onbeforeunload;
		event EventHandler<HashChangeEvent/*	*/> onhashchange/*	*/;
		event EventHandler<Event/*	*/> onlanguagechange/*	*/;
		event EventHandler<MessageEvent/*	*/> onmessage/*	*/;
		event EventHandler<MessageEvent/*	*/> onmessageerror/*	*/;
		event EventHandler<Event/*	*/> onoffline/*	*/;
		event EventHandler<Event/*	*/> ononline/*	*/;
		event EventHandler<PageTransitionEvent/*	*/> onpagehide/*	*/;
		event EventHandler<PageTransitionEvent/*	*/> onpageshow/*	*/;
		event EventHandler<PopStateEvent/*	*/> onpopstate/*	*/;
		event EventHandler<StorageEvent/*	*/> onstorage/*	*/;
		event EventHandler<PromiseRejectionEvent/*	*/> onrejectionhandled/*	*/;
		event EventHandler<PromiseRejectionEvent/*	*/> onunhandledrejection/*	*/;
		event EventHandler<Event/*	*/> onunload/*	*/;
	}
}