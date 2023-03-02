using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_rect.idl

	public class DOMRect : DOMRectReadOnly
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMRect));

		protected internal DOMRect() { }

		public DOMRect(double x = 0, double y = 0, double width = 0, double height = 0)
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

		new public static DOMRect fromRect(DOMRectInit other) =>
			Static.Method<DOMRect>().Invoke(other);

		new public static DOMRect fromRect(DOMRectReadOnly other) =>
			Static.Method<DOMRect>().Invoke(other);

		new public double x { get => Get<double>(); set => Set(value); }
		new public double y { get => Get<double>(); set => Set(value); }
		new public double width { get => Get<double>(); set => Set(value); }
		new public double height { get => Get<double>(); set => Set(value); }
	}
}
