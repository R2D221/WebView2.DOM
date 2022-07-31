namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_marker_element.idl

	public enum SVGMarkerUnits : ushort
	{
		UNKNOWN = 0,
		USERSPACEONUSE = 1,
		STROKEWIDTH = 2,
	}

	public enum SVGMarkerOrientType : ushort
	{
		UNKNOWN = 0,
		AUTO = 1,
		ANGLE = 2,
	}

	public sealed partial class SVGMarkerElement : SVGElement
	{
		private SVGMarkerElement() { }

		public SVGAnimatedLength refX =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength refY =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGMarkerUnits> markerUnits =>
			GetCached<SVGAnimatedEnumeration<SVGMarkerUnits>>();
		public SVGAnimatedLength markerWidth =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedLength markerHeight =>
			GetCached<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGMarkerOrientType> orientType =>
			GetCached<SVGAnimatedEnumeration<SVGMarkerOrientType>>();
		public SVGAnimatedAngle orientAngle =>
			GetCached<SVGAnimatedAngle>();

		public void setOrientToAuto() => Method().Invoke();
		public void setOrientToAngle(SVGAngle angle) => Method().Invoke(angle);
	}

	public partial class SVGMarkerElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => GetCached<SVGAnimatedRect>();
		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => GetCached<SVGAnimatedPreserveAspectRatio>();
	}
}