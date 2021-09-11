using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLDetailsElement : HTMLElement
	{
		protected internal HTMLDetailsElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool open { get => Get<bool>(); set => Set(value); }
	}
}
