using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

	public class ScreenOrientation : EventTarget
	{
		public ushort angle => Get<ushort>();
		public OrientationType type => Get<OrientationType>();

		public Task @lock(OrientationLockType orientation)
			=> Method<Task>().Invoke(orientation);
		public void unlock() => Method().Invoke();

		public event EventHandler<Event>? onchange { add { AddEvent(value); } remove { RemoveEvent(value); } }
	}
}
