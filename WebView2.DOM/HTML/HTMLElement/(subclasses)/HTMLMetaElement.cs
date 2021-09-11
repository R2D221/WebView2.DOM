using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLMetaElement : HTMLElement
	{
		protected internal HTMLMetaElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name { get => Get<string>(); set => Set(value); }
		public string httpEquiv { get => Get<string>(); set => Set(value); }
		public string content { get => Get<string>(); set => Set(value); }
	}
}
