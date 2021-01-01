using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLHiddenInputElement : HTMLInputElement
	{
		protected internal HTMLHiddenInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string autocomplete { get => Get<string>(); set => Set(value); }
	}
}
