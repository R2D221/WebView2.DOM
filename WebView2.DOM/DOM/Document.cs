using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/document.idl

	public enum DocumentReadyState { loading, interactive, complete }

	public enum VisibilityState { hidden, visible, prerender, unloaded }

	public enum AddressSpace { local, @private, @public }

	public partial class Document : Node
	{
		private protected Document() { }

		#region url
		public DOMImplementation implementation => GetCached<DOMImplementation>();
		public string URL => Get<string>();
		public string? documentURI => Get<string?>();
		public string compatMode => Get<string>();
		#endregion

		#region charset
		public string characterSet => Get<string>();
		//public string charset => GetPrimitive<string>();
		//public string inputEncoding => GetPrimitive<string>();
		public string contentType => Get<string>();
		#endregion

		#region elements
		public DocumentType? doctype => Get<DocumentType?>();
		public Element? documentElement => Get<Element?>();
		public HTMLCollection<Element> getElementsByTagName(string localName)
		  => Method<HTMLCollection<Element>>().Invoke(localName);
		public HTMLCollection<Element> getElementsByTagNameNS(string? namespaceURI, string localName)
		  => Method<HTMLCollection<Element>>().Invoke(namespaceURI, localName);
		public HTMLCollection<Element> getElementsByClassName(string classNames)
		  => Method<HTMLCollection<Element>>().Invoke(classNames);
		#endregion

		#region createNode
		public Element createElement(string localName)
		  => Method<Element>().Invoke(localName);
		public Element createElementNS(string? namespaceURI, string qualifiedName)
		  => Method<Element>().Invoke(namespaceURI, qualifiedName);
		public DocumentFragment createDocumentFragment()
		  => Method<DocumentFragment>().Invoke();
		public Text createTextNode(string data)
		  => Method<Text>().Invoke(data);
		public CDATASection createCDATASection(string data)
		  => Method<CDATASection>().Invoke(data);
		public Comment createComment(string data)
		  => Method<Comment>().Invoke(data);
		public ProcessingInstruction createProcessingInstruction(string target, string data)
		  => Method<ProcessingInstruction>().Invoke(target, data);
		#endregion

		#region importNode
		public Node importNode(Node node, bool deep)
		  => Method<Node>().Invoke(node, deep);
		public Node adoptNode(Node node)
		  => Method<Node>().Invoke(node);
		#endregion

		#region create attr/event/range
		public Attr createAttribute(string localName)
		  => Method<Attr>().Invoke(localName);
		public Attr createAttributeNS(string? namespaceURI, string qualifiedName)
		  => Method<Attr>().Invoke(namespaceURI, qualifiedName);

		public Event createEvent(string eventType)
		  => Method<Event>().Invoke(eventType);

		public Range createRange()
		  => Method<Range>().Invoke();
		#endregion

		#region NodeIterator
		//public NodeIterator createNodeIterator(Node root, uint whatToShow = 0xFFFFFFFF, NodeFilter? filter = null)
		//  => ReturnObject<NodeIterator>().Invoke(root, whatToShow, filter);
		//public TreeWalker createTreeWalker(Node root, uint whatToShow = 0xFFFFFFFF, NodeFilter? filter = null)
		//  => ReturnObject<TreeWalker>().Invoke(root, whatToShow, filter);
		#endregion

		#region xmlEncoding/xmlVersion/xmlStandalone have been removed from the spec
		//public string? xmlEncoding => GetPrimitive<string?>();
		//public string? xmlVersion { get => GetPrimitive<string?>(); set => SetPrimitive(value); }
		//public bool xmlStandalone { get => GetPrimitive<bool>(); set => SetPrimitive(value); }
		#endregion

		#region resource metadata management
		public Location? location => Get<Location?>();
		public string domain { get => Get<string>(); set => Set(value); }
		public string referrer => Get<string>();
		public string cookie { get => Get<string>(); set => Set(value); }
		public string lastModified => Get<string>();
		public DocumentReadyState readyState => Get<DocumentReadyState>();
		#endregion

		#region DOM tree accessors
		public string title { get => Get<string>(); set => Set(value); }
		public string dir { get => Get<string>(); set => Set(value); }
		public HTMLBodyElement/*?*/ body { get => Get<HTMLBodyElement/*?*/>(); set => Set(value); }
		public HTMLHeadElement/*?*/ head => Get<HTMLHeadElement/*?*/>();
		public HTMLCollection<HTMLImageElement> images => GetCached<HTMLCollection<HTMLImageElement>>();
		public HTMLCollection<HTMLEmbedElement> embeds => GetCached<HTMLCollection<HTMLEmbedElement>>();
		public HTMLCollection<HTMLEmbedElement> plugins => GetCached<HTMLCollection<HTMLEmbedElement>>();
		public HTMLCollection<HTMLHyperlinkElementUtils> links => GetCached<HTMLCollection<HTMLHyperlinkElementUtils>>();
		public HTMLCollection<HTMLFormElement> forms => GetCached<HTMLCollection<HTMLFormElement>>();
		public HTMLCollection<HTMLScriptElement> scripts => GetCached<HTMLCollection<HTMLScriptElement>>();
		public NodeList<HTMLElement> getElementsByName(string elementName)
		  => Method<NodeList<HTMLElement>>().Invoke(elementName);
		//public HTMLOrSVGScriptElement? currentScript => Get2<HTMLOrSVGScriptElement?>();
		#endregion

		#region dynamic markup insertion
		//public Document open(string type = "text/html", string replace = "")
		//  => ReturnObject<Document>().Invoke(type, replace);
		public Window open(string url, string name, string features)
		  => Method<Window>().Invoke(url, name, features);
		//public void close()
		//  => ReturnVoid().Invoke();
		//public void write(params string[] text)
		//  => ReturnVoid().Invoke(text);
		//public void writeln(params string[] text)
		//  => ReturnVoid().Invoke(text);
		//public void write(TrustedHTML text)
		//  => ReturnVoid().Invoke(text);
		//public void writeln(TrustedHTML text)
		//  => ReturnVoid().Invoke(text);
		#endregion

		#region user interaction
		public Window? defaultView => Get<Window?>();
		public bool hasFocus()
		  => Method<bool>().Invoke();
		public string designMode { get => Get<string>(); set => Set(value); }
		//public bool execCommand(string commandId, bool showUI = false, string value = "")
		//  => ReturnPrimitive<bool>().Invoke(commandId, showUI, value);
		//public bool queryCommandEnabled(string commandId)
		//  => ReturnPrimitive<bool>().Invoke(commandId);
		//public bool queryCommandIndeterm(string commandId)
		//  => ReturnPrimitive<bool>().Invoke(commandId);
		//public bool queryCommandState(string commandId)
		//  => ReturnPrimitive<bool>().Invoke(commandId);
		//public bool queryCommandSupported(string commandId)
		//  => ReturnPrimitive<bool>().Invoke(commandId);
		//public string queryCommandValue(string commandId)
		//  => ReturnPrimitive<string>().Invoke(commandId);
		#endregion

		public event EventHandler<Event>? onreadystatechange { add => AddEvent(value); remove => RemoveEvent(value); }

		#region HTML obsolete features
		//public HTMLCollection anchors => GetObject<HTMLCollection>();
		//public HTMLCollection applets => GetObject<HTMLCollection>();
		//public string fgColor { get => GetPrimitive<string>(); set => SetPrimitive(value); }
		//public string linkColor { get => GetPrimitive<string>(); set => SetPrimitive(value); }
		//public string vlinkColor { get => GetPrimitive<string>(); set => SetPrimitive(value); }
		//public string alinkColor { get => GetPrimitive<string>(); set => SetPrimitive(value); }
		//public string bgColor { get => GetPrimitive<string>(); set => SetPrimitive(value); }
		//public void clear()
		//  => ReturnVoid().Invoke();
		//public void captureEvents()
		//  => ReturnVoid().Invoke();
		//public void releaseEvents()
		//  => ReturnVoid().Invoke();
		//public HTMLAllCollection all => GetCached<HTMLAllCollection>();
		#endregion

		#region CSSOM View Module
		public Element? scrollingElement => Get<Element?>();
		#endregion

		#region Pointer Lock
		public event EventHandler<Event>? onpointerlockchange { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onpointerlockerror { add => AddEvent(value); remove => RemoveEvent(value); }
		public void exitPointerLock()
		  => Method().Invoke();
		#endregion

		#region Custom Elements
		//public any registerElement(string type, ElementRegistrationOptions options = default)
		//  => ReturnPrimitive<any>().Invoke(type, options);
		//public Element createElement(string localName, options)
		//  => ReturnObject<Element>().Invoke(localName, options);
		//public Element createElementNS(string? namespaceURI, string qualifiedName, options)
		//  => ReturnObject<Element>().Invoke(namespaceURI, qualifiedName, options);
		#endregion

		#region Page Visibility
		public bool hidden => Get<bool>();
		public VisibilityState visibilityState => Get<VisibilityState>();
		public bool wasDiscarded => Get<bool>();
		#endregion

		#region CORS and RFC1918
		public AddressSpace addressSpace => Get<AddressSpace>();
		#endregion

		#region Non-standard APIs
		//public Range caretRangeFromPoint(int x = 0, int y = 0)
		//  => ReturnObject<Range>().Invoke(x, y);
		#endregion

		#region Storage Access API
		public Promise<bool> hasStorageAccess() =>
			Method<Promise<bool>>().Invoke();
		public VoidPromise requestStorageAccess() =>
			Method<VoidPromise>().Invoke();
		#endregion

		#region Text fragment directive API
		//public FragmentDirective fragmentDirective => GetCached<FragmentDirective>();
		#endregion

		#region Feature policy
		//public FeaturePolicy featurePolicy => GetObject<FeaturePolicy>();
		#endregion

		#region Deprecated prefixed page visibility API.
		//public string webkitVisibilityState => GetPrimitive<string>();
		//public bool webkitHidden => GetPrimitive<bool>();
		#endregion

		#region Trust Token API
		//public Task<bool> hasTrustToken(string issuer)
		//  => ReturnPrimitiveTask<bool>().Invoke(issuer);
		#endregion

		#region Events
		//public event EventHandler<Event>? onbeforecopy { add => AddEvent(value); remove => RemoveEvent(value); }
		//public event EventHandler<Event>? onbeforecut { add => AddEvent(value); remove => RemoveEvent(value); }
		//public event EventHandler<Event>? onbeforepaste { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onfreeze { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onresume { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onsearch { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<SecurityPolicyViolationEvent>? onsecuritypolicyviolation { add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event>? onvisibilitychange { add => AddEvent(value); remove => RemoveEvent(value); }
		#endregion
	}
}