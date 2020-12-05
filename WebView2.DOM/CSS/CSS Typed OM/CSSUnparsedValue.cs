using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
#if DEBUG
#error Iterable
#endif

	public class CSSUnparsedValue : CSSStyleValue
	{
		protected internal CSSUnparsedValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		/*
		constructor(sequence<CSSUnparsedSegment> members);
		iterable<CSSUnparsedSegment>;
		readonly attribute unsigned long length;
		getter CSSUnparsedSegment (unsigned long index);
		setter CSSUnparsedSegment (unsigned long index, CSSUnparsedSegment val);

		typedef (DOMString or CSSVariableReferenceValue) CSSUnparsedSegment;
		*/
	}
}
