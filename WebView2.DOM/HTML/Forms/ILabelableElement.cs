using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public interface ILabelableElement : HTMLElement.OneOf<
		HTMLButtonElement,
		HTMLInputElement,
		HTMLMeterElement,
		HTMLOutputElement,
		HTMLProgressElement,
		HTMLSelectElement,
		HTMLTextAreaElement>
	{
		NodeList<HTMLLabelElement> labels { get; }
	}
}
