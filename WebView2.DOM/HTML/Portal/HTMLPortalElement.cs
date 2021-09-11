using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	[Obsolete("Not implemented", true)]
	public class HTMLPortalElement : HTMLElement
	{
		protected internal HTMLPortalElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
