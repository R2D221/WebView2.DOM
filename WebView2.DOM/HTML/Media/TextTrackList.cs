﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/text_track_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed partial class TextTrackList : EventTarget, IReadOnlyCollection<TextTrack>
	{
		private TextTrackList() { }

		//public TextTrack this[uint index] =>
		//	IndexerGet<TextTrack?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public int Count => Get<int>("length");
		public TextTrack? getTrackById(string id) => Method<TextTrack?>().Invoke(id);

		public event EventHandler<Event>? onchange { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<TrackEvent>? onaddtrack { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<TrackEvent>? onremovetrack { add => AddEvent(value); remove => RemoveEvent(value); }

		public IEnumerator<TextTrack> GetEnumerator() =>
			SymbolMethod<Iterator<TextTrack>>("iterator").Invoke();
	}
}