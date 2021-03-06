﻿using Microsoft.Web.WebView2.Core;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_read_only.idl

	public class DOMRectReadOnly : JsObject
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??=
			window.Instance.Get<JsObject>(nameof(DOMRectReadOnly));

		protected internal DOMRectReadOnly(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMRectReadOnly(double x = 0, double y = 0, double width = 0, double height = 0)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			_ = (x, y, width, height) switch
			{
				(0, 0, 0, 0) => Construct(),
				(_, 0, 0, 0) => Construct(x),
				(_, _, 0, 0) => Construct(x, y),
				(_, _, _, 0) => Construct(x, y, width),
				(_, _, _, _) => Construct(x, y, width, height),
			};

		public static DOMRectReadOnly fromRect(DOMRectInit other) =>
			@static.Method<DOMRectReadOnly>().Invoke(other);

		public static DOMRectReadOnly fromRect(DOMRectReadOnly other) =>
			@static.Method<DOMRectReadOnly>().Invoke(other);

		public double x => Get<double>();
		public double y => Get<double>();
		public double width => Get<double>();
		public double height => Get<double>();
		public double top => Get<double>();
		public double right => Get<double>();
		public double bottom => Get<double>();
		public double left => Get<double>();

		public DOMRectInit toJSON() => Method<DOMRectInit>().Invoke();
	}
}
