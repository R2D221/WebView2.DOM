namespace WebView2.DOM
{
	public partial class CharacterData : NonDocumentTypeChildNode
	{
		public Element? previousElementSibling => Get<Element?>();
		public Element? nextElementSibling => Get<Element?>();
	}
}