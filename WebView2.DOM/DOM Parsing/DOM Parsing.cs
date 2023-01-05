using System.Runtime.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xml_serializer.idl

	public class XMLSerializer : JsObject
	{
		public XMLSerializer() =>
			Construct();

		public string serializeToString(Node root) =>
			Method<string>().Invoke(root);
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/parse_from_string_options.idl

	public record ParseFromStringOptions
	{
		public required bool includeShadowRoots { get; init; }
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/dom_parser.idl

	public enum SupportedType
	{
		/// <summary>
		/// text/html
		/// </summary>
		[EnumMember(Value = "text/html")] text_html,

		/// <summary>
		/// text/xml
		/// </summary>
		[EnumMember(Value = "text/xml")] text_xml,

		/// <summary>
		/// application/xml
		/// </summary>
		[EnumMember(Value = "application/xml")] application_xml,

		/// <summary>
		/// application/xhtml+xml
		/// </summary>
		[EnumMember(Value = "application/xhtml+xml")] application_xhtml_xml,

		/// <summary>
		/// image/svg+xml
		/// </summary>
		[EnumMember(Value = "image/svg+xml")] image_svg_xml,
	}

	public sealed class DOMParser : JsObject
	{
		public DOMParser() =>
			Construct();

		public Document parseFromString(string str, SupportedType type) =>
			Method<Document>().Invoke(str, type);

		public Document parseFromString(string str, SupportedType type, ParseFromStringOptions options) =>
			Method<Document>().Invoke(str, type, options);
	}
}
