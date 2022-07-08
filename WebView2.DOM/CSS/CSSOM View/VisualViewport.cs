using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/visual_viewport.idl

	public sealed class VisualViewport : EventTarget
	{
		private VisualViewport() { }

		public double offsetLeft => Get<double>();
		public double offsetTop => Get<double>();

		public double pageLeft => Get<double>();
		public double pageTop => Get<double>();

		public double width => Get<double>();
		public double height => Get<double>();

		public double scale => Get<double>();

		public event EventHandler<Event>? onresize { add { AddEvent(value); } remove { RemoveEvent(value); } }
		public event EventHandler<Event>? onscroll { add { AddEvent(value); } remove { RemoveEvent(value); } }
	}
}
