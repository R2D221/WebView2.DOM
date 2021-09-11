using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unit_value.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unit_values.idl

	public class CSSUnitValue : CSSNumericValue
	{
		protected internal CSSUnitValue(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public CSSUnitValue(double value, string unit)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(value, unit);

		public double value => Get<double>();
		public string unit => Get<string>();
	}

	public static class CSS
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??= window.Instance.Get<JsObject>(nameof(CSS));

		public static CSSUnitValue number(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue percent(double value) => @static.Method<CSSUnitValue>().Invoke(value);

		// <length>
		public static CSSUnitValue em(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ex(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ch(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue rem(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vw(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vh(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vmin(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vmax(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue cm(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue mm(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue @in(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue pt(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue pc(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue px(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue Q(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		// TODO: Currently unsupported length units that are specified
		// public static CSSUnitValue ic(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue lh(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue rlh(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue vi(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue vb(double value) => @this.Method<CSSUnitValue>().Invoke(value);

		// <angle>
		public static CSSUnitValue deg(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue grad(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue rad(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue turn(double value) => @static.Method<CSSUnitValue>().Invoke(value);

		// <time>
		public static CSSUnitValue s(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ms(double value) => @static.Method<CSSUnitValue>().Invoke(value);

		// <frequency>
		public static CSSUnitValue Hz(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue kHz(double value) => @static.Method<CSSUnitValue>().Invoke(value);

		// <resolution>
		public static CSSUnitValue dpi(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue dpcm(double value) => @static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue dppx(double value) => @static.Method<CSSUnitValue>().Invoke(value);

		// <flex>
		public static CSSUnitValue fr(double value) => @static.Method<CSSUnitValue>().Invoke(value);







		public static CSSNumericValue min(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("min").Invoke(y);
		public static CSSNumericValue max(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("max").Invoke(y);
	}
}
