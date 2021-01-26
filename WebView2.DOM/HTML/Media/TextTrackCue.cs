using Microsoft.Web.WebView2.Core;
using NodaTime;
using System;

namespace WebView2.DOM
{
	public class TextTrackCue : EventTarget
	{
		protected internal TextTrackCue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public TextTrack? track => Get<TextTrack?>();

		public string id { get => Get<string>(); set => Set(value); }
		public Duration startTime { get => Duration.FromSeconds(Get<double>()); set => Set(value.TotalSeconds); }
		public Duration endTime { get => Duration.FromSeconds(Get<double>()); set => Set(value.TotalSeconds); }
		public bool pauseOnExit { get => Get<bool>(); set => Set(value); }

		public event EventHandler<Event>? onenter { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onexit { add => AddEvent(value); remove => RemoveEvent(value); }
	}
}