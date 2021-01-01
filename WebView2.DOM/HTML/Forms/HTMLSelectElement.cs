using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_select_element.idl

	public class HTMLSelectElement : HTMLElement, IFormControl, ILabelableElement
	{
		protected internal HTMLSelectElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string autocomplete { get => Get<string>(); set => Set(value); }
		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public bool multiple { get => Get<bool>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
		public uint size { get => Get<uint>(); set => Set(value); }

		public FormControlType type => Get<FormControlType>();

		public HTMLOptionsCollection options => Get<HTMLOptionsCollection>();

		public HTMLCollection<HTMLOptionElement> selectedOptions => Get<HTMLCollection<HTMLOptionElement>>();
		public int selectedIndex { get => Get<int>(); set => Set(value); }
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
