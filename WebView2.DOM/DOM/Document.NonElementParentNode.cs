using System;
using System.Collections.Generic;
using System.Text;

namespace WebView2.DOM
{
	public partial class Document : NonElementParentNode
	{
		public Element? getElementById(string elementId) => Method<Element?>().Invoke(elementId);
	}
}
