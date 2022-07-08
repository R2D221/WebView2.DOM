namespace WebView2.DOM
{
	public sealed class HTMLTableColElement : HTMLElement
	{
		private HTMLTableColElement() { }

		public uint span { get => Get<uint>(); set => Set(value); }
	}
}
