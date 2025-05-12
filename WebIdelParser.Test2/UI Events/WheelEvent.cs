using System;

namespace WebView2.DOM
{
	public enum DeltaMode : uint
	{
		PIXEL = 0,
		LINE = 1,
		PAGE = 2,
	}

	public partial class WheelEvent
	{
		private ushort DOM_DELTA_PIXEL/* */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DOM_DELTA_LINE/*  */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DOM_DELTA_PAGE/*  */=> throw new NotImplementedException("Implemented as an enum instead");

		public DeltaMode deltaMode => Get<DeltaMode>();
	}

	public partial record WheelEventInit
	{
		public DeltaMode deltaMode
		{
			get => Get<DeltaMode>(defaultValue: DeltaMode.PIXEL);
			init => Set(value);
		}
	}
}
