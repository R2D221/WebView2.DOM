using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_script_element.idl

	public partial class SVGScriptElement : SVGElement
	{
		protected internal SVGScriptElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string type { get => Get<string>(); set => Set(value); }
	}

	public partial class SVGScriptElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}