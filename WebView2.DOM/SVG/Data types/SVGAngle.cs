using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_angle.idl

	public enum SVGAngleType : ushort
	{
		UNKNOWN = 0,
		UNSPECIFIED = 1,
		DEG = 2,
		RAD = 3,
		GRAD = 4,
	}

	public class SVGAngle : JsObject
	{
		protected internal SVGAngle(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAngleType unitType => Get<SVGAngleType>();
		public float value { get => Get<float>(); set => Set(value); }
		public float valueInSpecifiedUnits { get => Get<float>(); set => Set(value); }
		public string valueAsString { get => Get<string>(); set => Set(value); }

		public void newValueSpecifiedUnits(SVGAngleType unitType, float valueInSpecifiedUnits) =>
			Method().Invoke(unitType, valueInSpecifiedUnits);
		public void convertToSpecifiedUnits(SVGAngleType unitType) =>
			Method().Invoke(unitType);
	}
}