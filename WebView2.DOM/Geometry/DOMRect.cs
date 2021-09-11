using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect.idl

	public class DOMRect : DOMRectReadOnly
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??=
			window.Instance.Get<JsObject>(nameof(DOMRect));

		protected internal DOMRect(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMRect(double x = 0, double y = 0, double width = 0, double height = 0)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			_ = (x, y, width, height) switch
			{
				(0, 0, 0, 0) => Construct(),
				(_, 0, 0, 0) => Construct(x),
				(_, _, 0, 0) => Construct(x, y),
				(_, _, _, 0) => Construct(x, y, width),
				(_, _, _, _) => Construct(x, y, width, height),
			};

		new public static DOMRect fromRect(DOMRectInit other) =>
			@static.Method<DOMRect>().Invoke(other);

		new public static DOMRect fromRect(DOMRectReadOnly other) =>
			@static.Method<DOMRect>().Invoke(other);

		new public double x { get => Get<double>(); set => Set(value); }
		new public double y { get => Get<double>(); set => Set(value); }
		new public double width { get => Get<double>(); set => Set(value); }
		new public double height { get => Get<double>(); set => Set(value); }
	}
}
