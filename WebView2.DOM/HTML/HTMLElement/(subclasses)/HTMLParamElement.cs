namespace WebView2.DOM
{
	public sealed class HTMLParamElement : HTMLElement
	{
		private HTMLParamElement() { }

		public string name { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }
	}
}
