using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point_read_only.idl

	public class DOMPointReadOnly : JsObject, IDOMPointInit
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??=
			window.Instance.Get<JsObject>(nameof(DOMPointReadOnly));

		protected internal DOMPointReadOnly(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMPointReadOnly(double x = 0, double y = 0, double z = 0, double w = 1)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			_ = (x, y, z, w) switch
			{
				(0, 0, 0, 1) => Construct(),
				(_, 0, 0, 1) => Construct(x),
				(_, _, 0, 1) => Construct(x, y),
				(_, _, _, 1) => Construct(x, y, z),
				(_, _, _, _) => Construct(x, y, z, w),
			};

		public static DOMPointReadOnly fromPoint(DOMPointInit other) =>
			@static.Method<DOMPointReadOnly>().Invoke(other);

		public static DOMPointReadOnly fromPoint(DOMPointReadOnly other) =>
			@static.Method<DOMPointReadOnly>().Invoke(other);

		public double x => Get<double>();
		public double y => Get<double>();
		public double z => Get<double>();
		public double w => Get<double>();

		public DOMPoint matrixTransform(DOMMatrixInit matrix) =>
			Method<DOMPoint>().Invoke(matrix);

		public DOMPointInit toJSON() => Method<DOMPointInit>().Invoke();
	}
}
