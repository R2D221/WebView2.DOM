namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_opt_group_element.idl

	public sealed class HTMLOptGroupElement : HTMLElement
	{
		private HTMLOptGroupElement() { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public string label { get => Get<string>(); set => Set(value); }
	}
}
