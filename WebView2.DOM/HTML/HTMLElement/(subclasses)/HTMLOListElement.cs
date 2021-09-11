using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLOListElement : HTMLElement
	{
		protected internal HTMLOListElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool reversed { get => Get<bool>(); set => Set(value); }
		public int start { get => Get<int>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
	}
}
