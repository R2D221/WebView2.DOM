using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_enumeration.idl

	public abstract class SVGAnimatedEnumeration : JsObject { }

	public sealed class SVGAnimatedEnumeration<TEnum> : SVGAnimatedEnumeration
		where TEnum : struct, Enum
	{
		private SVGAnimatedEnumeration() { }

		public TEnum baseVal { get => Get<TEnum>(); set => Set(value); }
		public TEnum animVal => Get<TEnum>();
	}
}