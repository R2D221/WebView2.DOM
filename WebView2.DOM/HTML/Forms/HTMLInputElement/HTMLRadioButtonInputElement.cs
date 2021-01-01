using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLRadioButtonInputElement : HTMLInputElementWithCheckednessBase
	{
		public HTMLRadioButtonInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}
}
