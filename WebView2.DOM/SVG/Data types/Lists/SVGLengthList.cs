using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class SVGLengthList : SVGList<SVGLength>
	{
		protected internal SVGLengthList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}