using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLParamElement : HTMLElement
	{
		protected internal HTMLParamElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }
	}
}
