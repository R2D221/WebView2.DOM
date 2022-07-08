using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class SVGTransformList : SVGList<SVGTransform>
	{
		private SVGTransformList() { }

		public SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix) =>
			Method<SVGTransform>().Invoke(matrix);

		public SVGTransform? consolidate() =>
			Method<SVGTransform?>().Invoke();
	}
}