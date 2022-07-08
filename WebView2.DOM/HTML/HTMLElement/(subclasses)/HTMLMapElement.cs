namespace WebView2.DOM
{
	public sealed class HTMLMapElement : HTMLElement
	{
		private HTMLMapElement() { }

		public string name { get => Get<string>(); set => Set(value); }
		public HTMLCollection<HTMLAreaElement> areas => Get<HTMLCollection<HTMLAreaElement>>();
	}
}
