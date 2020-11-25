using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/history.idl

	public enum ScrollRestoration { auto, manual }

	public class History : JsObject
	{
		protected internal History(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public uint length => Get<uint>();
		public ScrollRestoration scrollRestoration { get => Get<ScrollRestoration>(); set => Set(value); }
		public dynamic state => Get<any>();
		public void go(int delta) => Method().Invoke(delta);
		public void back() => Method().Invoke();
		public void forward() => Method().Invoke();
		public void pushState(object? data, string title, string? url = null) => Method().Invoke(data, title, url);
		public void replaceState(object? data, string title, string? url = null) => Method().Invoke(data, title, url);
	}
}