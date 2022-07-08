namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_text_area_element.idl

	public sealed class HTMLTextAreaElement : HTMLElement, IFormControl, ILabelableElement
	{
		private HTMLTextAreaElement() { }

		public string autocomplete { get => Get<string>(); set => Set(value); }
		public uint cols { get => Get<uint>(); set => Set(value); }
		public string dirName { get => Get<string>(); set => Set(value); }
		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public int maxLength { get => Get<int>(); set => Set(value); }
		public int minLength { get => Get<int>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public string placeholder { get => Get<string>(); set => Set(value); }
		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
		public uint rows { get => Get<uint>(); set => Set(value); }
		public Wrap wrap { get => Get<Wrap>(); set => Set(value); }

		public FormControlType type => Get<FormControlType>();
		public string defaultValue { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }
		public uint textLength => Get<uint>();

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);

		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();

		public void select() => Method().Invoke();
		public uint selectionStart { get => Get<uint>(); set => Set(value); }
		public uint selectionEnd { get => Get<uint>(); set => Set(value); }
		public SelectionDirection selectionDirection { get => Get<SelectionDirection>(); set => Set(value); }
		public void setRangeText(string replacement) => Method().Invoke(replacement);
		public void setRangeText(string replacement, uint start, uint end) =>
			Method().Invoke(replacement, start, end);
		public void setRangeText(string replacement, uint start, uint end, SelectionMode selectionMode) =>
			Method().Invoke(replacement, start, end, selectionMode);
		public void setSelectionRange(uint start, uint end) =>
			Method().Invoke(start, end);
		public void setSelectionRange(uint start, uint end, SelectionDirection direction) =>
			Method().Invoke(start, end, direction);
	}

	public enum Wrap { soft, hard }

	public enum SelectionDirection { forward, backward, none }
}
