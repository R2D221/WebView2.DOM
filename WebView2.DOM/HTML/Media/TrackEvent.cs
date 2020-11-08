namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/track_event.idl

	public class TrackEvent : Event
	{
		public TextTrack? track => Get<TextTrack?>(); //(VideoTrack or AudioTrack or TextTrack)?
	}
}