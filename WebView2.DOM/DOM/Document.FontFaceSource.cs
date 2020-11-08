using System;
using System.Collections.Generic;
using System.Text;

namespace WebView2.DOM
{
	public partial class Document : FontFaceSource
	{
		public FontFaceSet fonts => Get<FontFaceSet>();
	}
}
