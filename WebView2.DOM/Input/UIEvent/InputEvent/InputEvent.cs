﻿using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/input_event.idl

	public class InputEvent : UIEvent
	{
		protected internal InputEvent(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string? data => Get<string?>();
		public bool isComposing => Get<bool>();

		// Input Events Level 1
		public string inputType => Get<string>();
		public DataTransfer? dataTransfer => Get<DataTransfer?>();
		public IReadOnlyList<StaticRange> getTargetRanges() => Method<ImmutableArray<StaticRange>>().Invoke();
	}
}