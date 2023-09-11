using System;

namespace WebView2.DOM.Components;

public abstract class HTMLElementBuilder : HTMLElementBuilder<HTMLElement>
{
}

public abstract class HTMLElementBuilder<THTMLElement> : ElementBuilder<THTMLElement>
	where THTMLElement : HTMLElement
{
	public AttributeBuilder<string> accesskey
	{
		get => new(value => element.accessKey = value);
		set => element.accessKey = value.GetConstantValue();
	}

	public AttributeBuilder<Autocapitalize> autocapitalize
	{
		get => new(value => element.autocapitalize = value);
		set => element.autocapitalize = value.GetConstantValue();
	}

	public AttributeBuilder<bool> autofocus
	{
		get => new(value => element.autofocus = value);
		set => element.autofocus = value.GetConstantValue();
	}

	public AttributeBuilder<ContentEditable> contenteditable
	{
		get => new(value => element.contentEditable = value);
		set => element.contentEditable = value.GetConstantValue();
	}

	public AttributeBuilder<Dir> dir
	{
		get => new(value => element.dir = value);
		set => element.dir = value.GetConstantValue();
	}

	public AttributeBuilder<bool?> draggable
	{
		get => new(value => SetOrRemoveAttribute(nameof(draggable), value switch { true => "true", false => "false", null => null }));
		set => SetOrRemoveAttribute(nameof(draggable), value.GetConstantValue() switch { true => "true", false => "false", null => null });
	}

	public AttributeBuilder<EnterKeyHint> enterkeyhint
	{
		get => new(value => element.enterKeyHint = value);
		set => element.enterKeyHint = value.GetConstantValue();
	}

	public AttributeBuilder<bool> hidden
	{
		get => new(value => element.hidden = value);
		set => element.hidden = value.GetConstantValue();
	}

	public AttributeBuilder<bool> inert
	{
		get => new(value => element.inert = value);
		set => element.inert = value.GetConstantValue();
	}

	public AttributeBuilder<InputMode> inputmode
	{
		get => new(value => element.inputMode = value);
		set => element.inputMode = value.GetConstantValue();
	}

	// public AttributeBuilder<TTT> @is
	// {
	// 	get => new(value => element.@is = value);
	// 	set => element.@is = value.GetConstantValue();
	// }

	// public AttributeBuilder<TTT> itemid
	// {
	// 	get => new(value => element.itemid = value);
	// 	set => element.itemid = value.GetConstantValue();
	// }

	// public AttributeBuilder<TTT> itemprop
	// {
	// 	get => new(value => element.itemprop = value);
	// 	set => element.itemprop = value.GetConstantValue();
	// }

	// public AttributeBuilder<TTT> itemref
	// {
	// 	get => new(value => element.itemref = value);
	// 	set => element.itemref = value.GetConstantValue();
	// }

	// public AttributeBuilder<TTT> itemscope
	// {
	// 	get => new(value => element.itemscope = value);
	// 	set => element.itemscope = value.GetConstantValue();
	// }

	// public AttributeBuilder<TTT> itemtype
	// {
	// 	get => new(value => element.itemtype = value);
	// 	set => element.itemtype = value.GetConstantValue();
	// }

	public AttributeBuilder<string> lang
	{
		get => new(value => element.lang = value);
		set => element.lang = value.GetConstantValue();
	}

	public AttributeBuilder<string> nonce
	{
		get => new(value => element.nonce = value);
		set => element.nonce = value.GetConstantValue();
	}

	// public AttributeBuilder<TTT> popover
	// {
	// 	get => new(value => element.popover = value);
	// 	set => element.popover = value.GetConstantValue();
	// }

	public AttributeBuilder<bool?> spellcheck
	{
		get => new(value => SetOrRemoveAttribute(nameof(spellcheck), value switch { true => "true", false => "false", null => null }));
		set => SetOrRemoveAttribute(nameof(spellcheck), value.GetConstantValue() switch { true => "true", false => "false", null => null });
	}

	public AttributeBuilder<string?> style
	{
		get => new(value => SetOrRemoveAttribute(nameof(style), value));
		set => SetOrRemoveAttribute(nameof(style), value.GetConstantValue());
	}

	public AttributeBuilder<int> tabindex
	{
		get => new(value => element.tabIndex = value);
		set => element.tabIndex = value.GetConstantValue();
	}

	public AttributeBuilder<string> title
	{
		get => new(value => element.title = value);
		set => element.title = value.GetConstantValue();
	}

	public AttributeBuilder<bool?> translate
	{
		get => new(value => SetOrRemoveAttribute(nameof(spellcheck), value switch { true => "yes", false => "no", null => null }));
		set => SetOrRemoveAttribute(nameof(spellcheck), value.GetConstantValue() switch { true => "yes", false => "no", null => null });
	}

	public AttributeBuilder<EventHandler<Event>> onabort
	{
		get
		{
			EventHandler<Event> onabort = (_, _) => { };
			element.onabort += (s, e) => onabort(s, e);
			return new(value => onabort = value);
		}

		set => element.onabort += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<AnimationEvent>> onanimationend
	{
		get
		{
			EventHandler<AnimationEvent> onanimationend = (_, _) => { };
			element.onanimationend += (s, e) => onanimationend(s, e);
			return new(value => onanimationend = value);
		}

		set => element.onanimationend += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<AnimationEvent>> onanimationiteration
	{
		get
		{
			EventHandler<AnimationEvent> onanimationiteration = (_, _) => { };
			element.onanimationiteration += (s, e) => onanimationiteration(s, e);
			return new(value => onanimationiteration = value);
		}

		set => element.onanimationiteration += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<AnimationEvent>> onanimationstart
	{
		get
		{
			EventHandler<AnimationEvent> onanimationstart = (_, _) => { };
			element.onanimationstart += (s, e) => onanimationstart(s, e);
			return new(value => onanimationstart = value);
		}

		set => element.onanimationstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onauxclick
	{
		get
		{
			EventHandler<PointerEvent> onauxclick = (_, _) => { };
			element.onauxclick += (s, e) => onauxclick(s, e);
			return new(value => onauxclick = value);
		}

		set => element.onauxclick += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<FocusEvent>> onblur
	{
		get
		{
			EventHandler<FocusEvent> onblur = (_, _) => { };
			element.onblur += (s, e) => onblur(s, e);
			return new(value => onblur = value);
		}

		set => element.onblur += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> oncancel
	{
		get
		{
			EventHandler<Event> oncancel = (_, _) => { };
			element.oncancel += (s, e) => oncancel(s, e);
			return new(value => oncancel = value);
		}

		set => element.oncancel += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> oncanplay
	{
		get
		{
			EventHandler<Event> oncanplay = (_, _) => { };
			element.oncanplay += (s, e) => oncanplay(s, e);
			return new(value => oncanplay = value);
		}

		set => element.oncanplay += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> oncanplaythrough
	{
		get
		{
			EventHandler<Event> oncanplaythrough = (_, _) => { };
			element.oncanplaythrough += (s, e) => oncanplaythrough(s, e);
			return new(value => oncanplaythrough = value);
		}

		set => element.oncanplaythrough += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onchange
	{
		get
		{
			EventHandler<Event> onchange = (_, _) => { };
			element.onchange += (s, e) => onchange(s, e);
			return new(value => onchange = value);
		}

		set => element.onchange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onclick
	{
		get
		{
			EventHandler<PointerEvent> onclick = (_, _) => { };
			element.onclick += (s, e) => onclick(s, e);
			return new(value => onclick = value);
		}

		set => element.onclick += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onclose
	{
		get
		{
			EventHandler<Event> onclose = (_, _) => { };
			element.onclose += (s, e) => onclose(s, e);
			return new(value => onclose = value);
		}

		set => element.onclose += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> oncontextmenu
	{
		get
		{
			EventHandler<PointerEvent> oncontextmenu = (_, _) => { };
			element.oncontextmenu += (s, e) => oncontextmenu(s, e);
			return new(value => oncontextmenu = value);
		}

		set => element.oncontextmenu += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> oncuechange
	{
		get
		{
			EventHandler<Event> oncuechange = (_, _) => { };
			element.oncuechange += (s, e) => oncuechange(s, e);
			return new(value => oncuechange = value);
		}

		set => element.oncuechange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> ondblclick
	{
		get
		{
			EventHandler<MouseEvent> ondblclick = (_, _) => { };
			element.ondblclick += (s, e) => ondblclick(s, e);
			return new(value => ondblclick = value);
		}

		set => element.ondblclick += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondrag
	{
		get
		{
			EventHandler<DragEvent> ondrag = (_, _) => { };
			element.ondrag += (s, e) => ondrag(s, e);
			return new(value => ondrag = value);
		}

		set => element.ondrag += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondragend
	{
		get
		{
			EventHandler<DragEvent> ondragend = (_, _) => { };
			element.ondragend += (s, e) => ondragend(s, e);
			return new(value => ondragend = value);
		}

		set => element.ondragend += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondragenter
	{
		get
		{
			EventHandler<DragEvent> ondragenter = (_, _) => { };
			element.ondragenter += (s, e) => ondragenter(s, e);
			return new(value => ondragenter = value);
		}

		set => element.ondragenter += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondragleave
	{
		get
		{
			EventHandler<DragEvent> ondragleave = (_, _) => { };
			element.ondragleave += (s, e) => ondragleave(s, e);
			return new(value => ondragleave = value);
		}

		set => element.ondragleave += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondragover
	{
		get
		{
			EventHandler<DragEvent> ondragover = (_, _) => { };
			element.ondragover += (s, e) => ondragover(s, e);
			return new(value => ondragover = value);
		}

		set => element.ondragover += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondragstart
	{
		get
		{
			EventHandler<DragEvent> ondragstart = (_, _) => { };
			element.ondragstart += (s, e) => ondragstart(s, e);
			return new(value => ondragstart = value);
		}

		set => element.ondragstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<DragEvent>> ondrop
	{
		get
		{
			EventHandler<DragEvent> ondrop = (_, _) => { };
			element.ondrop += (s, e) => ondrop(s, e);
			return new(value => ondrop = value);
		}

		set => element.ondrop += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> ondurationchange
	{
		get
		{
			EventHandler<Event> ondurationchange = (_, _) => { };
			element.ondurationchange += (s, e) => ondurationchange(s, e);
			return new(value => ondurationchange = value);
		}

		set => element.ondurationchange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onemptied
	{
		get
		{
			EventHandler<Event> onemptied = (_, _) => { };
			element.onemptied += (s, e) => onemptied(s, e);
			return new(value => onemptied = value);
		}

		set => element.onemptied += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onended
	{
		get
		{
			EventHandler<Event> onended = (_, _) => { };
			element.onended += (s, e) => onended(s, e);
			return new(value => onended = value);
		}

		set => element.onended += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<FocusEvent>> onfocus
	{
		get
		{
			EventHandler<FocusEvent> onfocus = (_, _) => { };
			element.onfocus += (s, e) => onfocus(s, e);
			return new(value => onfocus = value);
		}

		set => element.onfocus += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<FormDataEvent>> onformdata
	{
		get
		{
			EventHandler<FormDataEvent> onformdata = (_, _) => { };
			element.onformdata += (s, e) => onformdata(s, e);
			return new(value => onformdata = value);
		}

		set => element.onformdata += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> ongotpointercapture
	{
		get
		{
			EventHandler<PointerEvent> ongotpointercapture = (_, _) => { };
			element.ongotpointercapture += (s, e) => ongotpointercapture(s, e);
			return new(value => ongotpointercapture = value);
		}

		set => element.ongotpointercapture += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<InputEvent>> oninput
	{
		get
		{
			EventHandler<InputEvent> oninput = (_, _) => { };
			element.oninput += (s, e) => oninput(s, e);
			return new(value => oninput = value);
		}

		set => element.oninput += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> oninvalid
	{
		get
		{
			EventHandler<Event> oninvalid = (_, _) => { };
			element.oninvalid += (s, e) => oninvalid(s, e);
			return new(value => oninvalid = value);
		}

		set => element.oninvalid += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<KeyboardEvent>> onkeydown
	{
		get
		{
			EventHandler<KeyboardEvent> onkeydown = (_, _) => { };
			element.onkeydown += (s, e) => onkeydown(s, e);
			return new(value => onkeydown = value);
		}

		set => element.onkeydown += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<KeyboardEvent>> onkeypress
	{
		get
		{
			EventHandler<KeyboardEvent> onkeypress = (_, _) => { };
			element.onkeypress += (s, e) => onkeypress(s, e);
			return new(value => onkeypress = value);
		}

		set => element.onkeypress += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<KeyboardEvent>> onkeyup
	{
		get
		{
			EventHandler<KeyboardEvent> onkeyup = (_, _) => { };
			element.onkeyup += (s, e) => onkeyup(s, e);
			return new(value => onkeyup = value);
		}

		set => element.onkeyup += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onload
	{
		get
		{
			EventHandler<Event> onload = (_, _) => { };
			element.onload += (s, e) => onload(s, e);
			return new(value => onload = value);
		}

		set => element.onload += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onloadeddata
	{
		get
		{
			EventHandler<Event> onloadeddata = (_, _) => { };
			element.onloadeddata += (s, e) => onloadeddata(s, e);
			return new(value => onloadeddata = value);
		}

		set => element.onloadeddata += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onloadedmetadata
	{
		get
		{
			EventHandler<Event> onloadedmetadata = (_, _) => { };
			element.onloadedmetadata += (s, e) => onloadedmetadata(s, e);
			return new(value => onloadedmetadata = value);
		}

		set => element.onloadedmetadata += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<ProgressEvent>> onloadstart
	{
		get
		{
			EventHandler<ProgressEvent> onloadstart = (_, _) => { };
			element.onloadstart += (s, e) => onloadstart(s, e);
			return new(value => onloadstart = value);
		}

		set => element.onloadstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onlostpointercapture
	{
		get
		{
			EventHandler<PointerEvent> onlostpointercapture = (_, _) => { };
			element.onlostpointercapture += (s, e) => onlostpointercapture(s, e);
			return new(value => onlostpointercapture = value);
		}

		set => element.onlostpointercapture += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmousedown
	{
		get
		{
			EventHandler<MouseEvent> onmousedown = (_, _) => { };
			element.onmousedown += (s, e) => onmousedown(s, e);
			return new(value => onmousedown = value);
		}

		set => element.onmousedown += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmouseenter
	{
		get
		{
			EventHandler<MouseEvent> onmouseenter = (_, _) => { };
			element.onmouseenter += (s, e) => onmouseenter(s, e);
			return new(value => onmouseenter = value);
		}

		set => element.onmouseenter += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmouseleave
	{
		get
		{
			EventHandler<MouseEvent> onmouseleave = (_, _) => { };
			element.onmouseleave += (s, e) => onmouseleave(s, e);
			return new(value => onmouseleave = value);
		}

		set => element.onmouseleave += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmousemove
	{
		get
		{
			EventHandler<MouseEvent> onmousemove = (_, _) => { };
			element.onmousemove += (s, e) => onmousemove(s, e);
			return new(value => onmousemove = value);
		}

		set => element.onmousemove += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmouseout
	{
		get
		{
			EventHandler<MouseEvent> onmouseout = (_, _) => { };
			element.onmouseout += (s, e) => onmouseout(s, e);
			return new(value => onmouseout = value);
		}

		set => element.onmouseout += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmouseover
	{
		get
		{
			EventHandler<MouseEvent> onmouseover = (_, _) => { };
			element.onmouseover += (s, e) => onmouseover(s, e);
			return new(value => onmouseover = value);
		}

		set => element.onmouseover += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<MouseEvent>> onmouseup
	{
		get
		{
			EventHandler<MouseEvent> onmouseup = (_, _) => { };
			element.onmouseup += (s, e) => onmouseup(s, e);
			return new(value => onmouseup = value);
		}

		set => element.onmouseup += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onpause
	{
		get
		{
			EventHandler<Event> onpause = (_, _) => { };
			element.onpause += (s, e) => onpause(s, e);
			return new(value => onpause = value);
		}

		set => element.onpause += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onplay
	{
		get
		{
			EventHandler<Event> onplay = (_, _) => { };
			element.onplay += (s, e) => onplay(s, e);
			return new(value => onplay = value);
		}

		set => element.onplay += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onplaying
	{
		get
		{
			EventHandler<Event> onplaying = (_, _) => { };
			element.onplaying += (s, e) => onplaying(s, e);
			return new(value => onplaying = value);
		}

		set => element.onplaying += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointercancel
	{
		get
		{
			EventHandler<PointerEvent> onpointercancel = (_, _) => { };
			element.onpointercancel += (s, e) => onpointercancel(s, e);
			return new(value => onpointercancel = value);
		}

		set => element.onpointercancel += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerdown
	{
		get
		{
			EventHandler<PointerEvent> onpointerdown = (_, _) => { };
			element.onpointerdown += (s, e) => onpointerdown(s, e);
			return new(value => onpointerdown = value);
		}

		set => element.onpointerdown += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerenter
	{
		get
		{
			EventHandler<PointerEvent> onpointerenter = (_, _) => { };
			element.onpointerenter += (s, e) => onpointerenter(s, e);
			return new(value => onpointerenter = value);
		}

		set => element.onpointerenter += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerleave
	{
		get
		{
			EventHandler<PointerEvent> onpointerleave = (_, _) => { };
			element.onpointerleave += (s, e) => onpointerleave(s, e);
			return new(value => onpointerleave = value);
		}

		set => element.onpointerleave += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointermove
	{
		get
		{
			EventHandler<PointerEvent> onpointermove = (_, _) => { };
			element.onpointermove += (s, e) => onpointermove(s, e);
			return new(value => onpointermove = value);
		}

		set => element.onpointermove += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerout
	{
		get
		{
			EventHandler<PointerEvent> onpointerout = (_, _) => { };
			element.onpointerout += (s, e) => onpointerout(s, e);
			return new(value => onpointerout = value);
		}

		set => element.onpointerout += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerover
	{
		get
		{
			EventHandler<PointerEvent> onpointerover = (_, _) => { };
			element.onpointerover += (s, e) => onpointerover(s, e);
			return new(value => onpointerover = value);
		}

		set => element.onpointerover += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerrawupdate
	{
		get
		{
			EventHandler<PointerEvent> onpointerrawupdate = (_, _) => { };
			element.onpointerrawupdate += (s, e) => onpointerrawupdate(s, e);
			return new(value => onpointerrawupdate = value);
		}

		set => element.onpointerrawupdate += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<PointerEvent>> onpointerup
	{
		get
		{
			EventHandler<PointerEvent> onpointerup = (_, _) => { };
			element.onpointerup += (s, e) => onpointerup(s, e);
			return new(value => onpointerup = value);
		}

		set => element.onpointerup += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<ProgressEvent>> onprogress
	{
		get
		{
			EventHandler<ProgressEvent> onprogress = (_, _) => { };
			element.onprogress += (s, e) => onprogress(s, e);
			return new(value => onprogress = value);
		}

		set => element.onprogress += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onratechange
	{
		get
		{
			EventHandler<Event> onratechange = (_, _) => { };
			element.onratechange += (s, e) => onratechange(s, e);
			return new(value => onratechange = value);
		}

		set => element.onratechange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onreset
	{
		get
		{
			EventHandler<Event> onreset = (_, _) => { };
			element.onreset += (s, e) => onreset(s, e);
			return new(value => onreset = value);
		}

		set => element.onreset += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onresize
	{
		get
		{
			EventHandler<Event> onresize = (_, _) => { };
			element.onresize += (s, e) => onresize(s, e);
			return new(value => onresize = value);
		}

		set => element.onresize += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onscroll
	{
		get
		{
			EventHandler<Event> onscroll = (_, _) => { };
			element.onscroll += (s, e) => onscroll(s, e);
			return new(value => onscroll = value);
		}

		set => element.onscroll += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onseeked
	{
		get
		{
			EventHandler<Event> onseeked = (_, _) => { };
			element.onseeked += (s, e) => onseeked(s, e);
			return new(value => onseeked = value);
		}

		set => element.onseeked += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onseeking
	{
		get
		{
			EventHandler<Event> onseeking = (_, _) => { };
			element.onseeking += (s, e) => onseeking(s, e);
			return new(value => onseeking = value);
		}

		set => element.onseeking += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onselect
	{
		get
		{
			EventHandler<Event> onselect = (_, _) => { };
			element.onselect += (s, e) => onselect(s, e);
			return new(value => onselect = value);
		}

		set => element.onselect += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onselectionchange
	{
		get
		{
			EventHandler<Event> onselectionchange = (_, _) => { };
			element.onselectionchange += (s, e) => onselectionchange(s, e);
			return new(value => onselectionchange = value);
		}

		set => element.onselectionchange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onselectstart
	{
		get
		{
			EventHandler<Event> onselectstart = (_, _) => { };
			element.onselectstart += (s, e) => onselectstart(s, e);
			return new(value => onselectstart = value);
		}

		set => element.onselectstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onstalled
	{
		get
		{
			EventHandler<Event> onstalled = (_, _) => { };
			element.onstalled += (s, e) => onstalled(s, e);
			return new(value => onstalled = value);
		}

		set => element.onstalled += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<SubmitEvent>> onsubmit
	{
		get
		{
			EventHandler<SubmitEvent> onsubmit = (_, _) => { };
			element.onsubmit += (s, e) => onsubmit(s, e);
			return new(value => onsubmit = value);
		}

		set => element.onsubmit += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onsuspend
	{
		get
		{
			EventHandler<Event> onsuspend = (_, _) => { };
			element.onsuspend += (s, e) => onsuspend(s, e);
			return new(value => onsuspend = value);
		}

		set => element.onsuspend += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> ontimeupdate
	{
		get
		{
			EventHandler<Event> ontimeupdate = (_, _) => { };
			element.ontimeupdate += (s, e) => ontimeupdate(s, e);
			return new(value => ontimeupdate = value);
		}

		set => element.ontimeupdate += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> ontoggle
	{
		get
		{
			EventHandler<Event> ontoggle = (_, _) => { };
			element.ontoggle += (s, e) => ontoggle(s, e);
			return new(value => ontoggle = value);
		}

		set => element.ontoggle += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TouchEvent>> ontouchcancel
	{
		get
		{
			EventHandler<TouchEvent> ontouchcancel = (_, _) => { };
			element.ontouchcancel += (s, e) => ontouchcancel(s, e);
			return new(value => ontouchcancel = value);
		}

		set => element.ontouchcancel += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TouchEvent>> ontouchend
	{
		get
		{
			EventHandler<TouchEvent> ontouchend = (_, _) => { };
			element.ontouchend += (s, e) => ontouchend(s, e);
			return new(value => ontouchend = value);
		}

		set => element.ontouchend += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TouchEvent>> ontouchmove
	{
		get
		{
			EventHandler<TouchEvent> ontouchmove = (_, _) => { };
			element.ontouchmove += (s, e) => ontouchmove(s, e);
			return new(value => ontouchmove = value);
		}

		set => element.ontouchmove += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TouchEvent>> ontouchstart
	{
		get
		{
			EventHandler<TouchEvent> ontouchstart = (_, _) => { };
			element.ontouchstart += (s, e) => ontouchstart(s, e);
			return new(value => ontouchstart = value);
		}

		set => element.ontouchstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TransitionEvent>> ontransitioncancel
	{
		get
		{
			EventHandler<TransitionEvent> ontransitioncancel = (_, _) => { };
			element.ontransitioncancel += (s, e) => ontransitioncancel(s, e);
			return new(value => ontransitioncancel = value);
		}

		set => element.ontransitioncancel += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TransitionEvent>> ontransitionend
	{
		get
		{
			EventHandler<TransitionEvent> ontransitionend = (_, _) => { };
			element.ontransitionend += (s, e) => ontransitionend(s, e);
			return new(value => ontransitionend = value);
		}

		set => element.ontransitionend += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TransitionEvent>> ontransitionrun
	{
		get
		{
			EventHandler<TransitionEvent> ontransitionrun = (_, _) => { };
			element.ontransitionrun += (s, e) => ontransitionrun(s, e);
			return new(value => ontransitionrun = value);
		}

		set => element.ontransitionrun += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<TransitionEvent>> ontransitionstart
	{
		get
		{
			EventHandler<TransitionEvent> ontransitionstart = (_, _) => { };
			element.ontransitionstart += (s, e) => ontransitionstart(s, e);
			return new(value => ontransitionstart = value);
		}

		set => element.ontransitionstart += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onvolumechange
	{
		get
		{
			EventHandler<Event> onvolumechange = (_, _) => { };
			element.onvolumechange += (s, e) => onvolumechange(s, e);
			return new(value => onvolumechange = value);
		}

		set => element.onvolumechange += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<Event>> onwaiting
	{
		get
		{
			EventHandler<Event> onwaiting = (_, _) => { };
			element.onwaiting += (s, e) => onwaiting(s, e);
			return new(value => onwaiting = value);
		}

		set => element.onwaiting += value.GetConstantValue();
	}

	public AttributeBuilder<EventHandler<WheelEvent>> onwheel
	{
		get
		{
			EventHandler<WheelEvent> onwheel = (_, _) => { };
			element.onwheel += (s, e) => onwheel(s, e);
			return new(value => onwheel = value);
		}

		set => element.onwheel += value.GetConstantValue();
	}
}
