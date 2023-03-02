using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect_read_only.idl

	public class DOMRectReadOnly : JsObject
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMRectReadOnly));

		protected internal DOMRectReadOnly() { }

		public DOMRectReadOnly(double x = 0, double y = 0, double width = 0, double height = 0)
		{
			switch ((x, y, width, height))
			{
			case ((0, 0, 0, 0)): Construct(); break;
			case ((_, 0, 0, 0)): Construct(x); break;
			case ((_, _, 0, 0)): Construct(x, y); break;
			case ((_, _, _, 0)): Construct(x, y, width); break;
			case ((_, _, _, _)): Construct(x, y, width, height); break;
			};
		}

		public static DOMRectReadOnly fromRect(DOMRectInit other) =>
			Static.Method<DOMRectReadOnly>().Invoke(other);

		public static DOMRectReadOnly fromRect(DOMRectReadOnly other) =>
			Static.Method<DOMRectReadOnly>().Invoke(other);

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
