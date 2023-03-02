using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_point_read_only.idl

	public class DOMPointReadOnly : JsObject, IDOMPointInit
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMPointReadOnly));

		protected internal DOMPointReadOnly() { }

		public DOMPointReadOnly(double x = 0, double y = 0, double z = 0, double w = 1)
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

		public static DOMPointReadOnly fromPoint(DOMPointInit other) =>
			Static.Method<DOMPointReadOnly>().Invoke(other);

		public static DOMPointReadOnly fromPoint(DOMPointReadOnly other) =>
			Static.Method<DOMPointReadOnly>().Invoke(other);

		public double x => Get<double>();
		public double y => Get<double>();
		public double z => Get<double>();
		public double w => Get<double>();

		public DOMPoint matrixTransform(DOMMatrixInit matrix) =>
			Method<DOMPoint>().Invoke(matrix);

		public DOMPointInit toJSON() => Method<DOMPointInit>().Invoke();
	}
}
