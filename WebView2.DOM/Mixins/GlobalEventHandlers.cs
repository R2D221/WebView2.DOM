using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/global_event_handlers.idl
	// https://w3c.github.io/uievents/#event-types-list

	public interface GlobalEventHandlers
	{
		event EventHandler<Event/*	*/>? onabort/*	*/;
		event EventHandler<FocusEvent/*	*/>? onblur/*	*/;
		event EventHandler<Event/*	*/>? oncancel/*	*/;
		event EventHandler<Event/*	*/>? oncanplay/*	*/;
		event EventHandler<Event/*	*/>? oncanplaythrough/*	*/;
		event EventHandler<Event/*	*/>? onchange/*	*/;
		event EventHandler<PointerEvent/*	*/>? onclick/*	*/;
		event EventHandler<Event/*	*/>? onclose/*	*/;
		event EventHandler<PointerEvent/*	*/>? oncontextmenu/*	*/;
		event EventHandler<Event/*	*/>? oncuechange/*	*/;
		event EventHandler<MouseEvent/*	*/>? ondblclick/*	*/;
		event EventHandler<DragEvent/*	*/>? ondrag/*	*/;
		event EventHandler<DragEvent/*	*/>? ondragend/*	*/;
		event EventHandler<DragEvent/*	*/>? ondragenter/*	*/;
		//event EventHandler<DragEvent/*	*/>? ondragexit/*	*/;
		event EventHandler<DragEvent/*	*/>? ondragleave/*	*/;
		event EventHandler<DragEvent/*	*/>? ondragover/*	*/;
		event EventHandler<DragEvent/*	*/>? ondragstart/*	*/;
		event EventHandler<DragEvent/*	*/>? ondrop/*	*/;
		event EventHandler<Event/*	*/>? ondurationchange/*	*/;
		event EventHandler<Event/*	*/>? onemptied/*	*/;
		event EventHandler<Event/*	*/>? onended/*	*/;
		//event OnErrorEventHandler	onerror	;
		event EventHandler<FocusEvent/*	*/>? onfocus/*	*/;
		event EventHandler<FormDataEvent/*	*/>? onformdata/*	*/;
		event EventHandler<InputEvent/*	*/>? oninput/*	*/;
		event EventHandler<Event/*	*/>? oninvalid/*	*/;
		event EventHandler<KeyboardEvent/*	*/>? onkeydown/*	*/;
		event EventHandler<KeyboardEvent/*	*/>? onkeypress/*	*/;
		event EventHandler<KeyboardEvent/*	*/>? onkeyup/*	*/;
		event EventHandler<Event/*	*/>? onload/*	*/;
		event EventHandler<Event/*	*/>? onloadeddata/*	*/;
		event EventHandler<Event/*	*/>? onloadedmetadata/*	*/;
		event EventHandler<ProgressEvent/*	*/>? onloadstart/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmousedown/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmouseenter/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmouseleave/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmousemove/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmouseout/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmouseover/*	*/;
		event EventHandler<MouseEvent/*	*/>? onmouseup/*	*/;
		//event EventHandler</*	*/>? onmousewheel/*	*/;
		//event EventHandler</*	*/>? onoverscroll/*	*/;
		event EventHandler<Event/*	*/>? onpause/*	*/;
		event EventHandler<Event/*	*/>? onplay/*	*/;
		event EventHandler<Event/*	*/>? onplaying/*	*/;
		event EventHandler<ProgressEvent/*	*/>? onprogress/*	*/;
		event EventHandler<Event/*	*/>? onratechange/*	*/;
		event EventHandler<Event/*	*/>? onreset/*	*/;
		event EventHandler<Event/*	*/>? onresize/*	*/;
		event EventHandler<Event/*	*/>? onscroll/*	*/;
		//event EventHandler</*	*/>? onscrollend/*	*/;
		event EventHandler<Event/*	*/>? onseeked/*	*/;
		event EventHandler<Event/*	*/>? onseeking/*	*/;
		event EventHandler<Event/*	*/>? onselect/*	*/;
		//event EventHandler</*	*/>? onsort/*	*/;
		event EventHandler<Event/*	*/>? onstalled/*	*/;
		event EventHandler<SubmitEvent/*	*/>? onsubmit/*	*/;
		event EventHandler<Event/*	*/>? onsuspend/*	*/;
		event EventHandler<Event/*	*/>? ontimeupdate/*	*/;
		event EventHandler<Event/*	*/>? ontoggle/*	*/;
		event EventHandler<Event/*	*/>? onvolumechange/*	*/;
		event EventHandler<Event/*	*/>? onwaiting/*	*/;
		event EventHandler<WheelEvent/*	*/>? onwheel/*	*/;

		// auxclick
		event EventHandler<PointerEvent/*	*/>? onauxclick/*	*/;

		// Pointer Events
		event EventHandler<PointerEvent/*	*/>? ongotpointercapture/*	*/;
		event EventHandler<PointerEvent/*	*/>? onlostpointercapture/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerdown/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointermove/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerrawupdate/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerup/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointercancel/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerover/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerout/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerenter/*	*/;
		event EventHandler<PointerEvent/*	*/>? onpointerleave/*	*/;

		// Touch Events
		event EventHandler<TouchEvent/*	*/>? ontouchcancel/*	*/;
		event EventHandler<TouchEvent/*	*/>? ontouchend/*	*/;
		event EventHandler<TouchEvent/*	*/>? ontouchmove/*	*/;
		event EventHandler<TouchEvent/*	*/>? ontouchstart/*	*/;

		// Selection API
		event EventHandler<Event/*	*/>? onselectstart/*	*/;
		event EventHandler<Event/*	*/>? onselectionchange/*	*/;

		// CSS Animations
		event EventHandler<AnimationEvent/*	*/>? onanimationend/*	*/;
		event EventHandler<AnimationEvent/*	*/>? onanimationiteration/*	*/;
		event EventHandler<AnimationEvent/*	*/>? onanimationstart/*	*/;

		// CSS Transitions
		event EventHandler<TransitionEvent/*	*/>? ontransitionrun/*	*/;
		event EventHandler<TransitionEvent/*	*/>? ontransitionstart/*	*/;
		event EventHandler<TransitionEvent/*	*/>? ontransitionend/*	*/;
		event EventHandler<TransitionEvent/*	*/>? ontransitioncancel/*	*/;
	}
}