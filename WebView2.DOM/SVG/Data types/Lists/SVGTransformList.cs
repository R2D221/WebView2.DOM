using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class SVGTransformList : SVGList<SVGTransform>
	{
		protected internal SVGTransformList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix) =>
			Method<SVGTransform>().Invoke(matrix);

		public SVGTransform? consolidate() =>
			Method<SVGTransform?>().Invoke();
	}
}