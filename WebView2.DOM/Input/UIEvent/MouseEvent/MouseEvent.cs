using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/mouse_event.idl

	public enum Button : short
	{
		PRIMARY/*	*/= 0, //: Main button pressed, usually the left button or the un-initialized state
		AUXILIARY/*	*/= 1, //: Auxiliary button pressed, usually the wheel button or the middle button (if present)
		SECONDARY/*	*/= 2, //: Secondary button pressed, usually the right button
		FOURTH/*	*/= 3, //: Fourth button, typically the Browser Back button
		FIFTH/*	*/= 4, //: Fifth button, typically the Browser Forward button
	}

	[Flags]
	public enum Buttons : ushort
	{
		NONE/*	*/= 0b00000,//00, //: No button or un-initialized
		PRIMARY/*	*/= 0b00001,//01, //: Primary button (usually the left button)
		SECONDARY/*	*/= 0b00010,//02, //: Secondary button (usually the right button)
		AUXILIARY/*	*/= 0b00100,//04, //: Auxiliary button (usually the mouse wheel button or middle button)
		FOURTH/*	*/= 0b01000,//08, //: 4th button (typically the "Browser Back" button)
		FIFTH/*	*/= 0b10000,//16, //: 5th button (typically the "Browser Forward" button)
	}

	public class MouseEvent : UIEvent
	{
		protected internal MouseEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public double screenX => Get<double>();
		public double screenY => Get<double>();
		public double clientX => Get<double>();
		public double clientY => Get<double>();
		public bool ctrlKey => Get<bool>();
		public bool shiftKey => Get<bool>();
		public bool altKey => Get<bool>();
		public bool metaKey => Get<bool>();
		public Button button => Get<Button>();
		public Buttons buttons => Get<Buttons>();
		public EventTarget? relatedTarget => Get<EventTarget?>();
		public bool getModifierState(string keyArg) => Method<bool>().Invoke(keyArg);

		public double pageX => Get<double>();
		public double pageY => Get<double>();
		public double x => Get<double>();
		public double y => Get<double>();
		public double offsetX => Get<double>();
		public double offsetY => Get<double>();

		// Pointer Lock
		public int movementX => Get<int>();
		public int movementY => Get<int>();

		// Canvas Hit Regions
		//public string? region => Get<string?>();

		// Non-standard
		public Node fromElement => Get<Node>();
		public Node toElement => Get<Node>();
		public int layerX => Get<int>();
		public int layerY => Get<int>();
	}
}
