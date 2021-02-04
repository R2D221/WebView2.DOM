using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_clip_path_element.idl
	
	public class SVGClipPathElement : SVGGraphicsElement
	{
		protected internal SVGClipPathElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
		
		public SVGAnimatedEnumeration<SVGUnitType> clipPathUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
	}
}