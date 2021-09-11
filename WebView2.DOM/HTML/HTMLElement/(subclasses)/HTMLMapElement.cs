using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLMapElement : HTMLElement
	{
		protected internal HTMLMapElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string name { get => Get<string>(); set => Set(value); }
		public HTMLCollection<HTMLAreaElement> areas => Get<HTMLCollection<HTMLAreaElement>>();
	}
}
