using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(childNodes))]
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public abstract class HTMLElement : Element
	{
		public NodeList childNodes { get; } = new();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string tagName => GetType().Name;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected virtual string DebuggerDisplay =>
			$"<{tagName}"
			+
			(id is not null ? $" id=\"{id}\"" : "")
			+
			(@class is not null ? $" class=\"{@class}\"" : "")
			+
			">"
			+
			(childNodes.Any() ? "..." : "")
			+
			$"</{tagName}>"
			;

		public string? @class { get; set; }
		public string? id { get; set; }
		//public string? slot { get; set; }

		public string? accesskey { get; set; }
		public string? autocapitalize { get; set; }
		public string? autofocus { get; set; }
		public string? contenteditable { get; set; }
		public string? dir { get; set; }
		public string? draggable { get; set; }
		public string? enterkeyhint { get; set; }
		public string? hidden { get; set; }
		public string? inputmode { get; set; }
		public string? @is { get; set; }
		public string? itemid { get; set; }
		public string? itemprop { get; set; }
		public string? itemref { get; set; }
		public string? itemscope { get; set; }
		public string? itemtype { get; set; }
		public string? lang { get; set; }
		public string? nonce { get; set; }
		public string? spellcheck { get; set; }
		public string? style { get; set; }
		public string? tabindex { get; set; }
		public string? title { get; set; }
		public string? translate { get; set; }
	}
}
