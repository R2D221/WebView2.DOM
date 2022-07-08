namespace WebView2.DOM
{
	public sealed class HTMLUListElement : HTMLElement
	{
		private HTMLUListElement() { }

		public string text { get => Get<string>(); set => Set(value); }
	}
}
