using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unit_value.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unit_values.idl

	public class CSSUnitValue : CSSNumericValue
	{
		protected internal CSSUnitValue() { }

		public CSSUnitValue(double value, string unit) =>
			Construct(value, unit);

		public double value => Get<double>();
		public string unit => Get<string>();
	}

	public sealed class CSS : JsObject
	{
		// R2D221 - 2023-03-02
		// This class is sealed and not static because it
		// maps to the 'CSS' object in JavaScript according to
		// its string tag.

		private CSS() { }
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(CSS));

		public static CSSUnitValue number(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue percent(double value) => Static.Method<CSSUnitValue>().Invoke(value);

		// <length>
		public static CSSUnitValue em(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ex(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ch(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue rem(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vw(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vh(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vmin(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue vmax(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue cm(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue mm(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue @in(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue pt(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue pc(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue px(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue Q(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		// TODO: Currently unsupported length units that are specified
		// public static CSSUnitValue ic(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue lh(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue rlh(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue vi(double value) => @this.Method<CSSUnitValue>().Invoke(value);
		// public static CSSUnitValue vb(double value) => @this.Method<CSSUnitValue>().Invoke(value);

		// <angle>
		public static CSSUnitValue deg(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue grad(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue rad(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue turn(double value) => Static.Method<CSSUnitValue>().Invoke(value);

		// <time>
		public static CSSUnitValue s(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue ms(double value) => Static.Method<CSSUnitValue>().Invoke(value);

		// <frequency>
		public static CSSUnitValue Hz(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue kHz(double value) => Static.Method<CSSUnitValue>().Invoke(value);

		// <resolution>
		public static CSSUnitValue dpi(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue dpcm(double value) => Static.Method<CSSUnitValue>().Invoke(value);
		public static CSSUnitValue dppx(double value) => Static.Method<CSSUnitValue>().Invoke(value);

		// <flex>
		public static CSSUnitValue fr(double value) => Static.Method<CSSUnitValue>().Invoke(value);







		public static CSSNumericValue min(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("min").Invoke(y);
		public static CSSNumericValue max(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("max").Invoke(y);
	}
}
