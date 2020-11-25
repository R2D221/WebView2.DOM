using Microsoft.Web.WebView2.Core;
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
		protected internal HTMLElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

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
		public string innerText { get => Get<string>(); /*set => Set(value);*/ }
		public string outerText { get => Get<string>(); /*set => Set(value);*/ }

		public sealed class OneOf<T0, T1> : HTMLElement
			where T0 : HTMLElement
			where T1 : HTMLElement
		{
			private readonly HTMLElement value;

			private OneOf(HTMLElement value)
				: base(value.coreWebView, value.referenceId)
			{
				this.value = value;
				events = value.events;
			}

			public static implicit operator OneOf<T0, T1>(T0 value) => new OneOf<T0, T1>(value);
			public static implicit operator OneOf<T0, T1>(T1 value) => new OneOf<T0, T1>(value);

			public void Switch
				(/**/Action<T0> f0
				,/**/Action<T1> f1
				)
			{
				switch (value)
				{
				case T0 value0: f0(value0); break;
				case T1 value1: f1(value1); break;
				default: throw new InvalidOperationException();
				}
			}

			public TResult Match<TResult>
				(/**/Func<T0, TResult> f0
				,/**/Func<T1, TResult> f1
				)
			{
				return value switch
				{
					T0 value0 => f0(value0),
					T1 value1 => f1(value1),
					_ => throw new InvalidOperationException(),
				};
			}
		}
	}
}
