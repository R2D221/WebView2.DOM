using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_button_element.idl

	public class HTMLButtonElement : HTMLElement, IFormControl, ILabelableElement
	{
		protected internal HTMLButtonElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public Uri formAction { get => Get<Uri>(); set => Set(value); }
		public Enctype formEnctype { get => Get<Enctype>(); set => Set(value); }
		public Method formMethod { get => Get<Method>(); set => Set(value); }
		public bool formNoValidate { get => Get<bool>(); set => Set(value); }
		public string formTarget { get => Get<string>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public ButtonType type { get => Get<ButtonType>(); set => Set(value); }
		FormControlType IFormControl.type => Get<FormControlType>();
		public string value { get => Get<string>(); set => Set(value); }

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);

		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}

	public enum ButtonType
	{
		submit,
		reset,
		button,
	}
}
