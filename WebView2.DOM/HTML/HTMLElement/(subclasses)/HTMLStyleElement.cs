namespace WebView2.DOM
{
	public sealed class HTMLStyleElement : HTMLElement
	{
		private HTMLStyleElement() { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }

		public StyleSheet? sheet => Get<StyleSheet?>();
	}
}
