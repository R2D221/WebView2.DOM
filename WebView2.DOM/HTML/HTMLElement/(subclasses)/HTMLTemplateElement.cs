namespace WebView2.DOM
{
	public sealed class HTMLTemplateElement : HTMLElement
	{
		private HTMLTemplateElement() { }

		public DocumentFragment content => Get<DocumentFragment>();
		// readonly attribute ShadowRoot? shadowRoot;
	}
}
