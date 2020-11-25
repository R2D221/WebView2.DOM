using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/wheel_event.idl

	public enum DeltaMode : uint
	{
		PIXEL = 0,
		LINE = 1,
		PAGE = 2,
	}

	public class WheelEvent : MouseEvent
	{
		protected internal WheelEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public double deltaX => Get<double>();
		public double deltaY => Get<double>();
		public double deltaZ => Get<double>();
		public DeltaMode deltaMode => Get<DeltaMode>();

		// Non-standard APIs
		//public int wheelDeltaX => Get<int>();
		//public int wheelDeltaY => Get<int>();
		//public int wheelDelta => Get<int>();
	}
}
