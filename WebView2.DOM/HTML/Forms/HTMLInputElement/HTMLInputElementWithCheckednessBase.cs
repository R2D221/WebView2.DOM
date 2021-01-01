using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public abstract class HTMLInputElementWithCheckednessBase : HTMLInputElement
	{
		protected internal HTMLInputElementWithCheckednessBase(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool defaultChecked { get => Get<bool>(); set => Set(value); }
		public bool @checked { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
