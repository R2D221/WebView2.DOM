namespace WebView2.DOM.Components;

public sealed class @base : HTMLBaseElementBuilder
{
	protected override HTMLBaseElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.@base);

	internal override bool CanAddChild(Node child) => false;
}


