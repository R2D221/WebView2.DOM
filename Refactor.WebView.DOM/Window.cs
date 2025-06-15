using Refactor.WebView2.DOM.Interop;
using System;
using System.Runtime.CompilerServices;

namespace Refactor.WebView2.DOM;

public sealed class Window : EventTarget
{
	private static readonly ConditionalWeakTable<JsReference, Window> windowCache = new();
	public static Window window => windowCache.GetValue(BrowsingContext.GlobalObject, x => x.Get<Window>("window"));

	private Window() { }

	public int innerWidth => JS.Get<int>();
	public int innerHeight => JS.Get<int>();
	public Document document => JS.Get<Document>();

	public void alert(string message) => JS.Method().Invoke(message);
	public bool confirm(string message) => JS.Method<bool>().Invoke(message);

	public void queueMicrotask(Action callback) => JS.Method().Invoke(callback);
}

public sealed class HTMLDocument : Document;
public abstract class Document : Node
{
	public HTMLBodyElement body => JS.Get<HTMLBodyElement>();

	public Element createElement(string localName) => JS.Method<Element>().Invoke(localName);

	public NodeIterator createNodeIterator(Node root, int whatToShow, Func<Node, int> filter) =>
		JS.Method<NodeIterator>().Invoke(root, whatToShow, filter);
}

public abstract class Node : EventTarget
{
	public void append(Node node) => JS.Method().Invoke(node);
}
public abstract class Element : Node;
public abstract class HTMLElement : Element;
public sealed class HTMLAnchorElement : HTMLElement;
public sealed class HTMLBodyElement : HTMLElement;

public sealed class NodeIterator : JsObject
{
	public Node root => JS.Get<Node>();
	public Node referenceNode => JS.Get<Node>();
	public bool pointerBeforeReferenceNode => JS.Get<bool>();
	public int whatToShow => JS.Get<int>();
	//public NodeFilter filter => JS.Get<NodeFilter>();

	public Node? nextNode() => JS.Method<Node?>().Invoke();
	public Node? previousNode() => JS.Method<Node?>().Invoke();

	public void detach() => JS.Method().Invoke();
}
