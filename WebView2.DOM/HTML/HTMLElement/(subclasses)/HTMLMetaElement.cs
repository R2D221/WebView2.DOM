namespace WebView2.DOM
{
	public sealed class HTMLMetaElement : HTMLElement
	{
		private HTMLMetaElement() { }

		public string name { get => Get<string>(); set => Set(value); }
		public string httpEquiv { get => Get<string>(); set => Set(value); }
		public string content { get => Get<string>(); set => Set(value); }
	}
}
