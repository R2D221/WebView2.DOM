using Microsoft.Web.WebView2.Core;
using NodaTime;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/idle_deadline.idl

	public class IdleDeadline : JsObject
	{
		protected internal IdleDeadline(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public Duration timeRemaining() =>
			Duration.FromNanoseconds(Math.Round(Method<double>().Invoke() * 1000) * 1000);

		public bool didTimeout => Get<bool>();
	}
}