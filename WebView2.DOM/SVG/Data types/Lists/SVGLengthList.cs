using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class SVGLengthList : SVGList<SVGLength>
	{
		private SVGLengthList() { }
	}
}