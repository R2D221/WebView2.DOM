namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_transform.idl

	public enum SVGTransformType : ushort
	{
		UNKNOWN = 0,
		MATRIX = 1,
		TRANSLATE = 2,
		SCALE = 3,
		ROTATE = 4,
		SKEWX = 5,
		SKEWY = 6,
	}

	public sealed class SVGTransform : JsObject
	{
		private SVGTransform() { }

		public SVGTransformType type => Get<SVGTransformType>();
		public SVGMatrix matrix => Get<SVGMatrix>();
		public float angle => Get<float>();

		public void setMatrix(SVGMatrix matrix) =>
			Method().Invoke(matrix);
		public void setTranslate(float tx, float ty) =>
			Method().Invoke(tx, ty);
		public void setScale(float sx, float sy) =>
			Method().Invoke(sx, sy);
		public void setRotate(float angle, float cx, float cy) =>
			Method().Invoke(angle, cx, cy);
		public void setSkewX(float angle) =>
			Method().Invoke(angle);
		public void setSkewY(float angle) =>
			Method().Invoke(angle);
	}
}