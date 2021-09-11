using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLLIElement : HTMLElement
	{
		protected internal HTMLLIElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public int value { get => Get<int>(); set => Set(value); }
	}
}
