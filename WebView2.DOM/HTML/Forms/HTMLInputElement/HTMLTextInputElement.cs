using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTextInputElement : HTMLInputElementWithSelectableTextBase
	{
		public HTMLTextInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string dirName { get => Get<string>(); set => Set(value); }
		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
