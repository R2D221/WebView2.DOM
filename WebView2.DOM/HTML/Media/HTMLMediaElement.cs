﻿using NodaTime;
using Savage.Range;
using System;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/media/html_media_element.idl

	public enum NetworkState : ushort
	{
		EMPTY = 0,
		IDLE = 1,
		LOADING = 2,
		NO_SOURCE = 3,
	}

	public enum CanPlayTypeResult { _, maybe, probably }

	public enum Preload { none, metadata, auto }

	public enum MediaReadyState : ushort
	{
		HAVE_NOTHING = 0,
		HAVE_METADATA = 1,
		HAVE_CURRENT_DATA = 2,
		HAVE_FUTURE_DATA = 3,
		HAVE_ENOUGH_DATA = 4,
	}

	public abstract class HTMLMediaElement : HTMLElement
	{
		private protected HTMLMediaElement() { }

		// error state
		public MediaError? error => Get<MediaError?>();

		// network state
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public Uri currentSrc => Get<Uri>();
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public NetworkState networkState => Get<NetworkState>();
		public Preload preload { get => Get<Preload>(); set => Set(value); }
		public ImmutableArray<Range<Duration>> buffered => Get<TimeRanges>().ToImmutableArray();

		public void load() => Method().Invoke();
		public CanPlayTypeResult canPlayType(string type) => Method<CanPlayTypeResult>().Invoke(type);

		// ready state
		public MediaReadyState readyState => Get<MediaReadyState>();
		public bool seeking => Get<bool>();

		// playback state
		public Duration currentTime { get => Duration.FromSeconds(Get<double>()); set => Set(value.TotalSeconds); }
		public Duration? duration =>
			!(Get<double>() is double ddd) ? throw new InvalidOperationException() :
			double.IsNaN(ddd) ? default(Duration?) :
			double.IsPositiveInfinity(ddd) ? Duration.MaxValue :
			Duration.FromSeconds(ddd)
			;

		public bool paused => Get<bool>();
		public double defaultPlaybackRate { get => Get<double>(); set => Set(value); }
		public double playbackRate { get => Get<double>(); set => Set(value); }
		public ImmutableArray<Range<Duration>> played => Get<TimeRanges>().ToImmutableArray();
		public ImmutableArray<Range<Duration>> seekable => Get<TimeRanges>().ToImmutableArray();
		public bool ended => Get<bool>();
		public bool autoplay { get => Get<bool>(); set => Set(value); }
		public bool loop { get => Get<bool>(); set => Set(value); }
		public VoidPromise play() => Method<VoidPromise>().Invoke();
		public void pause() => Method().Invoke();
		//attribute double latencyHint;
		//attribute boolean preservesPitch;

		// controls
		public bool controls { get => Get<bool>(); set => Set(value); }
		public DOMTokenList controlsList => GetCached<DOMTokenList>();
		public double volume { get => Get<double>(); set => Set(value); }
		public bool muted { get => Get<bool>(); set => Set(value); }
		public bool defaultMuted { get => Get<bool>(); set => Set(value); }

		// tracks
		//public AudioTrackList audioTracks => GetCached<AudioTrackList>();
		//public VideoTrackList videoTracks => GetCached<VideoTrackList>();
		public TextTrackList textTracks => GetCached<TextTrackList>();
		public TextTrack addTextTrack(TextTrackKind kind, string label = "", string language = "") =>
			Method<TextTrack>().Invoke(kind, label, language);

		// Non-standard APIs
		// The number of bytes consumed by the media decoder.
		//public ulong webkitAudioDecodedByteCount => Get<ulong>();
		//public ulong webkitVideoDecodedByteCount => Get<ulong>();
	}
}
