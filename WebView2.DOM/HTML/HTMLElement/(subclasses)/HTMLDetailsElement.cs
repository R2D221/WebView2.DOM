namespace WebView2.DOM
{
	public sealed class HTMLDetailsElement : HTMLElement
	{
		private HTMLDetailsElement() { }

		public bool open { get => Get<bool>(); set => Set(value); }
	}
}
