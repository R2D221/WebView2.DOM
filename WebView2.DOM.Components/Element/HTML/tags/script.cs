namespace WebView2.DOM.Components;

public sealed class @script : HTMLScriptElementBuilder
{
	protected override HTMLScriptElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.script);

	internal override bool CanAddChild(Node child) => false;
}


