﻿namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_style_element.idl

	public sealed class SVGStyleElement : SVGElement
	{
		private SVGStyleElement() { }

		public string type { get => Get<string>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
		public string title { get => Get<string>(); set => Set(value); }

		public StyleSheet? sheet => Get<StyleSheet?>();

		public bool disabled { get => Get<bool>(); set => Set(value); }
	}
}