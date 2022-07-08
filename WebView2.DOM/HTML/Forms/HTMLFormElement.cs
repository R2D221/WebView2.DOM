using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_form_element.idl

	public sealed class HTMLFormElement : HTMLElement
	{
		private HTMLFormElement() { }

		public string acceptCharset { get => Get<string>(); set => Set(value); }
		public Uri action { get => Get<Uri>(); set => Set(value); }
		public Autocomplete autocomplete { get => Get<Autocomplete>(); set => Set(value); }
		public Enctype enctype { get => Get<Enctype>(); set => Set(value); }
		public Method method { get => Get<Method>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public bool noValidate { get => Get<bool>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }

		public HTMLFormControlsCollection elements => Get<HTMLFormControlsCollection>();

		public void submit() => Method().Invoke();
		public void requestSubmit() => Method().Invoke();
		public void requestSubmit(HTMLElement submitter) => Method().Invoke(submitter);
		public void reset() => Method().Invoke();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
	}

	public enum Autocomplete { on, off }
}
