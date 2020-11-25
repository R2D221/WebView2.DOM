using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class CSSUnparsedValue : CSSStyleValue
	{
		protected internal CSSUnparsedValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

#if DEBUG
#error Iterable
#endif
		/*
		constructor(sequence<CSSUnparsedSegment> members);
		iterable<CSSUnparsedSegment>;
		readonly attribute unsigned long length;
		[RaisesException] getter CSSUnparsedSegment (unsigned long index);
		[RaisesException] setter CSSUnparsedSegment (unsigned long index, CSSUnparsedSegment val);

		typedef (DOMString or CSSVariableReferenceValue) CSSUnparsedSegment;
		*/
	}
}
