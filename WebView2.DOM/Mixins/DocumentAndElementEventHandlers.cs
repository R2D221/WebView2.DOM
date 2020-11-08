using System;
using System.Collections.Generic;
using System.Text;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/document_and_element_event_handlers.idl

	public interface DocumentAndElementEventHandlers
	{
		event EventHandler<ClipboardEvent/*	*/>? oncopy/*	*/;
		event EventHandler<ClipboardEvent/*	*/>? oncut/*	*/;
		event EventHandler<ClipboardEvent/*	*/>? onpaste/*	*/;
	}
}
