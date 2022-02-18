using EnumsNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Markup;

namespace WebView2.Markup
{
	internal static class Events
	{
		private static ConditionalWeakTable<object, EventHandler<DOM.Event>> nongenericEvents = new();

		public static EventHandler<DOM.Event> GetNongenericEvent<TEvent>(EventHandler<TEvent> @event)
			where TEvent : DOM.Event
		{
			return nongenericEvents.GetValue(@event, _event =>
			{
				return new EventHandler<DOM.Event>((sender, nongenericEvent) =>
				{
					((EventHandler<TEvent>)_event).Invoke(sender, (TEvent)nongenericEvent);
				});
			});
		}
	}

	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[XmlLangProperty(nameof(lang))]
	public abstract class HTMLElement : Element
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public override string namespaceURI => "http://www.w3.org/1999/xhtml";

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual string DebuggerDisplay =>
			$"<{qualifiedName}"
			+
			(id is not null ? $" id=\"{id}\"" : "")
			+
			(@class is not null ? $" class=\"{@class}\"" : "")
			+
			">"
			+
			(childNodes.Count != 0 ? "..." : "")
			+
			$"</{qualifiedName}>"
			;

		protected void SetAttribute(string? value, [CallerMemberName] string name = "")
		{
			Attr attr = new Attr
			{
				//namespaceURI = "http://www.w3.org/1999/xhtml",
				namespaceURI = null,
				localName = name,
				value = value!,
			};

			if (value is null)
			{
				_ = attributes.Remove((attr.namespaceURI, attr.qualifiedName));
			}
			else
			{
				attributes[(attr.namespaceURI, attr.qualifiedName)] = attr;
			}
		}

		protected string? GetAttribute([CallerMemberName] string name = "")
		{
			Attr attr = new Attr
			{
				//namespaceURI = "http://www.w3.org/1999/xhtml",
				namespaceURI = null,
				localName = name,
			};

			return attributes.GetValueOrDefault((attr.namespaceURI, attr.qualifiedName))?.value;
		}

		protected void SetAttribute<TEnum>(TEnum? value, [CallerMemberName] string name = "")
			where TEnum : struct, System.Enum
		{
			SetAttribute(value?.AsString(EnumFormat.EnumMemberValue, EnumFormat.Name), name);
		}

		protected TEnum? GetAttribute<TEnum>([CallerMemberName] string name = "")
			where TEnum : struct, System.Enum
		{
			return GetAttribute(name) is { } x ? Enums.Parse<TEnum>(x, ignoreCase: false, EnumFormat.EnumMemberValue, EnumFormat.Name) : null;
		}

		protected void AddEvent<TEvent>(EventHandler<TEvent> value, [CallerMemberName] string name = "")
			where TEvent : DOM.Event
		{
			//if (name.StartsWith("on"))
			//{
			//	name = name[2..];
			//}

			List<EventHandler<DOM.Event>> list = events.GetOrAdd(name, _ => new());

			list.Add(Events.GetNongenericEvent(value));
		}

		protected void RemoveEvent<TEvent>(EventHandler<TEvent> value, [CallerMemberName] string name = "")
			where TEvent : DOM.Event
		{
			//if (name.StartsWith("on"))
			//{
			//	name = name[2..];
			//}

			bool hasEvent = events.TryGetValue(name, out List<EventHandler<DOM.Event>>? list);

			if (!hasEvent) { return; }
			if (list is null) { return; }

			_ = list.Remove(Events.GetNongenericEvent(value));
		}

		public string? @class { get => GetAttribute(); set => SetAttribute(value); }
		public string? id { get => GetAttribute(); set => SetAttribute(value); }
		//public string? slot { get => GetAttribute(); set => SetAttribute(value); }

		public string? accesskey { get => GetAttribute(); set => SetAttribute(value); }
		public autocapitalize? autocapitalize { get => GetAttribute<autocapitalize>(); set => SetAttribute(value); }
		public autofocus? autofocus { get => GetAttribute<autofocus>(); set => SetAttribute(value); }
		public contenteditable? contenteditable { get => GetAttribute<contenteditable>(); set => SetAttribute(value); }
		public dir? dir { get => GetAttribute<dir>(); set => SetAttribute(value); }
		public draggable? draggable { get => GetAttribute<draggable>(); set => SetAttribute(value); }
		public enterkeyhint? enterkeyhint { get => GetAttribute<enterkeyhint>(); set => SetAttribute(value); }
		public hidden? hidden { get => GetAttribute<hidden>(); set => SetAttribute(value); }
		public inputmode? inputmode { get => GetAttribute<inputmode>(); set => SetAttribute(value); }
		//public string? @is { get => GetAttribute(); set => SetAttribute(value); }
		//public string? itemid { get => GetAttribute(); set => SetAttribute(value); }
		//public string? itemprop { get => GetAttribute(); set => SetAttribute(value); }
		//public string? itemref { get => GetAttribute(); set => SetAttribute(value); }
		//public string? itemscope { get => GetAttribute(); set => SetAttribute(value); }
		//public string? itemtype { get => GetAttribute(); set => SetAttribute(value); }
		/// <summary>
		/// The lang attribute (in no namespace) specifies the primary language for the element's contents and for any of the element's attributes that contain text. Its value must be a valid BCP 47 language tag, or the empty string. Setting the attribute to the empty string indicates that the primary language is unknown.
		/// </summary>
		public string? lang { get => GetAttribute(); set => SetAttribute(value); }
		public string? nonce { get => GetAttribute(); set => SetAttribute(value); }
		public spellcheck? spellcheck { get => GetAttribute<spellcheck>(); set => SetAttribute(value); }
		public string? style { get => GetAttribute(); set => SetAttribute(value); }
		public int? tabindex
		{
			get => GetAttribute() is { } s ? JsonSerializer.Deserialize<int>(s) : null;
			set => SetAttribute(value is { } i ? JsonSerializer.Serialize(i) : null);
		}
		public string? title { get => GetAttribute(); set => SetAttribute(value); }
		public translate? translate { get => GetAttribute<translate>(); set => SetAttribute(value); }

		public event EventHandler<DOM.Event/*	*/> onabort/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.AnimationEvent/*	*/> onanimationend/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.AnimationEvent/*	*/> onanimationiteration/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.AnimationEvent/*	*/> onanimationstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onauxclick/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.FocusEvent/*	*/> onblur/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> oncancel/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> oncanplay/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> oncanplaythrough/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onchange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onclick/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onclose/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> oncontextmenu/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> oncuechange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> ondblclick/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondrag/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondragend/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondragenter/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondragleave/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondragover/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondragstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.DragEvent/*	*/> ondrop/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> ondurationchange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onemptied/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onended/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.FocusEvent/*	*/> onfocus/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.FormDataEvent/*	*/> onformdata/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> ongotpointercapture/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.InputEvent/*	*/> oninput/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> oninvalid/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.KeyboardEvent/*	*/> onkeydown/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.KeyboardEvent/*	*/> onkeypress/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.KeyboardEvent/*	*/> onkeyup/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onload/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onloadeddata/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onloadedmetadata/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.ProgressEvent/*	*/> onloadstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onlostpointercapture/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmousedown/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmouseenter/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmouseleave/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmousemove/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmouseout/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmouseover/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.MouseEvent/*	*/> onmouseup/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onpause/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onplay/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onplaying/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointercancel/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerdown/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerenter/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerleave/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointermove/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerout/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerover/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerrawupdate/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.PointerEvent/*	*/> onpointerup/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.ProgressEvent/*	*/> onprogress/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onratechange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onreset/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onresize/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onscroll/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onseeked/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onseeking/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onselect/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onselectionchange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onselectstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onstalled/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.SubmitEvent/*	*/> onsubmit/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onsuspend/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> ontimeupdate/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> ontoggle/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TouchEvent/*	*/> ontouchcancel/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TouchEvent/*	*/> ontouchend/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TouchEvent/*	*/> ontouchmove/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TouchEvent/*	*/> ontouchstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TransitionEvent/*	*/> ontransitioncancel/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TransitionEvent/*	*/> ontransitionend/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TransitionEvent/*	*/> ontransitionrun/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.TransitionEvent/*	*/> ontransitionstart/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onvolumechange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.Event/*	*/> onwaiting/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<DOM.WheelEvent/*	*/> onwheel/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
	}

	public enum autocapitalize
	{
		off,
		none,
		on,
		sentences,
		words,
		characters,
	}

	public enum autofocus
	{
		autofocus,
	}

	public enum contenteditable
	{
		@true,
		@false,
	}

	public enum dir
	{
		ltr,
		rtl,
		auto,
	}

	public enum draggable
	{
		@true,
		@false,
	}

	public enum enterkeyhint
	{
		enter,
		done,
		go,
		next,
		previous,
		search,
		send,
	}

	public enum hidden
	{
		hidden,
	}

	/// <summary>
	/// The inputmode content attribute is an enumerated attribute that specifies what kind of input mechanism would be most helpful for users entering content.
	/// </summary>
	public enum inputmode
	{
		/// <summary>
		/// The user agent should not display a virtual keyboard. This keyword is useful for content that renders its own keyboard control.
		/// </summary>
		none,
		text,
		tel,
		url,
		email,
		numeric,
		@decimal,
		search,
	}

	public enum spellcheck
	{
		@true,
		@false,
	}

	public enum translate
	{
		yes,
		no,
	}
}
