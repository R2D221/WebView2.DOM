using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTitleElement : HTMLElement
	{
		protected internal HTMLTitleElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string text { get => Get<string>(); set => Set(value); }
	}
}
