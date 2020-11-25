using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/events/security_policy_violation_event.idl

	public enum SecurityPolicyViolationEventDisposition
	{
		enforce, report
	}

	public class SecurityPolicyViolationEvent : Event
	{
		protected internal SecurityPolicyViolationEvent(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string documentURI => Get<string>();
		public string referrer => Get<string>();
		public string blockedURI => Get<string>();
		public string violatedDirective => Get<string>();
		public string effectiveDirective => Get<string>();
		public string originalPolicy => Get<string>();
		public SecurityPolicyViolationEventDisposition disposition => Get<SecurityPolicyViolationEventDisposition>();
		public string sourceFile => Get<string>();
		public ushort statusCode => Get<ushort>();
		public long lineNumber => Get<long>();
		public long columnNumber => Get<long>();
		public string sample => Get<string>();
	}
}