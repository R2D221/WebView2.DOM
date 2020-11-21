using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/text_track_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class TextTrackList : EventTarget, ICollection<TextTrack>, IReadOnlyCollection<TextTrack>
	{

		public TextTrack this[uint index] =>
			IndexerGet<TextTrack?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public TextTrack? getTrackById(string id) => Method<TextTrack?>().Invoke(id);

		public event EventHandler<Event>? onchange { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<TrackEvent>? onaddtrack { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<TrackEvent>? onremovetrack { add => AddEvent(value); remove => RemoveEvent(value); }

		public Iterator<TextTrack> GetEnumerator() =>
			SymbolMethod<Iterator<TextTrack>>("iterator").Invoke();

		int IReadOnlyCollection<TextTrack>.Count => (int)length;
		int ICollection<TextTrack>.Count => (int)length;
		bool ICollection<TextTrack>.IsReadOnly => true;
		void ICollection<TextTrack>.Add(TextTrack item) => throw new NotSupportedException();
		void ICollection<TextTrack>.Clear() => throw new NotSupportedException();
		bool ICollection<TextTrack>.Contains(TextTrack item) => this.Any(x => x == item);
		void ICollection<TextTrack>.CopyTo(TextTrack[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<TextTrack>.Remove(TextTrack item) => throw new NotSupportedException();
		IEnumerator<TextTrack> IEnumerable<TextTrack>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}