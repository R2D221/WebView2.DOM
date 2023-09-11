using System;

namespace WebView2.DOM.Components;

public sealed class @head : HTMLHeadElementBuilder
{
	protected override HTMLHeadElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.head);

	internal override bool CanAddChild(Node child)
	{
		// Metadata content
		// Exactly one title element
		throw new NotImplementedException();
	}
}


