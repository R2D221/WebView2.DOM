namespace WebView2.DOM.Components;

public sealed class @col : HTMLTableColElementBuilder
{
	protected override HTMLTableColElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.col);

	internal override bool CanAddChild(Node child) => false;
}


