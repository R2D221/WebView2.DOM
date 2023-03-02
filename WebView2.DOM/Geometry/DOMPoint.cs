using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point.idl

	public class DOMPoint : DOMPointReadOnly
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMPoint));

		protected internal DOMPoint() { }

		public DOMPoint(double x = 0, double y = 0, double z = 0, double w = 1)
		{
			switch ((x, y, z, w))
			{
			case ((0, 0, 0, 1)): Construct(); break;
			case ((_, 0, 0, 1)): Construct(x); break;
			case ((_, _, 0, 1)): Construct(x, y); break;
			case ((_, _, _, 1)): Construct(x, y, z); break;
			case ((_, _, _, _)): Construct(x, y, z, w); break;
			};
		}

		new public static DOMPoint fromPoint(DOMPointInit other) =>
			Static.Method<DOMPoint>().Invoke(other);

		new public static DOMPoint fromPoint(DOMPointReadOnly other) =>
			Static.Method<DOMPoint>().Invoke(other);

		new public double x { get => Get<double>(); set => Set(value); }
		new public double y { get => Get<double>(); set => Set(value); }
		new public double z { get => Get<double>(); set => Set(value); }
		new public double w { get => Get<double>(); set => Set(value); }
	}
}
