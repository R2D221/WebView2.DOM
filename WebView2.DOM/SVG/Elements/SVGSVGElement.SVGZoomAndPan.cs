namespace WebView2.DOM
{
	public partial class SVGSVGElement : SVGZoomAndPan
	{
		public SVGZoomAndPanType zoomAndPan
		{
			get => Get<SVGZoomAndPanType>();
			set => Set(value);
		}
	}
}
