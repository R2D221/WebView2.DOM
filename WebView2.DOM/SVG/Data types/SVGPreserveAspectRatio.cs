namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_preserve_aspect_ratio.idl

	public enum SVGPreserveAspectRatioAlign : ushort
	{
		UNKNOWN = 0,
		NONE = 1,
		XMINYMIN = 2,
		XMIDYMIN = 3,
		XMAXYMIN = 4,
		XMINYMID = 5,
		XMIDYMID = 6,
		XMAXYMID = 7,
		XMINYMAX = 8,
		XMIDYMAX = 9,
		XMAXYMAX = 10,
	}

	public enum SVGMeetOrSlice : ushort
	{
		UNKNOWN = 0,
		MEET = 1,
		SLICE = 2,
	}

	public sealed class SVGPreserveAspectRatio : JsObject
	{
		private SVGPreserveAspectRatio() { }

		public SVGPreserveAspectRatioAlign align
		{
			get => Get<SVGPreserveAspectRatioAlign>();
			set => Set(value);
		}

		public SVGMeetOrSlice meetOrSlice
		{
			get => Get<SVGMeetOrSlice>();
			set => Set(value);
		}
	}
}