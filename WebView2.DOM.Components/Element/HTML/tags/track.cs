namespace WebView2.DOM.Components;

public sealed class @track : HTMLTrackElementBuilder
{
	protected override HTMLTrackElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.track);

	internal override bool CanAddChild(Node child) => false;
}


