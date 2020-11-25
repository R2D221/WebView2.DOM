using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/track/html_track_element.idl

	public enum TrackReadyState : ushort
	{
		NONE = 0,
		LOADING = 1,
		LOADED = 2,
		ERROR = 3,
	}

	public class HTMLTrackElement : HTMLElement
	{
		protected internal HTMLTrackElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public TextTrackKind kind { get => Get<TextTrackKind>(); set => Set(value); }
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string srclang { get => Get<string>(); set => Set(value); }
		public string label { get => Get<string>(); set => Set(value); }
		public bool @default { get => Get<bool>(); set => Set(value); }

		public TrackReadyState readyState => Get<TrackReadyState>();

		public TextTrack track => Get<TextTrack>();
	}
}
