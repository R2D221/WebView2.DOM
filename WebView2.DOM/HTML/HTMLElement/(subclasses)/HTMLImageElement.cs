using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public sealed class HTMLImageElement : HTMLElement
	{
		private HTMLImageElement() { }

		public string alt { get => Get<string>(); set => Set(value); }
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public IReadOnlyList<SrcSetItem> srcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string sizes { get => Get<string>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string useMap { get => Get<string>(); set => Set(value); }
		public bool isMap { get => Get<bool>(); set => Set(value); }
		public uint width { get => Get<uint>(); set => Set(value); }
		public uint height { get => Get<uint>(); set => Set(value); }
		public uint naturalWidth => Get<uint>();
		public uint naturalHeight => Get<uint>();
		public bool complete => Get<bool>();
		public Uri currentSrc => Get<Uri>();
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		public ImageDecodingHint decoding { get => Get<ImageDecodingHint>(); set => Set(value); }
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;
		public LazyLoading loading { get => Get<LazyLoading>(); set => Set(value); }

		// CSSOM View Module
		public int x => Get<int>();
		public int y => Get<int>();

		public VoidPromise decode() => Method<VoidPromise>().Invoke();
	}
}
