using System;

namespace WebView2.DOM
{
	public sealed class HTMLBaseElement : HTMLElement
	{
		private HTMLBaseElement() { }

		public Uri href { get => Get<Uri>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }
	}
}
