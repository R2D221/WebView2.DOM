using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/pointer_event.idl

	public sealed class PointerEvent : MouseEvent
	{
		private PointerEvent() { }

		public int pointerId => Get<int>();
		public double width => Get<double>();
		public double height => Get<double>();
		public float pressure => Get<float>();
		public int tiltX => Get<int>();
		public int tiltY => Get<int>();
		public double azimuthAngle => Get<double>();
		public double altitudeAngle => Get<double>();
		public float tangentialPressure => Get<float>();
		public int twist => Get<int>();
		public string pointerType => Get<string>();
		public bool isPrimary => Get<bool>();

		public IReadOnlyList<PointerEvent> getCoalescedEvents() => Method<ImmutableArray<PointerEvent>>().Invoke();
		public IReadOnlyList<PointerEvent> getPredictedEvents() => Method<ImmutableArray<PointerEvent>>().Invoke();
	}
}