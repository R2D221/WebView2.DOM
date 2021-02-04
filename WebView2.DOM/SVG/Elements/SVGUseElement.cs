using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_use_element.idl

	public partial class SVGUseElement : SVGGraphicsElement
	{
		protected internal SVGUseElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedLength x => Get<SVGAnimatedLength>();
		public SVGAnimatedLength y => Get<SVGAnimatedLength>();
		public SVGAnimatedLength width => Get<SVGAnimatedLength>();
		public SVGAnimatedLength height => Get<SVGAnimatedLength>();
	}

	public partial class SVGUseElement : SVGURIReference
	{
		public SVGAnimatedString href => Get<SVGAnimatedString>();
	}
}