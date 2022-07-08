namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/input/touch.idl

	public sealed class Touch : JsObject
	{
		private Touch() { }

		public int identifier => Get<int>();
		public EventTarget target => Get<EventTarget>();
		public double screenX => Get<double>();
		public double screenY => Get<double>();
		public double clientX => Get<double>();
		public double clientY => Get<double>();
		public double pageX => Get<double>();
		public double pageY => Get<double>();
		public float radiusX => Get<float>();
		public float radiusY => Get<float>();
		public float rotationAngle => Get<float>();
		public float force => Get<float>();

		// Canvas Hit Regions
		//public string? region => Get<string?>();
	}
}
