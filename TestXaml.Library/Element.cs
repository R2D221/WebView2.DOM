using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[UsableDuringInitialization(true)]
	public abstract class Element : Node
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public abstract string namespaceURI { get; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public virtual string? prefix => null;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string localName => GetType().Name;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string qualifiedName => prefix is null ? localName : $"{prefix}:{localName}";

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Dictionary<(string? namespaceURI, string qualifiedName), Attr> attributes { get; } = new();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ConcurrentDictionary<string, List<EventHandler<DOM.Event>>> events { get; } = new();

		public virtual NodeList childNodes { get; }

		public Element() { childNodes = new EmptyNodeList(this); }
	}
}
