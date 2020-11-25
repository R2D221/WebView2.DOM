using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/static_range.idl

	public class StaticRange : JsObject
	{
		protected internal StaticRange(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Node startContainer => Get<Node>();
		public uint startOffset => Get<uint>();
		public Node endContainer => Get<Node>();
		public uint endOffset => Get<uint>();
		public bool collapsed => Get<bool>();
	}
}
