using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/touch_event.idl

	public sealed class TouchEvent : UIEvent
	{
		private TouchEvent() { }

		public IReadOnlyList<Touch> touches => Get<ImmutableArray<Touch>>();
		public IReadOnlyList<Touch> targetTouches => Get<ImmutableArray<Touch>>();
		public IReadOnlyList<Touch> changedTouches => Get<ImmutableArray<Touch>>();
		public bool altKey => Get<bool>();
		public bool metaKey => Get<bool>();
		public bool ctrlKey => Get<bool>();
		public bool shiftKey => Get<bool>();
	}
}
