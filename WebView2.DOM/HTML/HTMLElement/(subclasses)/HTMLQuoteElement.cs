using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class HTMLQuoteElement : HTMLElement
	{
		protected internal HTMLQuoteElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri cite { get => Get<Uri>(); set => Set(value); }
	}
}
