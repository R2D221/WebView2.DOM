using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLTableColElement : HTMLElement
	{
		protected internal HTMLTableColElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public uint span { get => Get<uint>(); set => Set(value); }
	}
}
