namespace WebView2.DOM
{
	public sealed class HTMLTitleElement : HTMLElement
	{
		private HTMLTitleElement() { }

		public string text { get => Get<string>(); set => Set(value); }
	}
}
