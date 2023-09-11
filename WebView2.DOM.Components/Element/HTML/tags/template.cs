using System;

namespace WebView2.DOM.Components;

public sealed class @template : HTMLTemplateElementBuilder
{
	protected override HTMLTemplateElement CreateElement()
	{
		throw new NotSupportedException();
		//return document.createHTMLElement(HTMLElementTag.template);
	}

	internal override bool CanAddChild(Node child) => true;
}


