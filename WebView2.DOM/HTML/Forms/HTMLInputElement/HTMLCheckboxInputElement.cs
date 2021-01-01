using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLCheckboxInputElement : HTMLInputElementWithCheckednessBase
	{
		public HTMLCheckboxInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool indeterminate { get => Get<bool>(); set => Set(value); }
	}
}
