using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_animated_enumeration.idl

	public sealed class SVGAnimatedEnumeration : JsObject
	{
		internal SVGAnimatedEnumeration(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}

	public class SVGAnimatedEnumeration<TEnum> : JsObject
		where TEnum : struct, Enum
	{
		protected internal SVGAnimatedEnumeration(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public static implicit operator SVGAnimatedEnumeration<TEnum>(SVGAnimatedEnumeration value) =>
			new SVGAnimatedEnumeration<TEnum>(value);

		internal SVGAnimatedEnumeration(SVGAnimatedEnumeration value)
			: base(value.coreWebView, value.referenceId)
		{
			References.Update(target: this);
		}

		public TEnum baseVal { get => Get<TEnum>(); set => Set(value); }
		public TEnum animVal => Get<TEnum>();
	}
}