using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class SVGPointList : SVGList<SVGPoint>
	{
		private SVGPointList() { }
	}
}