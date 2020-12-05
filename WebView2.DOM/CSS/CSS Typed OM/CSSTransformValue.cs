using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;

namespace WebView2.DOM
{
#if DEBUG
#error Iterable
#endif
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_transform_value.idl

	public class CSSTransformValue : CSSStyleValue
	{
		protected internal CSSTransformValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSTransformValue(IReadOnlyList<CSSTransformComponent> transforms)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(transforms);
		//iterable<CSSTransformComponent>;
		//readonly attribute unsigned long length;
		//getter CSSTransformComponent (unsigned long index);
		//setter CSSTransformComponent (unsigned long index, CSSTransformComponent val);

		public bool is2D => Get<bool>();
		public DOMMatrix toMatrix() => Method<DOMMatrix>().Invoke();
	}
}
