using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_input_element.idl

	// Note: Most members of the HTMLInputElement type have been split into several subtypes.
	// So, instead of having a single HTMLInputElement type, we have e.g.
	// <input type=checkbox> => HTMLCheckboxInputElement,
	// <input type=date> => HTMLDateInputElement,
	// and so on.
	// This explicitly deviates from the HTML standard, where all members are contained into
	// the HTMLInputElement type, but I hope the separation makes it better to use the
	// properties that actually belong to each input type.

	public class HTMLInputElement : HTMLElement, IFormControl, ILabelableElement
	{
		protected internal HTMLInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();

		public string defaultValue { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }

		//public object? valueAsDate { get => Get<object?>(); set => Set(value); }
		//public double valueAsNumber { get => Get<double>(); set => Set(value); }

		public string name { get => Get<string>(); set => Set(value); }
		public FormControlType type { get => Get<FormControlType>(); /*set => Set(value);*/ }

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);

		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();

		//// Non-standard APIs
		//attribute bool webkitdirectory;
		//attribute bool incremental;
	}
}
