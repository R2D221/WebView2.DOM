using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class SVGPointList : SVGList<SVGPoint>
	{
		protected internal SVGPointList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}