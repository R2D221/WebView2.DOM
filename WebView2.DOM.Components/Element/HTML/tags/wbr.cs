namespace WebView2.DOM.Components;

public sealed class @wbr : HTMLElementBuilder
{
	protected override HTMLElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.wbr);

	internal override bool CanAddChild(Node child) => false;
}


