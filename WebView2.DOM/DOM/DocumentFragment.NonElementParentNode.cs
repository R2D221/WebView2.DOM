namespace WebView2.DOM
{
	public partial class DocumentFragment : NonElementParentNode
	{
		public Element? getElementById(string elementId) => Method<Element?>().Invoke(elementId);
	}
}