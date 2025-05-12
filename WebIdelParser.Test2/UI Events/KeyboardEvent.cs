using System;

namespace WebView2.DOM
{
	public enum KeyLocation : uint
	{
		STANDARD/* */= 0,
		LEFT/*     */= 1,
		RIGHT/*    */= 2,
		NUMPAD/*   */= 3,
	}

	public partial class KeyboardEvent
	{
		private ushort DOM_KEY_LOCATION_STANDARD/* */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DOM_KEY_LOCATION_LEFT/*     */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DOM_KEY_LOCATION_RIGHT/*    */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DOM_KEY_LOCATION_NUMPAD/*   */=> throw new NotImplementedException("Implemented as an enum instead");

		public KeyLocation location => Get<KeyLocation>();
	}

	public partial record KeyboardEventInit
	{
		public KeyLocation location
		{
			get => Get<KeyLocation>(defaultValue: KeyLocation.STANDARD);
			init => Set(value);
		}
	}
}
