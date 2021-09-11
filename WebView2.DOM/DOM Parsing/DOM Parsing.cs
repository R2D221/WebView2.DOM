using Microsoft.Web.WebView2.Core;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System.Runtime.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xml_serializer.idl

	public class XMLSerializer : JsObject
	{
		protected internal XMLSerializer(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public XMLSerializer()
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct();

		public string serializeToString(Node root) =>
			Method<string>().Invoke(root);
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/parse_from_string_options.idl

	[InitOnly]
	public record ParseFromStringOptions
	{
		public bool includeShadowRoots
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= false;
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/dom_parser.idl

	public enum SupportedType
	{
		[EnumMember(Value = "text/html")] text_html,
		[EnumMember(Value = "text/xml")] text_xml,
		[EnumMember(Value = "application/xml")] application_xml,
		[EnumMember(Value = "application/xhtml+xml")] application_xhtml_xml,
		[EnumMember(Value = "image/svg+xml")] image_svg_xml,
	}

	public class DOMParser : JsObject
	{
		protected internal DOMParser(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMParser()
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct();

		public Document parseFromString(string str, SupportedType type) =>
			Method<Document>().Invoke(str, type);

		public Document parseFromString(string str, SupportedType type, ParseFromStringOptions options) =>
			Method<Document>().Invoke(str, type, options);
	}
}
