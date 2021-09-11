using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class HTMLBaseElement : HTMLElement
	{
		protected internal HTMLBaseElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri href { get => Get<Uri>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }
	}
}
