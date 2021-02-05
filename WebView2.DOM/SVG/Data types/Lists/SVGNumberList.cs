using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class SVGNumberList : SVGList<SVGNumber>
	{
		protected internal SVGNumberList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}