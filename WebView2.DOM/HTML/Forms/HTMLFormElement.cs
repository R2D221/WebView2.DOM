using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class HTMLFormElement : HTMLElement
	{
		protected internal HTMLFormElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public HTMLFormElement() : this(null!, null!) { }
	}
}
