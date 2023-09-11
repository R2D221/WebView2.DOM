namespace WebView2.DOM.Components;

public abstract class HTMLDialogElementBuilder : HTMLElementBuilder<HTMLDialogElement>
{
	// R2D221 - 2023-08-20
	// I decided not to include this attribute because setting it
	// in code rather than markup does some wacky stuff:
	// https://developer.mozilla.org/en-US/docs/Web/HTML/Element/dialog#attributes
	// https://html.spec.whatwg.org/multipage/interactive-elements.html#attr-dialog-open
	// Better use the show(), showModal(), close() methods.

	// /// <summary>
	// /// Whether the dialog box is showing
	// /// </summary>
	// public TwoWayAttributeBuilder<bool> open
	// {
	// 	get => new(() => element.open, x => element.close += x);
	// 	set => element.open = value.GetConstantValue();
	// }
}
