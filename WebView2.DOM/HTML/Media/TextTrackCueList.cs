using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/text_track_cue_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class TextTrackCueList : JsObject, ICollection<TextTrackCue>, IReadOnlyCollection<TextTrackCue>
	{
		protected internal TextTrackCueList(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public TextTrackCue this[uint index] =>
			IndexerGet<TextTrackCue?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public TextTrackCue? getCueById(string id) => Method<TextTrackCue?>().Invoke(id);

		public Iterator<TextTrackCue> GetEnumerator() =>
			SymbolMethod<Iterator<TextTrackCue>>("iterator").Invoke();

		int IReadOnlyCollection<TextTrackCue>.Count => (int)length;
		int ICollection<TextTrackCue>.Count => (int)length;
		bool ICollection<TextTrackCue>.IsReadOnly => true;
		void ICollection<TextTrackCue>.Add(TextTrackCue item) => throw new NotSupportedException();
		void ICollection<TextTrackCue>.Clear() => throw new NotSupportedException();
		bool ICollection<TextTrackCue>.Contains(TextTrackCue item) => this.Any(x => x == item);
		void ICollection<TextTrackCue>.CopyTo(TextTrackCue[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<TextTrackCue>.Remove(TextTrackCue item) => throw new NotSupportedException();
		IEnumerator<TextTrackCue> IEnumerable<TextTrackCue>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}