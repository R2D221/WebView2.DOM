using NodaTime;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window_post_message_options.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/modules/storage/window_storage.idl

	public record WindowPostMessageOptions : PostMessageOptions
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public string targetOrigin
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		} = "/";
	}

	public sealed partial class Window : EventTarget
	{
		internal Window() { }

		//public Window window => Get<Window>();
		public Window self => Get<Window>();
		public Document document => Get<Document>();
		public string name { get => Get<string>(); set => Set(value); }
		public Location location => Get<Location>();
		//public CustomElementRegistry customElements => Get<CustomElementRegistry>();
		public History history => Get<History>();
		public BarProp locationbar => Get<BarProp>();
		public BarProp menubar => Get<BarProp>();
		public BarProp personalbar => Get<BarProp>();
		public BarProp scrollbars => Get<BarProp>();
		public BarProp statusbar => Get<BarProp>();
		public BarProp toolbar => Get<BarProp>();
		//public string status { get => Get<string>(); set => Set(value); }
		public void close()
			=> Method().Invoke();
		public bool closed => Get<bool>();
		public void stop()
			=> Method().Invoke();
		public void focus()
			=> Method().Invoke();
		public void blur()
			=> Method().Invoke();

		// other browsing contexts
		//public Window frames => Get<Window>();
		//public uint length => GetPrimitive<uint>();
		//public Window? top => GetNullableObject<Window>();
		public Window opener { get => Get<Window>(); set => Set(value); }
		public Window? parent => Get<Window?>();
		public Element? frameElement => Get<Element?>();
		public Window? open(string url = "", string target = "_blank", string features = "")
			=> Method<Window?>().Invoke(url, target, features);

		// indexed properties
		//public Window this[uint index]
		//	=> ReturnObject<Window>().Invoke(index);

		// named properties
		//public object this[string name]
		//	=> ReturnPrimitive<object>().Invoke(name);

		// the user agent
		public Navigator navigator => Get<Navigator>();
		//public ApplicationCache applicationCache => Get<ApplicationCache>();
		public bool originIsolated => Get<bool>();

		// user prompts
		public void alert()
			=> Method().Invoke();
		public void alert(string message)
			=> Method().Invoke(message);
		public bool confirm(string message = "")
			=> Method<bool>().Invoke(message);
		public string? prompt(string message = "", string defaultValue = "")
			=> Method<string?>().Invoke(message, defaultValue);
		public void print()
			=> Method().Invoke();

		[Obsolete("not tested")]
		public void postMessage(object? message)
			=> Method().Invoke(message);
		[Obsolete("not tested")]
		public void postMessage(object? message, string targetOrigin)
			=> Method().Invoke(message, targetOrigin);
		[Obsolete("not tested")]
		public void postMessage(object? message, string targetOrigin, IReadOnlyList<Transferable> transfer)
			=> Method().Invoke(message, targetOrigin, transfer);
		[Obsolete("not tested")]
		public void postMessage(object? message, WindowPostMessageOptions options)
			=> Method().Invoke(message, options);

		// WindowOrWorkerGlobalScope mixin
		public string origin => Get<string>();
		public void queueMicrotask(Action callback)
			=> Method().Invoke(callback);
		//public FrozenArray<string> originPolicyIds => _originPolicyIds ??= Get<FrozenArray<string>>();
		//private FrozenArray<string>? _originPolicyIds;

		// AnimationFrameProvider mixin
		private static ConditionalWeakTable<Action<Duration>, Action<double>> requestAnimationFrameCallbacks = new();
		public AnimationFrameID requestAnimationFrame(Action<Duration> callback)
			=> Method<AnimationFrameID>().Invoke
			(
				requestAnimationFrameCallbacks.GetValue(callback, static _callback =>
					(highResTime) => _callback(Duration.FromNanoseconds(Math.Round(highResTime * 1000) * 1000)))
			);

		public void cancelAnimationFrame(AnimationFrameID handle)
			=> Method().Invoke(handle);

		// HTML obsolete features
		//public void captureEvents()
		//	=> Method().Invoke();
		//public void releaseEvents()
		//	=> Method().Invoke();

		//public External external => _external ??= Get<External>();
		//private External? _external;

		// Cooperative Scheduling of Background Tasks
		public IdleCallbackID requestIdleCallback(Action<IdleDeadline> callback)
			=> Method<IdleCallbackID>().Invoke(callback);
		public IdleCallbackID requestIdleCallback(Action<IdleDeadline> callback, IdleRequestOptions options)
			=> Method<IdleCallbackID>().Invoke(callback, options);
		public void cancelIdleCallback(IdleCallbackID id)
			=> Method().Invoke(id);

		// CSS Object Model (CSSOM)
		public CSSStyleDeclaration getComputedStyle(Element elt, string? pseudoElt = null)
			=> Method<CSSStyleDeclaration>().Invoke(elt, pseudoElt);

		// CSSOM View Module
		public MediaQueryList matchMedia(string query)
			=> Method<MediaQueryList>().Invoke(query);
		public Screen screen => GetCached<Screen>();

		// browsing context
		public void moveTo(int x, int y)
			=> Method().Invoke(x, y);
		public void moveBy(int x, int y)
			=> Method().Invoke(x, y);
		public void resizeTo(int x, int y)
			=> Method().Invoke(x, y);
		public void resizeBy(int x, int y)
			=> Method().Invoke(x, y);

		// viewport
		public int innerWidth => Get<int>();
		public int innerHeight => Get<int>();

		// viewport scrolling
		public /*restricted*/double scrollX => Get</*restricted*/double>();
		public /*restricted*/double pageXOffset => Get</*restricted*/double>();
		public /*restricted*/double scrollY => Get</*restricted*/double>();
		public /*restricted*/double pageYOffset => Get</*restricted*/double>();
		public void scroll()
			=> Method().Invoke();
		public void scroll(ScrollToOptions options)
			=> Method().Invoke(options);
		public void scroll(double x, double y)
			=> Method().Invoke(x, y);
		public void scrollTo()
			=> Method().Invoke();
		public void scrollTo(ScrollToOptions options)
			=> Method().Invoke(options);
		public void scrollTo(double x, double y)
			=> Method().Invoke(x, y);
		public void scrollBy()
			=> Method().Invoke();
		public void scrollBy(ScrollToOptions options)
			=> Method().Invoke(options);
		public void scrollBy(double x, double y)
			=> Method().Invoke(x, y);

		// Visual Viewport API
		public VisualViewport visualViewport => GetCached<VisualViewport>();

		// client
		public int screenX => Get<int>();
		public int screenY => Get<int>();
		public int outerWidth => Get<int>();
		public int outerHeight => Get<int>();
		public /*restricted*/double devicePixelRatio => Get</*restricted*/double>();

		// Window Segments API
		//public FrozenArray<DOMRect> getWindowSegments()
		//	=> ReturnObject<FrozenArray<DOMRect>>().Invoke();

		// Selection API
		public Selection? getSelection()
			=> Method<Selection?>().Invoke();

		// Console API
		// readonly attribute Console console;

		// Compatibility
		// https://compat.spec.whatwg.org/#windoworientation-interface
		//public event EventHandler<UnknownEvent>? onorientationchange { add => AddEvent(value); remove => RemoveEvent(value); }
		//public int orientation => GetPrimitive<int>();

		// Accessibility Object Model
		//public Task<ComputedAccessibleNode> getComputedAccessibleNode(Element element)
		//	=> ReturnObjectTask<ComputedAccessibleNode>().Invoke(element);

		//public URLConstructor webkitURL { get => Get<URLConstructor>(); set => SetObject(value); }

		// https://dom.spec.whatwg.org/#interface-window-extensions
		//public any @event => GetPrimitive<any>();

		// Non-standard APIs
		public Navigator clientInformation => Get<Navigator>();
		public bool find(string @string = "", bool caseSensitive = false, bool backwards = false, bool wrap = false, bool wholeWord = false, bool searchInFrames = false, bool showDialog = false)
			=> Method<bool>().Invoke(@string, caseSensitive, backwards, wrap, wholeWord, searchInFrames, showDialog);
		public bool offscreenBuffering => Get<bool>();
		public int screenLeft => Get<int>();
		public int screenTop => Get<int>();
		public string defaultStatus { get => Get<string>(); set => Set(value); }
		public string defaultstatus { get => Get<string>(); set => Set(value); }
		public StyleMedia styleMedia => Get<StyleMedia>();
		//public int webkitRequestAnimationFrame(FrameRequestCallback callback)
		//	=> ReturnPrimitive<int>().Invoke(callback);
		//public void webkitCancelAnimationFrame(int id)
		//	=> Method().Invoke(id);
		//public MutationObserverConstructor WebKitMutationObserver { get => Get<MutationObserverConstructor>(); set => SetObject(value); }

		// Event handler attributes
		public event EventHandler<Event>? onsearch { add => AddEvent(value); remove => RemoveEvent(value); }

		// https://w3c.github.io/webappsec-secure-contexts/#monkey-patching-global-object
		public bool isSecureContext => Get<bool>();

		//public DOMMatrixConstructor WebKitCSSMatrix { get => Get<DOMMatrixConstructor>(); set => SetObject(value); }

		// TrustedTypes API: http://github.com/wicg/trusted-types
		//public TrustedTypePolicyFactory trustedTypes => Get<TrustedTypePolicyFactory>();

		public Storage sessionStorage => Get<Storage>();
		public Storage localStorage => Get<Storage>();
	}
}