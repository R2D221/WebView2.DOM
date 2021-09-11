using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLDataElement : HTMLElement
	{
		protected internal HTMLDataElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string value { get => Get<string>(); set => Set(value); }
	}
}
