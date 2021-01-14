using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/text_track_cue_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class TextTrackCueList : JsObject, IReadOnlyCollection<TextTrackCue>
	{
		protected internal TextTrackCueList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public TextTrackCue this[uint index] =>
			IndexerGet<TextTrackCue?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();
		public TextTrackCue? getCueById(string id) => Method<TextTrackCue?>().Invoke(id);

		public Iterator<TextTrackCue> GetEnumerator() =>
			SymbolMethod<Iterator<TextTrackCue>>("iterator").Invoke();

		int IReadOnlyCollection<TextTrackCue>.Count => (int)length;
		IEnumerator<TextTrackCue> IEnumerable<TextTrackCue>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}