namespace WebView2.DOM
{
	public sealed class HTMLLIElement : HTMLElement
	{
		private HTMLLIElement() { }

		public int value { get => Get<int>(); set => Set(value); }
	}
}
