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
	public bool sendTest(Document document) => JS.Method<bool>().Invoke(document);
}

public abstract class Document : EventTarget;
public sealed class HTMLDocument : Document;
