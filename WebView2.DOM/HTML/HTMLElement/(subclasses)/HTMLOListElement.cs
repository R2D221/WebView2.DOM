namespace WebView2.DOM
{
	public sealed class HTMLOListElement : HTMLElement
	{
		private HTMLOListElement() { }

		public bool reversed { get => Get<bool>(); set => Set(value); }
		public int start { get => Get<int>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
	}
}
