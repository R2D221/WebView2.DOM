namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_field_set_element.idl

	public sealed class HTMLFieldSetElement : HTMLElement, IFormControl
	{
		private HTMLFieldSetElement() { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public string name { get => Get<string>(); set => Set(value); }

		public FormControlType type => Get<FormControlType>();

		public HTMLCollection<IFormControl> elements => Get<HTMLCollection<IFormControl>>();

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);
	}
}
