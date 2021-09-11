using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point.idl

	public class DOMPoint : DOMPointReadOnly
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??=
			window.Instance.Get<JsObject>(nameof(DOMPoint));

		protected internal DOMPoint(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMPoint(double x = 0, double y = 0, double z = 0, double w = 1)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			_ = (x, y, z, w) switch
			{
				(0, 0, 0, 1) => Construct(),
				(_, 0, 0, 1) => Construct(x),
				(_, _, 0, 1) => Construct(x, y),
				(_, _, _, 1) => Construct(x, y, z),
				(_, _, _, _) => Construct(x, y, z, w),
			};

		new public static DOMPoint fromPoint(DOMPointInit other) =>
			@static.Method<DOMPoint>().Invoke(other);

		new public static DOMPoint fromPoint(DOMPointReadOnly other) =>
			@static.Method<DOMPoint>().Invoke(other);

		new public double x { get => Get<double>(); set => Set(value); }
		new public double y { get => Get<double>(); set => Set(value); }
		new public double z { get => Get<double>(); set => Set(value); }
		new public double w { get => Get<double>(); set => Set(value); }
	}
}
