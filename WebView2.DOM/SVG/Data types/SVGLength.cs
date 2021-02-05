using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_length.idl
	
	public enum SVGLengthType : ushort
	{
		UNKNOWN = 0,
		NUMBER = 1,
		PERCENTAGE = 2,
		EMS = 3,
		EXS = 4,
		PX = 5,
		CM = 6,
		MM = 7,
		IN = 8,
		PT = 9,
		PC = 10,
	}

	public class SVGLength : JsObject
	{
		protected internal SVGLength(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGLengthType unitType => Get<SVGLengthType>();
		public float value { get => Get<float>(); set => Set(value); }
		public float valueInSpecifiedUnits { get => Get<float>(); set => Set(value); }
		public string valueAsString { get => Get<string>(); set => Set(value); }

		public void newValueSpecifiedUnits(SVGLengthType unitType, float valueInSpecifiedUnits) =>
			Method().Invoke(unitType, valueInSpecifiedUnits);
		public void convertToSpecifiedUnits(SVGLengthType unitType) =>
			Method().Invoke(unitType);
	}
}