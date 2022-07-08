using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public sealed class HTMLObjectElement : HTMLElement, IFormControl
	{
		private HTMLObjectElement() { }

		public Uri data { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		FormControlType IFormControl.type => Get<FormControlType>();
		public string name { get => Get<string>(); set => Set(value); }
		public string useMap { get => Get<string>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public Document? contentDocument => Get<Document?>();
		public Window? contentWindow => Get<Window?>();
		public Document? getSVGDocument() => Method<Document?>().Invoke();

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);
	}
}
