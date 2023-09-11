namespace WebView2.DOM.Components;

public sealed class @source : HTMLSourceElementBuilder
{
	protected override HTMLSourceElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.source);

	internal override bool CanAddChild(Node child) => false;
}


