namespace WebView2.DOM.Components;

public sealed class @embed : HTMLEmbedElementBuilder
{
	protected override HTMLEmbedElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.embed);

	internal override bool CanAddChild(Node child) => false;
}


