using Microsoft.Web.WebView2.Core;
using System;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_quad.idl

	public class DOMQuad : JsObject
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMQuad));

		protected internal DOMQuad() { }

		public DOMQuad(DOMPointInit p1, DOMPointInit p2, DOMPointInit p3, DOMPointInit p4) =>
			Construct(p1, p2, p3, p4);

		public DOMQuad(IDOMPointInit p1, IDOMPointInit p2, IDOMPointInit p3, IDOMPointInit p4) =>
			Construct(p1, p2, p3, p4);

		public static DOMQuad fromRect(DOMRectInit other) =>
			Static.Method<DOMQuad>().Invoke(other);

		public static DOMQuad fromRect(DOMRectReadOnly other) =>
			Static.Method<DOMQuad>().Invoke(other);

		public static DOMQuad fromQuad(DOMQuadInit other) =>
			Static.Method<DOMQuad>().Invoke(other);

		public static DOMQuad fromQuad(DOMQuad other) =>
			Static.Method<DOMQuad>().Invoke(other);

		public DOMPoint p1 => GetCached<DOMPoint>();
		public DOMPoint p2 => GetCached<DOMPoint>();
		public DOMPoint p3 => GetCached<DOMPoint>();
		public DOMPoint p4 => GetCached<DOMPoint>();

		public DOMRect getBounds() => Method<DOMRect>().Invoke();

		public DOMQuadInit toJSON() => Method<DOMQuadInit>().Invoke();
	}
}
