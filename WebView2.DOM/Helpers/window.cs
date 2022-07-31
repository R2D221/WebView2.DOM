using NodaTime;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebView2.DOM
{
	public static class window
	{
		//private static AsyncLocal<Window?> _window = new AsyncLocal<Window?>();

		//internal static Window Instance => _window.Value ?? throw new InvalidOperationException("The calling thread cannot access this object because a different thread owns it.");

		//internal static void SetInstance(Window? value) => _window.Value = value;

		//internal static bool HasValue() => _window.Value != null;

		internal static Window Instance => BrowsingContext.Current.Window;

		#region Window
		public static event EventHandler<Event>? onsearch { add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static Navigator clientInformation => Instance.Get<Navigator>();
		public static bool closed => Instance.Get<bool>();
		public static string defaultstatus { get => Instance.Get<string>(); set => Instance.Set(value); }
		public static string defaultStatus { get => Instance.Get<string>(); set => Instance.Set(value); }
		public static /*restricted*/double devicePixelRatio => Instance.Get</*restricted*/double>();
		public static Document document => Instance.Get<Document>();
		public static Element? frameElement => Instance.Get<Element?>();
		public static History history => Instance.Get<History>();
		public static int innerHeight => Instance.Get<int>();
		public static int innerWidth => Instance.Get<int>();
		public static bool isSecureContext => Instance.Get<bool>();
		public static Storage localStorage => Instance.Get<Storage>();
		public static Location location => Instance.Get<Location>();
		public static BarProp locationbar => Instance.Get<BarProp>();
		public static BarProp menubar => Instance.Get<BarProp>();
		public static string name { get => Instance.Get<string>(); set => Instance.Set(value); }
		public static Navigator navigator => Instance.Get<Navigator>();
		public static bool offscreenBuffering => Instance.Get<bool>();
		public static Window opener { get => Instance.Get<Window>(); set => Instance.Set(value); }
		public static string origin => Instance.Get<string>();
		public static bool originIsolated => Instance.Get<bool>();
		public static int outerHeight => Instance.Get<int>();
		public static int outerWidth => Instance.Get<int>();
		public static /*restricted*/double pageXOffset => Instance.Get</*restricted*/double>();
		public static /*restricted*/double pageYOffset => Instance.Get</*restricted*/double>();
		public static Window? parent => Instance.Get<Window?>();
		public static BarProp personalbar => Instance.Get<BarProp>();
		public static Screen screen => Instance.GetCached<Screen>();
		public static int screenLeft => Instance.Get<int>();
		public static int screenTop => Instance.Get<int>();
		public static int screenX => Instance.Get<int>();
		public static int screenY => Instance.Get<int>();
		public static BarProp scrollbars => Instance.Get<BarProp>();
		public static /*restricted*/double scrollX => Instance.Get</*restricted*/double>();
		public static /*restricted*/double scrollY => Instance.Get</*restricted*/double>();
		public static Window self => Instance.Get<Window>();
		public static Storage sessionStorage => Instance.Get<Storage>();
		//public static string status { get => Instance.Get<string>(); set => Instance.Set(value); }
		public static BarProp statusbar => Instance.Get<BarProp>();
		public static StyleMedia styleMedia => Instance.Get<StyleMedia>();
		public static BarProp toolbar => Instance.Get<BarProp>();
		public static VisualViewport visualViewport => Instance.GetCached<VisualViewport>();
		public static void alert()
			=> Instance.Method().Invoke();
		public static void alert(string message)
			=> Instance.Method().Invoke(message);
		public static void blur()
			=> Instance.Method().Invoke();
		public static void cancelAnimationFrame(AnimationFrameID handle)
			=> Instance.Method().Invoke(handle);
		public static void cancelIdleCallback(IdleCallbackID id)
			=> Instance.Method().Invoke(id);
		public static void close()
			=> Instance.Method().Invoke();
		public static bool confirm(string message = "")
			=> Instance.Method<bool>().Invoke(message);
		public static bool find(string @string = "", bool caseSensitive = false, bool backwards = false, bool wrap = false, bool wholeWord = false, bool searchInFrames = false, bool showDialog = false)
			=> Instance.Method<bool>().Invoke(@string, caseSensitive, backwards, wrap, wholeWord, searchInFrames, showDialog);
		public static void focus()
			=> Instance.Method().Invoke();
		public static CSSStyleDeclaration getComputedStyle(Element elt, string? pseudoElt = null)
			=> Instance.Method<CSSStyleDeclaration>().Invoke(elt, pseudoElt);
		public static Selection? getSelection()
			=> Instance.Method<Selection?>().Invoke();
		public static MediaQueryList matchMedia(string query)
			=> Instance.Method<MediaQueryList>().Invoke(query);
		public static void moveBy(int x, int y)
			=> Instance.Method().Invoke(x, y);
		public static void moveTo(int x, int y)
			=> Instance.Method().Invoke(x, y);
		public static Window? open(string url = "", string target = "_blank", string features = "")
			=> Instance.Method<Window?>().Invoke(url, target, features);
		[Obsolete("not tested")]
		public static void postMessage(object? message)
			=> Instance.Method().Invoke(message);
		[Obsolete("not tested")]
		public static void postMessage(object? message, string targetOrigin)
			=> Instance.Method().Invoke(message, targetOrigin);
		[Obsolete("not tested")]
		public static void postMessage(object? message, string targetOrigin, IReadOnlyList<Transferable> transfer)
			=> Instance.Method().Invoke(message, targetOrigin, transfer);
		[Obsolete("not tested")]
		public static void postMessage(object? message, WindowPostMessageOptions options)
			=> Instance.Method().Invoke(message, options);
		public static void print()
			=> Instance.Method().Invoke();
		public static string? prompt(string message = "", string defaultValue = "")
			=> Instance.Method<string?>().Invoke(message, defaultValue);
		public static void queueMicrotask(Action callback)
			=> Instance.Method().Invoke(callback);
		public static AnimationFrameID requestAnimationFrame(Action<Duration> callback)
			=> Instance.requestAnimationFrame(callback);
		public static IdleCallbackID requestIdleCallback(Action<IdleDeadline> callback)
			=> Instance.Method<IdleCallbackID>().Invoke(callback);
		public static IdleCallbackID requestIdleCallback(Action<IdleDeadline> callback, IdleRequestOptions options)
			=> Instance.Method<IdleCallbackID>().Invoke(callback, options);
		public static void resizeBy(int x, int y)
			=> Instance.Method().Invoke(x, y);
		public static void resizeTo(int x, int y)
			=> Instance.Method().Invoke(x, y);
		public static void scroll()
			=> Instance.Method().Invoke();
		public static void scroll(ScrollToOptions options)
			=> Instance.Method().Invoke(options);
		public static void scroll(double x, double y)
			=> Instance.Method().Invoke(x, y);
		public static void scrollBy()
			=> Instance.Method().Invoke();
		public static void scrollBy(ScrollToOptions options)
			=> Instance.Method().Invoke(options);
		public static void scrollBy(double x, double y)
			=> Instance.Method().Invoke(x, y);
		public static void scrollTo()
			=> Instance.Method().Invoke();
		public static void scrollTo(ScrollToOptions options)
			=> Instance.Method().Invoke(options);
		public static void scrollTo(double x, double y)
			=> Instance.Method().Invoke(x, y);
		public static void stop()
			=> Instance.Method().Invoke();
		#endregion

		#region GlobalEventHandlers
		public static event EventHandler<Event/*	*/>? onabort/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<AnimationEvent/*	*/>? onanimationend/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<AnimationEvent/*	*/>? onanimationiteration/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<AnimationEvent/*	*/>? onanimationstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onauxclick/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<FocusEvent/*	*/>? onblur/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? oncancel/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? oncanplay/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? oncanplaythrough/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onchange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onclick/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onclose/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? oncontextmenu/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? oncuechange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? ondblclick/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondrag/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondragend/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondragenter/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondragleave/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondragover/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondragstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<DragEvent/*	*/>? ondrop/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? ondurationchange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onemptied/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onended/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<FocusEvent/*	*/>? onfocus/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<FormDataEvent/*	*/>? onformdata/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? ongotpointercapture/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<InputEvent/*	*/>? oninput/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? oninvalid/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<KeyboardEvent/*	*/>? onkeydown/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<KeyboardEvent/*	*/>? onkeypress/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<KeyboardEvent/*	*/>? onkeyup/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onload/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onloadeddata/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onloadedmetadata/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<ProgressEvent/*	*/>? onloadstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onlostpointercapture/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmousedown/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmouseenter/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmouseleave/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmousemove/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmouseout/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmouseover/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<MouseEvent/*	*/>? onmouseup/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onpause/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onplay/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onplaying/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointercancel/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerdown/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerenter/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerleave/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointermove/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerout/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerover/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerrawupdate/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PointerEvent/*	*/>? onpointerup/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<ProgressEvent/*	*/>? onprogress/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onratechange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onreset/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onresize/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onscroll/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onseeked/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onseeking/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onselect/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onselectionchange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onselectstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onstalled/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<SubmitEvent/*	*/>? onsubmit/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onsuspend/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? ontimeupdate/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? ontoggle/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TouchEvent/*	*/>? ontouchcancel/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TouchEvent/*	*/>? ontouchend/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TouchEvent/*	*/>? ontouchmove/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TouchEvent/*	*/>? ontouchstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TransitionEvent/*	*/>? ontransitioncancel/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TransitionEvent/*	*/>? ontransitionend/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TransitionEvent/*	*/>? ontransitionrun/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<TransitionEvent/*	*/>? ontransitionstart/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onvolumechange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/>? onwaiting/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<WheelEvent/*	*/>? onwheel/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		#endregion

		#region WindowEventHandlers
		public static event EventHandler<Event/*	*/> onafterprint/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/> onbeforeprint/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<HashChangeEvent/*	*/> onhashchange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/> onlanguagechange/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		[Obsolete("not tested")]
		public static event EventHandler<MessageEvent/*	*/> onmessage/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		[Obsolete("not tested")]
		public static event EventHandler<MessageEvent/*	*/> onmessageerror/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/> onoffline/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/> ononline/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PageTransitionEvent/*	*/> onpagehide/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PageTransitionEvent/*	*/> onpageshow/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PopStateEvent/*	*/> onpopstate/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PromiseRejectionEvent/*	*/> onrejectionhandled/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<StorageEvent/*	*/> onstorage/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<PromiseRejectionEvent/*	*/> onunhandledrejection/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		public static event EventHandler<Event/*	*/> onunload/*	*/{ add => Instance.AddEvent(value); remove => Instance.RemoveEvent(value); }
		#endregion

		#region WindowOrWorkerGlobalScope
		public static TimeoutID setTimeout(Action handler, Duration timeout) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds);
		public static TimeoutID setTimeout<T1>(Action<T1> handler, Duration timeout, T1 arg1) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1);
		public static TimeoutID setTimeout<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2);
		public static TimeoutID setTimeout<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3);
		public static TimeoutID setTimeout<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		public static TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
			Instance.Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

		public static void clearTimeout(TimeoutID id) =>
			Instance.Method().Invoke(id);

		public static IntervalID setInterval(Action handler, Duration timeout) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds);
		public static IntervalID setInterval<T1>(Action<T1> handler, Duration timeout, T1 arg1) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1);
		public static IntervalID setInterval<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2);
		public static IntervalID setInterval<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3);
		public static IntervalID setInterval<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4);
		public static IntervalID setInterval<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		public static IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
			Instance.Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

		public static void clearInterval(IntervalID id) =>
			Instance.Method().Invoke(id);
		#endregion
	}
}
