using System;

namespace WebView2.DOM
{
	public enum Button : short
	{
		PRIMARY/*   */= 0, //: Main button pressed, usually the left button or the un-initialized state
		AUXILIARY/* */= 1, //: Auxiliary button pressed, usually the wheel button or the middle button (if present)
		SECONDARY/* */= 2, //: Secondary button pressed, usually the right button
		FOURTH/*    */= 3, //: Fourth button, typically the Browser Back button
		FIFTH/*     */= 4, //: Fifth button, typically the Browser Forward button
	}

	[Flags]
	public enum Buttons : ushort
	{
		NONE/*      */= 0b00000, //: No button or un-initialized
		PRIMARY/*   */= 0b00001, //: Primary button (usually the left button)
		SECONDARY/* */= 0b00010, //: Secondary button (usually the right button)
		AUXILIARY/* */= 0b00100, //: Auxiliary button (usually the mouse wheel button or middle button)
		FOURTH/*    */= 0b01000, //: 4th button (typically the "Browser Back" button)
		FIFTH/*     */= 0b10000, //: 5th button (typically the "Browser Forward" button)
	}

	public partial class MouseEvent
	{
		public Button button => Get<Button>();
		public Buttons buttons => Get<Buttons>();
	}

	public partial record MouseEventInit
	{
		public Button button
		{
			get => Get<Button>(defaultValue: Button.PRIMARY);
			init => Set(value);
		}

		public Buttons buttons
		{
			get => Get<Buttons>(defaultValue: Buttons.NONE);
			init => Set(value);
		}
	}
}
