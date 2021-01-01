using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLColorInputElement : HTMLInputElement
	{
		protected internal HTMLColorInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string autocomplete { get => Get<string>(); set => Set(value); }
		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
