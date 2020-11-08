using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/text_track.idl

	public enum TextTrackMode { disabled, hidden, showing };
	public enum TextTrackKind { _, subtitles, captions, descriptions, chapters, metadata };

	public class TextTrack : EventTarget
	{
		public TextTrackKind kind => Get<TextTrackKind>();
		public string label => Get<string>();
		public string language => Get<string>();

		public string id => Get<string>();
		// readonly attribute string inBandMetadataTrackDispatchType;

		public TextTrackMode mode { get => Get<TextTrackMode>(); set => Set(value); }

		public TextTrackCueList? cues => Get<TextTrackCueList?>();
		public TextTrackCueList? activeCues => Get<TextTrackCueList?>();

		public void addCue(TextTrackCue cue) => Method().Invoke(cue);
		public void removeCue(TextTrackCue cue) => Method().Invoke(cue);

		public event EventHandler<Event>? oncuechange { add => AddEvent(value); remove => RemoveEvent(value); }
	}
}
