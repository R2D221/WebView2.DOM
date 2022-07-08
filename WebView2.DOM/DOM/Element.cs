using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/element.idl

	public abstract partial class Element : Node
	{
		private protected Element() { }

		public string? namespaceURI => Get<string?>();
		public string? prefix => Get<string?>();
		public string localName => Get<string>();
		public string tagName => Get<string>();

		public string id { get => Get<string>(); set => Set(value); }
		public string className { get => Get<string>(); set => Set(value); }
		public DOMTokenList classList => _classList ??= Get<DOMTokenList>();
		private DOMTokenList? _classList;
		public string slot { get => Get<string>(); set => Set(value); }

		public bool hasAttributes()
		  => Method<bool>().Invoke();
		public NamedNodeMap attributes => _attributes ??= Get<NamedNodeMap>();
		private NamedNodeMap? _attributes;
		public IReadOnlyList<string> getAttributeNames()
			=> Method<ImmutableArray<string>>().Invoke();
		public string? getAttribute(string name)
		  => Method<string?>().Invoke(name);
		public string? getAttributeNS(string? namespaceURI, string localName)
		  => Method<string?>().Invoke(namespaceURI, localName);
		public void setAttribute(string name, /*TrustedString*/string value)
		  => Method().Invoke(name, value);
		public void setAttributeNS(string? namespaceURI, string name, /*TrustedString*/string value)
		  => Method().Invoke(namespaceURI, name, value);
		public void removeAttribute(string name)
		  => Method().Invoke(name);
		public void removeAttributeNS(string? namespaceURI, string localName)
		  => Method().Invoke(namespaceURI, localName);
		public bool toggleAttribute(string qualifiedName, bool? force = null) =>
			force != null
			? Method<bool>().Invoke(qualifiedName, force)
			: Method<bool>().Invoke(qualifiedName);
		public bool hasAttribute(string name)
		  => Method<bool>().Invoke(name);
		public bool hasAttributeNS(string? namespaceURI, string localName)
		  => Method<bool>().Invoke(namespaceURI, localName);

		public Attr? getAttributeNode(string name)
		  => Method<Attr?>().Invoke(name);
		public Attr? getAttributeNodeNS(string? namespaceURI, string localName)
		  => Method<Attr?>().Invoke(namespaceURI, localName);
		public Attr? setAttributeNode(Attr attr)
		  => Method<Attr?>().Invoke(attr);
		public Attr? setAttributeNodeNS(Attr attr)
		  => Method<Attr?>().Invoke(attr);
		public Attr removeAttributeNode(Attr attr)
		  => Method<Attr>().Invoke(attr);

		//public ShadowRoot attachShadow(ShadowRootInit shadowRootInitDict)
		//  => Method<ShadowRoot>().Invoke(shadowRootInitDict);
		//public ShadowRoot? shadowRoot => Get<ShadowRoot?>();

		public Element? closest(string selectors)
		  => Method<Element?>().Invoke(selectors);
		public bool matches(string selectors)
		  => Method<bool>().Invoke(selectors);

		public HTMLCollection<Element> getElementsByTagName(string localName)
		  => Method<HTMLCollection<Element>>().Invoke(localName);
		public HTMLCollection<Element> getElementsByTagNameNS(string? namespaceURI, string localName)
		  => Method<HTMLCollection<Element>>().Invoke(namespaceURI, localName);
		public HTMLCollection<Element> getElementsByClassName(string classNames)
		  => Method<HTMLCollection<Element>>().Invoke(classNames);

		public Element? insertAdjacentElement(string where, Element element)
		  => Method<Element?>().Invoke(where, element);
		public void insertAdjacentText(string where, string data)
		  => Method().Invoke(where, data);

		// CSS Shadow Parts
		public DOMTokenList part => _part ??= Get<DOMTokenList>();
		private DOMTokenList? _part;

		// Pointer Events
		public void setPointerCapture(int pointerId)
		  => Method().Invoke(pointerId);
		public void releasePointerCapture(int pointerId)
		  => Method().Invoke(pointerId);
		public bool hasPointerCapture(int pointerId)
		  => Method<bool>().Invoke(pointerId);

		// Mixin Slotable
		public HTMLSlotElement? assignedSlot => Get<HTMLSlotElement?>();

		// DOM Parsing and Serialization
		public string innerHTML { get => Get<string>(); set => Set(value); }
		public string outerHTML { get => Get<string>(); set => Set(value); }
		//public void insertAdjacentHTML(string position, HTMLString text)
		//  => Method().Invoke(position, text);

		// Declarative Shadow DOM getInnerHTML() function.
		//public HTMLString getInnerHTML(GetInnerHTMLOptions options = default)
		//  => Method<HTMLString>().Invoke(options);

		// Pointer Lock
		public void requestPointerLock(/*PointerLockOptions options = default*/)
		  => Method().Invoke(/*options*/);

		// CSSOM View Module
		public IReadOnlyList<DOMRect> getClientRects()
		  => Method<ImmutableArray<DOMRect>>().Invoke();
		public DOMRect getBoundingClientRect()
		  => Method<DOMRect>().Invoke();

		public void scrollIntoView()
		  => Method().Invoke();
		public void scrollIntoView(bool alignToTop)
		  => Method().Invoke(alignToTop);
		public void scrollIntoView(ScrollIntoViewOptions options)
		  => Method().Invoke(options);
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
		public double scrollTop { get => Get<double>(); set => Set(value); }
		public double scrollLeft { get => Get<double>(); set => Set(value); }
		public int scrollWidth => Get<int>();
		public int scrollHeight => Get<int>();
		public int clientTop => Get<int>();
		public int clientLeft => Get<int>();
		public int clientWidth => Get<int>();
		public int clientHeight => Get<int>();

		// Typed OM
		public StylePropertyMap attributeStyleMap => _attributeStyleMap ??= Get<StylePropertyMap>();
		private StylePropertyMap? _attributeStyleMap;

		// Non-standard API
		public void scrollIntoViewIfNeeded()
		  => Method().Invoke();
		public void scrollIntoViewIfNeeded(bool centerIfNeeded)
		  => Method().Invoke(centerIfNeeded);
		//public ShadowRoot createShadowRoot()
		//  => Method<ShadowRoot>().Invoke();
		//public NodeList getDestinationInsertionPoints()
		//  => Method<NodeList>().Invoke();

		// Experimental accessibility API
		//public string? computedRole => Get<string?>();
		//public string? computedName => Get<string?>();

		// Accessibility Object Model
		//public AccessibleNode? accessibleNode => Get<AccessibleNode?>();

		// Event handler attributes
		//public event EventHandler<UnknownEvent>? onbeforecopy { add => AddEvent(value); remove => RemoveEvent(value); }
		//public event EventHandler<UnknownEvent>? onbeforecut { add => AddEvent(value); remove => RemoveEvent(value); }
		//public event EventHandler<UnknownEvent>? onbeforepaste { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onsearch { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onbeforematch { add => AddEvent(value); remove => RemoveEvent(value); }

		// Element Timing
		public string elementTiming { get => Get<string>(); set => Set(value); }

		// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/element_computed_style_map.idl
		public StylePropertyMapReadOnly computedStyleMap() => Method<StylePropertyMapReadOnly>().Invoke();
	}
}