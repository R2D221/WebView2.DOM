namespace WebView2.DOM
{
	public partial class SVGGraphicsElement : SVGTests
	{
		public SVGStringList requiredExtensions => GetCached<SVGStringList>();
		public SVGStringList systemLanguage => GetCached<SVGStringList>();
	}
}