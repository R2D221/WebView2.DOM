﻿namespace WebView2.DOM
{
	public partial class SVGAElement : SVGURIReference
	{
		public SVGAnimatedString href => GetCached<SVGAnimatedString>();
	}
}