using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLUListElement : HTMLElement
	{
		protected internal HTMLUListElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string text { get => Get<string>(); set => Set(value); }
	}
}
