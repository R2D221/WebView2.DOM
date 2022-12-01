﻿using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The strong element represents strong importance, seriousness, or urgency for its contents.
	/// </summary>
	[ContentProperty(nameof(strongChildNodes))]
	public sealed class strong : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public strong() { strongChildNodes = new(this); }
		public PhrasingContentNodeList strongChildNodes { get; }
		public override NodeList childNodes => strongChildNodes;
	}
}