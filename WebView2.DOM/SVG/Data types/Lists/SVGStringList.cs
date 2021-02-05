using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class SVGStringList : SVGList<string>
	{
		protected internal SVGStringList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}