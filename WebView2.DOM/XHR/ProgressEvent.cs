using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/progress_event.idl

	public class ProgressEvent : Event
	{
		protected internal ProgressEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool lengthComputable => Get<bool>();
		public ulong loaded => Get<ulong>();
		public ulong total => Get<ulong>();
	}
}