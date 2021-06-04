using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_style_value.idl

	public class CSSStyleValue : JsObject
	{
		protected internal CSSStyleValue(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		private static readonly AsyncLocal<Function?> _static = new();
		private static Function @static => _static.Value ??= window.Instance.Get<Function>(nameof(CSSStyleValue));

		public override string ToString() => Method<string>("toString").Invoke();
		public static CSSStyleValue parse(string property, string cssText) =>
			@static.Method<CSSStyleValue>().Invoke(property, cssText);
		public static IReadOnlyList<CSSStyleValue> parseAll(string property, string cssText) =>
			@static.Method<ImmutableArray<CSSStyleValue>>().Invoke(property, cssText);
	}
}
