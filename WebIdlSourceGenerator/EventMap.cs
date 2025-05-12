using System.Diagnostics;
using WebIdlParser;

namespace WebIdlSourceGenerator
{
	internal static class EventMap
	{
		public static string GetEventTypeName(string type, string name)
		{
			//try
			//{
				return map[type][name];
			//}
			//catch (Exception ex)
			//{
			//	_ = ex;
			//	_ = Debugger.Launch();
			//	throw;
			//}
		}

		private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> map =
			new Dictionary<string, IReadOnlyDictionary<string, string>>
			{
				["GlobalEventHandlers"] = new Dictionary<string, string>
				{
					//attribute OnErrorEventHandler onerror;

					#region HTML 4.8.11 Media elements
					["oncanplay"] = "Event",
					["oncanplaythrough"] = "Event",
					["oncuechange"] = "Event",
					["ondurationchange"] = "Event",
					["onemptied"] = "Event",
					["onended"] = "Event",
					["onloadeddata"] = "Event",
					["onloadedmetadata"] = "Event",
					["onloadstart"] = "Event",
					["onpause"] = "Event",
					["onplay"] = "Event",
					["onplaying"] = "Event",
					["onprogress"] = "Event",
					["onratechange"] = "Event",
					["onseeked"] = "Event",
					["onseeking"] = "Event",
					["onstalled"] = "Event",
					["onsuspend"] = "Event",
					["ontimeupdate"] = "Event",
					["onvolumechange"] = "Event",
					["onwaiting"] = "Event",
					#endregion

					#region HTML 6.10 Drag and drop
					["ondrag"] = "DragEvent",
					["ondragend"] = "DragEvent",
					["ondragenter"] = "DragEvent",
					["ondragleave"] = "DragEvent",
					["ondragover"] = "DragEvent",
					["ondragstart"] = "DragEvent",
					["ondrop"] = "DragEvent",
					#endregion

					#region HTML Events
					["onbeforematch"] = "Event",
					["oncancel"] = "Event",
					["onchange"] = "Event",
					["onclose"] = "Event",
					["oncontextlost"] = "Event",
					["oncontextrestored"] = "Event",
					["onformdata"] = "FormDataEvent",
					["oninvalid"] = "Event",
					["onreset"] = "Event",
					["onsubmit"] = "SubmitEvent",
					["ontoggle"] = "Event",
					#endregion

					#region UI Events
					["onabort"] = "Event",
					["onauxclick"] = "PointerEvent",
					["onbeforeinput"] = "InputEvent",
					["onblur"] = "FocusEvent",
					["onclick"] = "PointerEvent",
					//compositionstart
					//compositionupdate
					//compositionend
					["oncontextmenu"] = "PointerEvent",
					["ondblclick"] = "MouseEvent",
					["onfocus"] = "FocusEvent",
					// focusin
					// focusout
					["oninput"] = "InputEvent",
					["onkeydown"] = "KeyboardEvent",
					["onkeypress"] = "KeyboardEvent",
					["onkeyup"] = "KeyboardEvent",
					["onload"] = "Event",
					["onmousedown"] = "MouseEvent",
					["onmouseenter"] = "MouseEvent",
					["onmouseleave"] = "MouseEvent",
					["onmousemove"] = "MouseEvent",
					["onmouseout"] = "MouseEvent",
					["onmouseover"] = "MouseEvent",
					["onmouseup"] = "MouseEvent",
					["onselect"] = "Event",
					["onwheel"] = "WheelEvent",
					#endregion

					#region Clipboard API and events
					["oncopy"] = "ClipboardEvent",
					["oncut"] = "ClipboardEvent",
					["onpaste"] = "ClipboardEvent",
					#endregion

					#region CSSOM View Module
					["onresize"] = "Event",
					["onscroll"] = "Event",
					["onscrollend"] = "Event",
					#endregion

					#region Content Security Policy Level 3
					["onsecuritypolicyviolation"] = "SecurityPolicyViolationEvent",
					#endregion

					#region DOM Standard / ShadowRoot
					["onslotchange"] = "Event",
					#endregion

					#region undocumented
					["onwebkitanimationend"] = "Event",
					["onwebkitanimationiteration"] = "Event",
					["onwebkitanimationstart"] = "Event",
					["onwebkittransitionend"] = "Event",
					#endregion

					#region Pointer Events
					["onpointerover"] = "PointerEvent",
					["onpointerenter"] = "PointerEvent",
					["onpointerdown"] = "PointerEvent",
					["onpointermove"] = "PointerEvent",
					["onpointerrawupdate"] = "PointerEvent",
					["onpointerup"] = "PointerEvent",
					["onpointercancel"] = "PointerEvent",
					["onpointerout"] = "PointerEvent",
					["onpointerleave"] = "PointerEvent",
					["ongotpointercapture"] = "PointerEvent",
					["onlostpointercapture"] = "PointerEvent",
					#endregion
				},
				["WindowEventHandlers"] = new Dictionary<string, string>
				{
					#region HTML Events
					["onafterprint"] = "Event",
					["onbeforeprint"] = "Event",
					["onhashchange"] = "HashChangeEvent",
					["onlanguagechange"] = "Event",
					["onmessage"] = "MessageEvent",
					["onmessageerror"] = "MessageEvent",
					["onoffline"] = "Event",
					["ononline"] = "Event",
					["onpagehide"] = "PageTransitionEvent",
					["onpageshow"] = "PageTransitionEvent",
					["onpopstate"] = "PopStateEvent",
					["onrejectionhandled"] = "PromiseRejectionEvent",
					["onstorage"] = "StorageEvent",
					["onunhandledrejection"] = "PromiseRejectionEvent",
					["onunload"] = "Event",
					#endregion

					//attribute OnBeforeUnloadEventHandler onbeforeunload;
				},
				["MessagePort"] = new Dictionary<string, string>
				{
					["onmessage"] = "MessageEvent",
					["onmessageerror"] = "MessageEvent",
				},
				["FileReader"] = new Dictionary<string, string>
				{
					["onloadstart"] = "ProgressEvent",
					["onprogress"] = "ProgressEvent",
					["onload"] = "ProgressEvent",
					["onabort"] = "ProgressEvent",
					["onerror"] = "ProgressEvent",
					["onloadend"] = "ProgressEvent",
				},
				["AbortSignal"] = new Dictionary<string, string>
				{
					["onabort"] = "Event",
				},
			};
	}
}
