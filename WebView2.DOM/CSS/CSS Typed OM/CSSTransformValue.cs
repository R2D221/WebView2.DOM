namespace WebView2.DOM
{
	public class CSSTransformValue : CSSStyleValue
	{
#if DEBUG
#error Iterable
#endif
		// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_transform_value.idl

		//[RaisesException] constructor(sequence<CSSTransformComponent> transforms);
		//iterable<CSSTransformComponent>;
		//readonly attribute unsigned long length;
		//getter CSSTransformComponent (unsigned long index);
		//[RaisesException] setter CSSTransformComponent (unsigned long index, CSSTransformComponent val);

		//readonly attribute boolean is2D;
		//[RaisesException] DOMMatrix toMatrix();
	}
}
