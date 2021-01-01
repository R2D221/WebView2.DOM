using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLSearchInputElement : HTMLInputElementWithSelectableTextBase
	{
		public HTMLSearchInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string dirName { get => Get<string>(); set => Set(value); }
		public HTMLDataListElement? list => Get<HTMLDataListElement?>();
	}
}
