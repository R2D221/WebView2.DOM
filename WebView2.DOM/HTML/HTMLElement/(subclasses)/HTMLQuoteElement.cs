using System;

namespace WebView2.DOM
{
	public sealed class HTMLQuoteElement : HTMLElement
	{
		private HTMLQuoteElement() { }

		public Uri cite { get => Get<Uri>(); set => Set(value); }
	}
}
