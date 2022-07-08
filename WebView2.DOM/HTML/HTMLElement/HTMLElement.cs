using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_element.idl

	public enum EnterKeyHint
	{
		_, enter, done, go, next, previous, search, send
	}

	public enum InputMode
	{
		_, none, text, tel, url, email, numeric, @decimal, search
	}

	public partial class HTMLElement : Element
	{
		private protected HTMLElement() { }

		// metadata attributes
		public string title { get => Get<string>(); set => Set(value); }
		public string lang { get => Get<string>(); set => Set(value); }
		public bool translate { get => Get<bool>(); set => Set(value); }
		public string dir { get => Get<string>(); set => Set(value); }

		// user interaction
		public bool hidden { get => Get<bool>(); set => Set(value); }
		public void click() => Method().Invoke();
		public bool inert { get => Get<bool>(); set => Set(value); }
		public string accessKey { get => Get<string>(); set => Set(value); }
		public bool draggable { get => Get<bool>(); set => Set(value); }
		public bool spellcheck { get => Get<bool>(); set => Set(value); }
		public string autocapitalize { get => Get<string>(); set => Set(value); }

		//public ElementInternals attachInternals() => Method<ElementInternals>().Invoke();

		// HTMLElement includes ElementContentEditable
		public string contentEditable { get => Get<string>(); set => Set(value); }
		public EnterKeyHint enterKeyHint { get => Get<EnterKeyHint>(); set => Set(value); }
		public bool isContentEditable => Get<bool>();
		public InputMode inputMode { get => Get<InputMode>(); set => Set(value); }

		// Explainers
		public string virtualKeyboardPolicy { get => Get<string>(); set => Set(value); }

		// CSSOM View Module
		public Element? offsetParent => Get<Element?>();
		public int offsetTop => Get<int>();
		public int offsetLeft => Get<int>();
		public int offsetWidth => Get<int>();
		public int offsetHeight => Get<int>();

		// CSS Object Model (CSSOM)
		public CSSStyleDeclaration style => _style ??= Get<CSSStyleDeclaration>();
		private CSSStyleDeclaration? _style;
		public string innerText { get => Get<string>(); set => Set(value); }
		public string outerText { get => Get<string>(); set => Set(value); }

		public interface OneOf<T0, T1>
			where T0 : HTMLElement
			where T1 : HTMLElement
		{
		}

		public interface OneOf<T0, T1, T2, T3, T4, T5, T6>
			where T0 : HTMLElement
			where T1 : HTMLElement
			where T2 : HTMLElement
			where T3 : HTMLElement
			where T4 : HTMLElement
			where T5 : HTMLElement
			where T6 : HTMLElement
		{
		}

		public interface OneOf<T0, T1, T2, T3, T4, T5, T6, T7>
			where T0 : HTMLElement
			where T1 : HTMLElement
			where T2 : HTMLElement
			where T3 : HTMLElement
			where T4 : HTMLElement
			where T5 : HTMLElement
			where T6 : HTMLElement
			where T7 : HTMLElement
		{
		}
	}
}

public static class HTMLElementOneOfExtensions
{
	public static void Switch<T0, T1>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1> @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
	{
		switch (@this)
		{
		case T0 value0: f0(value0); break;
		case T1 value1: f1(value1); break;
		default: throw new InvalidOperationException();
		}
	}

	public static TResult Match<T0, T1, TResult>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1> @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
	{
		return @this switch
		{
			T0 value0 => f0(value0),
			T1 value1 => f1(value1),
			_ => throw new InvalidOperationException(),
		};
	}

	public static void Switch<T0, T1, T2, T3, T4, T5, T6>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1, T2, T3, T4, T5, T6> @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		,/**/Action<T2> f2
		,/**/Action<T3> f3
		,/**/Action<T4> f4
		,/**/Action<T5> f5
		,/**/Action<T6> f6
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
		where T2 : WebView2.DOM.HTMLElement
		where T3 : WebView2.DOM.HTMLElement
		where T4 : WebView2.DOM.HTMLElement
		where T5 : WebView2.DOM.HTMLElement
		where T6 : WebView2.DOM.HTMLElement
	{
		switch (@this)
		{
		case T0 value0: f0(value0); break;
		case T1 value1: f1(value1); break;
		case T2 value2: f2(value2); break;
		case T3 value3: f3(value3); break;
		case T4 value4: f4(value4); break;
		case T5 value5: f5(value5); break;
		case T6 value6: f6(value6); break;
		default: throw new InvalidOperationException();
		}
	}

	public static TResult Match<T0, T1, T2, T3, T4, T5, T6, TResult>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1, T2, T3, T4, T5, T6> @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		,/**/Func<T2, TResult> f2
		,/**/Func<T3, TResult> f3
		,/**/Func<T4, TResult> f4
		,/**/Func<T5, TResult> f5
		,/**/Func<T6, TResult> f6
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
		where T2 : WebView2.DOM.HTMLElement
		where T3 : WebView2.DOM.HTMLElement
		where T4 : WebView2.DOM.HTMLElement
		where T5 : WebView2.DOM.HTMLElement
		where T6 : WebView2.DOM.HTMLElement
	{
		return @this switch
		{
			T0 value0 => f0(value0),
			T1 value1 => f1(value1),
			T2 value2 => f2(value2),
			T3 value3 => f3(value3),
			T4 value4 => f4(value4),
			T5 value5 => f5(value5),
			T6 value6 => f6(value6),
			_ => throw new InvalidOperationException(),
		};
	}

	public static void Switch<T0, T1, T2, T3, T4, T5, T6, T7>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1, T2, T3, T4, T5, T6, T7> @this
		,/**/Action<T0> f0
		,/**/Action<T1> f1
		,/**/Action<T2> f2
		,/**/Action<T3> f3
		,/**/Action<T4> f4
		,/**/Action<T5> f5
		,/**/Action<T6> f6
		,/**/Action<T7> f7
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
		where T2 : WebView2.DOM.HTMLElement
		where T3 : WebView2.DOM.HTMLElement
		where T4 : WebView2.DOM.HTMLElement
		where T5 : WebView2.DOM.HTMLElement
		where T6 : WebView2.DOM.HTMLElement
		where T7 : WebView2.DOM.HTMLElement
	{
		switch (@this)
		{
		case T0 value0: f0(value0); break;
		case T1 value1: f1(value1); break;
		case T2 value2: f2(value2); break;
		case T3 value3: f3(value3); break;
		case T4 value4: f4(value4); break;
		case T5 value5: f5(value5); break;
		case T6 value6: f6(value6); break;
		case T7 value7: f7(value7); break;
		default: throw new InvalidOperationException();
		}
	}

	public static TResult Match<T0, T1, T2, T3, T4, T5, T6, T7, TResult>
		(this WebView2.DOM.HTMLElement.OneOf<T0, T1, T2, T3, T4, T5, T6, T7> @this
		,/**/Func<T0, TResult> f0
		,/**/Func<T1, TResult> f1
		,/**/Func<T2, TResult> f2
		,/**/Func<T3, TResult> f3
		,/**/Func<T4, TResult> f4
		,/**/Func<T5, TResult> f5
		,/**/Func<T6, TResult> f6
		,/**/Func<T7, TResult> f7
		)
		where T0 : WebView2.DOM.HTMLElement
		where T1 : WebView2.DOM.HTMLElement
		where T2 : WebView2.DOM.HTMLElement
		where T3 : WebView2.DOM.HTMLElement
		where T4 : WebView2.DOM.HTMLElement
		where T5 : WebView2.DOM.HTMLElement
		where T6 : WebView2.DOM.HTMLElement
		where T7 : WebView2.DOM.HTMLElement
	{
		return @this switch
		{
			T0 value0 => f0(value0),
			T1 value1 => f1(value1),
			T2 value2 => f2(value2),
			T3 value3 => f3(value3),
			T4 value4 => f4(value4),
			T5 value5 => f5(value5),
			T6 value6 => f6(value6),
			T7 value7 => f7(value7),
			_ => throw new InvalidOperationException(),
		};
	}
}