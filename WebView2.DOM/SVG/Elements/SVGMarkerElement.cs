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
			Get<SVGAnimatedLength>();
		public SVGAnimatedLength refY =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGMarkerUnits> markerUnits =>
			Get<SVGAnimatedEnumeration<SVGMarkerUnits>>();
		public SVGAnimatedLength markerWidth =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedLength markerHeight =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedEnumeration<SVGMarkerOrientType> orientType =>
			Get<SVGAnimatedEnumeration<SVGMarkerOrientType>>();
		public SVGAnimatedAngle orientAngle =>
			Get<SVGAnimatedAngle>();

		public void setOrientToAuto() => Method().Invoke();
		public void setOrientToAngle(SVGAngle angle) => Method().Invoke(angle);
	}

	public partial class SVGMarkerElement : SVGFitToViewBox
	{
		public SVGAnimatedRect viewBox => Get<SVGAnimatedRect>();

		public SVGAnimatedPreserveAspectRatio preserveAspectRatio => Get<SVGAnimatedPreserveAspectRatio>();
	}
}