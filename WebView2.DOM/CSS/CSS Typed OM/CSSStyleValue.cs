using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_style_value.idl

	public class CSSStyleValue : JsObject
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(CSSStyleValue));

		protected internal CSSStyleValue() { }

		public override string ToString() => Method<string>("toString").Invoke();
		public static CSSStyleValue parse(string property, string cssText) =>
			Static.Method<CSSStyleValue>().Invoke(property, cssText);
		public static IReadOnlyList<CSSStyleValue> parseAll(string property, string cssText) =>
			Static.Method<ImmutableArray<CSSStyleValue>>().Invoke(property, cssText);
	}
}
