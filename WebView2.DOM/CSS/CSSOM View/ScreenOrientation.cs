using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/screen_orientation/screen_orientation.idl

	public enum OrientationType
	{
		portrait_primary,
		portrait_secondary,
		landscape_primary,
		landscape_secondary,
	}

	public enum OrientationLockType
	{
		any,
		natural,
		landscape,
		portrait,
		portrait_primary,
		portrait_secondary,
		landscape_primary,
		landscape_secondary,
	}

	public sealed class ScreenOrientation : EventTarget
	{
		private ScreenOrientation() { }

		public ushort angle => Get<ushort>();
		public OrientationType type => Get<OrientationType>();

		public VoidPromise @lock(OrientationLockType orientation) =>
			Method<VoidPromise>().Invoke(orientation);
		public void unlock() => Method().Invoke();

		public event EventHandler<Event>? onchange { add { AddEvent(value); } remove { RemoveEvent(value); } }
	}
}
