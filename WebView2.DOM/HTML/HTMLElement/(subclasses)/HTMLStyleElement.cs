using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLStyleElement : HTMLElement
	{
		protected internal HTMLStyleElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }

		public StyleSheet? sheet => Get<StyleSheet?>();
	}
}
