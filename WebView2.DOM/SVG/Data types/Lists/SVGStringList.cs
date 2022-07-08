using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class SVGStringList : SVGList<string>
	{
		private SVGStringList() { }
	}
}