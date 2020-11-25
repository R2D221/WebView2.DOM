using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/style_sheet.idl

	public class StyleSheet : JsObject
	{
		protected internal StyleSheet(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string type => Get<string>();
		public string? href => Get<string?>();
		public Node? ownerNode => Get<Node?>(); // Element or ProcessingInstruction
		public StyleSheet? parentStyleSheet => Get<StyleSheet?>();
		public string? title => Get<string?>();
		public MediaList media => Get<MediaList>();
		public bool disabled { get => Get<bool>(); set => Set(value); }
	}
}