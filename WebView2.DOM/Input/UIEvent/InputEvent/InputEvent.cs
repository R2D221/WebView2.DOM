using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/input_event.idl

	public sealed class InputEvent : UIEvent
	{
		private InputEvent() { }

		internal override void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public string? data => Get<string?>();
		public bool isComposing => Get<bool>();

		// Input Events Level 1
		public string inputType => Get<string>();
		public DataTransfer? dataTransfer => Get<DataTransfer?>();
		public IReadOnlyList<StaticRange> getTargetRanges() => Method<ImmutableArray<StaticRange>>().Invoke();
	}
}