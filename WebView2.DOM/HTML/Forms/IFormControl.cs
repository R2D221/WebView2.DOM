using Microsoft.Web.WebView2.Core;
using OneOf;
using System;

namespace WebView2.DOM
{
	public interface IFormControl : HTMLElement.OneOf<
		HTMLButtonElement,
		HTMLFieldSetElement,
		HTMLInputElement,
		HTMLObjectElement,
		HTMLOutputElement,
		HTMLSelectElement,
		HTMLTextAreaElement>
	{
		FormControlType type { get; }
		string name { get; }
		HTMLFormElement? form { get; }
	}
}