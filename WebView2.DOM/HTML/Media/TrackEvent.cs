using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/track_event.idl

	public class TrackEvent : Event
	{
		protected internal TrackEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public TextTrack? track => Get<TextTrack?>(); //(VideoTrack or AudioTrack or TextTrack)?
	}
}