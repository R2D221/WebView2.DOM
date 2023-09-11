namespace WebView2.DOM.Components;

public sealed class @iframe : HTMLIFrameElementBuilder
{
	protected override HTMLIFrameElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.iframe);

	internal override bool CanAddChild(Node child) => false;
}


