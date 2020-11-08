using System;

namespace WebView2.DOM
{
	public partial class HTMLElement : DocumentAndElementEventHandlers
	{
		public event EventHandler<ClipboardEvent>? oncopy { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<ClipboardEvent>? oncut { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<ClipboardEvent>? onpaste { add => AddEvent(value); remove => RemoveEvent(value); }
	}
}
