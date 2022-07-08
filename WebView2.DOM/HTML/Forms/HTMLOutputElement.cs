namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_output_element.idl

	public sealed class HTMLOutputElement : HTMLElement, IFormControl, ILabelableElement
	{
		private HTMLOutputElement() { }

		public DOMTokenList htmlFor => Get<DOMTokenList>();
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public string name { get => Get<string>(); set => Set(value); }

		public FormControlType type => Get<FormControlType>();
		public string defaultValue { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);

		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}
}
