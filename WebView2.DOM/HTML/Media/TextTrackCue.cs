using NodaTime;
using System;

namespace WebView2.DOM
{
	public sealed class TextTrackCue : EventTarget
	{
		private TextTrackCue() { }

		public TextTrack? track => Get<TextTrack?>();

		public string id { get => Get<string>(); set => Set(value); }
		public Duration startTime { get => Duration.FromSeconds(Get<double>()); set => Set(value.TotalSeconds); }
		public Duration endTime { get => Duration.FromSeconds(Get<double>()); set => Set(value.TotalSeconds); }
		public bool pauseOnExit { get => Get<bool>(); set => Set(value); }

		public event EventHandler<Event>? onenter { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onexit { add => AddEvent(value); remove => RemoveEvent(value); }
	}
}