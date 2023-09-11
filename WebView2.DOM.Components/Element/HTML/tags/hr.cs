namespace WebView2.DOM.Components;

public sealed class @hr : HTMLHRElementBuilder
{
	protected override HTMLHRElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.hr);

	internal override bool CanAddChild(Node child) => false;
}


