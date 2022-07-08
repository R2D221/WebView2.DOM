namespace WebView2.DOM
{
	public sealed class HTMLDataElement : HTMLElement
	{
		private HTMLDataElement() { }

		public string value { get => Get<string>(); set => Set(value); }
	}
}
