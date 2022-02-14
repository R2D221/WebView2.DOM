﻿using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(bodyChildNodes))]
	public sealed class body : HTMLElement, head_or_body
	{
		public DefaultNodeList bodyChildNodes { get; } = new();
		public override NodeList childNodes => bodyChildNodes;
	}
}