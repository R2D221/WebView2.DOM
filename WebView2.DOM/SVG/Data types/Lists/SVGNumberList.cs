using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class SVGNumberList : SVGList<SVGNumber>
	{
		private SVGNumberList() { }
	}
}