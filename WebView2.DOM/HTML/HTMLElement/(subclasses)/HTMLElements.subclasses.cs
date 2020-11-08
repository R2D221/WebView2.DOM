using NodaTime;
using OneOf;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Data;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	#region canvas
	public class HTMLCanvasElement : HTMLElement { }
	#endregion

	#region forms
	public class HTMLButtonElement : HTMLElement { }
	public class HTMLDataListElement : HTMLElement { }
	public class HTMLFieldSetElement : HTMLElement { }
	public class HTMLFormElement : HTMLElement { }
	public class HTMLInputElement : HTMLElement { }
	public class HTMLLabelElement : HTMLElement { }
	public class HTMLLegendElement : HTMLElement { }
	public class HTMLOptGroupElement : HTMLElement { }
	public class HTMLOptionElement : HTMLElement { }
	public class HTMLOutputElement : HTMLElement { }
	public class HTMLSelectElement : HTMLElement { }
	public class HTMLTextAreaElement : HTMLElement { }

	#endregion

	#region portal
	//public class HTMLPortalElement : HTMLElement { }
	#endregion

	public enum ReferrerPolicy
	{
		_,
		no_referrer,
		no_referrer_when_downgrade,
		same_origin,
		origin,
		strict_origin,
		origin_when_cross_origin,
		strict_origin_when_cross_origin,
		unsafe_url,
	}

	public sealed class HTMLAnchorElement : HTMLElement
	{
		// HTMLAnchorElement includes HTMLHyperlinkElementUtils
		public Uri href { get => Get<Uri>(); set => Set(value); }

		public string target { get => Get<string>(); set => Set(value); }
		public string download { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<Uri> ping
		{
			get => Get<string>().Trim()
				.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
				.Select(x => new Uri(x))
				.ToImmutableArray()
				;
			set => Set(string.Join(' ', value));
		}
		public string rel { get => Get<string>(); set => Set(value); }
		public DOMTokenList relList => _relList ??= Get<DOMTokenList>();
		private DOMTokenList? _relList;
		public string hreflang { get => Get<string>(); set => Set(value); }
		public string hrefTranslate { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }

		public string text { get => Get<string>(); set => Set(value); }

		// Conversion Measurement
		//public string impressionData { get => Get<string>(); set => Set(value); }
		//public string conversionDestination { get => Get<string>(); set => Set(value); }
		//public string reportingOrigin { get => Get<string>(); set => Set(value); }
		//public string impressionExpiry { get => Get<string>(); set => Set(value); }
	}

	public enum Shape { _, circle, @default, poly, rect }

	public sealed class HTMLAreaElement : HTMLElement
	{
		// HTMLAnchorElement includes HTMLHyperlinkElementUtils
		public Uri href { get => Get<Uri>(); set => Set(value); }

		public string alt { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<double> coords
		{
			get => Get<string>().Trim()
				.Split(',')
				.Select(x => double.Parse(x, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, CultureInfo.InvariantCulture))
				.ToImmutableArray();
			set => Set(string.Join(',', value.Select(x => x.ToString(CultureInfo.InvariantCulture))));
		}
		public string download { get => Get<string>(); set => Set(value); }
		public Shape shape { get => Get<Shape>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<Uri> ping
		{
			get => Get<string>().Trim()
				.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
				.Select(x => new Uri(x))
				.ToImmutableArray()
				;
			set => Set(string.Join(' ', value));
		}
		public string rel { get => Get<string>(); set => Set(value); }
		public DOMTokenList relList => _relList ??= Get<DOMTokenList>();
		private DOMTokenList? _relList;
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
	}

	public class HTMLBaseElement : HTMLElement
	{
		public Uri href { get => Get<Uri>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }
	}

	public partial class HTMLBodyElement : HTMLElement { }

	public partial class HTMLBodyElement : WindowEventHandlers
	{
		public event EventHandler<Event/*	*/> onafterprint/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onbeforeprint/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<HashChangeEvent/*	*/> onhashchange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onlanguagechange/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<MessageEvent/*	*/> onmessage/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<MessageEvent/*	*/> onmessageerror/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onoffline/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> ononline/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PageTransitionEvent/*	*/> onpagehide/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PageTransitionEvent/*	*/> onpageshow/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PopStateEvent/*	*/> onpopstate/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PromiseRejectionEvent/*	*/> onrejectionhandled/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<StorageEvent/*	*/> onstorage/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<PromiseRejectionEvent/*	*/> onunhandledrejection/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
		public event EventHandler<Event/*	*/> onunload/*	*/{ add => AddEvent(value); remove => RemoveEvent(value); }
	}

	public class HTMLBRElement : HTMLElement { }

	public class HTMLDataElement : HTMLElement
	{
		public string value { get => Get<string>(); set => Set(value); }
	}

	public class HTMLDetailsElement : HTMLElement
	{
		public bool open { get => Get<bool>(); set => Set(value); }
	}

	public class HTMLDialogElement : HTMLElement
	{
		public bool open { get => Get<bool>(); set => Set(value); }
		public string returnValue { get => Get<string>(); set => Set(value); }
		public void show() => Method().Invoke();
		public void showModal() => Method().Invoke();
		public void close() => Method().Invoke();
		public void close(string returnValue) => Method().Invoke(returnValue);
	}

	public class HTMLDivElement : HTMLElement { }

	public class HTMLDListElement : HTMLElement { }

	public class HTMLEmbedElement : HTMLElement
	{
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public Document? getSVGDocument() => Method<Document?>().Invoke();
	}

	public class HTMLHeadElement : HTMLElement { }

	public class HTMLHeadingElement : HTMLElement { }

	public class HTMLHRElement : HTMLElement { }

	public class HTMLHtmlElement : HTMLElement { }

	public enum LazyLoading { _, lazy, eager }

	public class HTMLIFrameElement : HTMLElement
	{
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string srcdoc { get => Get<string>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public DOMTokenList sandbox => Get<DOMTokenList>();
		public bool allowFullscreen{ get => Get<bool>(); set => Set(value); }
		public bool disallowDocumentAccess { get => Get<bool>(); set => Set(value); }
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }

		public Document? contentDocument => Get<Document?>();
		public Window? contentWindow => Get<Window?>();
		public Document? getSVGDocument() => Method<Document?>().Invoke();
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		// https://w3c.github.io/webappsec-csp/embedded/#dom-htmliframeelement-csp
		public string csp { get => Get<string>(); set => Set(value); }

		// Feature Policy
		//[CEReactions, Reflect] attribute DOMString allow;
		//// https://w3c.github.io/webappsec-feature-policy/#the-policy-object
		//readonly attribute FeaturePolicy featurePolicy;

		//// Document Policy
		//[RuntimeEnabled=DocumentPolicyNegotiation, CEReactions, Reflect] attribute DOMString policy;

		public LazyLoading loading { get => Get<LazyLoading>(); set => Set(value); }

		//// Trust Tokens request parameters (https://github.com/wicg/trust-token-api)
		//[RuntimeEnabled=TrustTokens, SecureContext, Reflect, MeasureAs=TrustTokenIframe] attribute DOMString trustToken;
	}

	public enum CrossOrigin { _, anonymous, use_credentials }

	public enum ImageDecodingHint { _, async, sync, auto }

	public class HTMLImageElement : HTMLElement
	{
		public string alt { get => Get<string>(); set => Set(value); }
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public IReadOnlyList<SrcSetItem> srcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string sizes { get => Get<string>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string useMap { get => Get<string>(); set => Set(value); }
		public bool isMap { get => Get<bool>(); set => Set(value); }
		public uint width { get => Get<uint>(); set => Set(value); }
		public uint height { get => Get<uint>(); set => Set(value); }
		public uint naturalWidth => Get<uint>();
		public uint naturalHeight => Get<uint>();
		public bool complete => Get<bool>();
		public Uri currentSrc => Get<Uri>();
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		public ImageDecodingHint decoding { get => Get<ImageDecodingHint>(); set => Set(value); }
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;
		public LazyLoading loading { get => Get<LazyLoading>(); set => Set(value); }

		// CSSOM View Module
		public int x => Get<int>();
		public int y => Get<int>();

		public Task decode() => Get<Task>();
	}

	public class HTMLLIElement : HTMLElement
	{
		public int value { get => Get<int>(); set => Set(value); }
	}

	public enum PotentialDestination { _, script, style, image, track, font, fetch }

	public class HTMLLinkElement : HTMLElement
	{
		public bool disabled { get => Get<bool>(); set => Set(value); }
		public Uri href { get => Get<Uri>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string rel { get => Get<string>(); set => Set(value); }
		public DOMTokenList relList => _relList ??= Get<DOMTokenList>();
		private DOMTokenList? _relList;
		public string media { get => Get<string>(); set => Set(value); }
		public string hreflang { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public PotentialDestination @as { get => Get<PotentialDestination>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		public DOMTokenList sizes => Get<DOMTokenList>();
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;
		public IReadOnlyList<SrcSetItem> imageSrcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string imageSizes { get => Get<string>(); set => Set(value); }

		// HTMLLinkElement includes LinkStyle
		public StyleSheet? sheet => Get<StyleSheet?>();

		// Subresource Integrity
		public string integrity { get => Get<string>(); set => Set(value); }

		// Subresource loading with Web Bundles
		//[RuntimeEnabled=SubresourceWebBundles, PutForwards=value] readonly attribute DOMTokenList resources;
	}

	public class HTMLMapElement : HTMLElement
	{
		public string name { get => Get<string>(); set => Set(value); }
		public HTMLCollection<HTMLAreaElement> areas => Get<HTMLCollection<HTMLAreaElement>>();
	}

	public class HTMLMetaElement : HTMLElement
	{
		public string name { get => Get<string>(); set => Set(value); }
		public string httpEquiv { get => Get<string>(); set => Set(value); }
		public string content { get => Get<string>(); set => Set(value); }
	}

	public class HTMLMeterElement : HTMLElement
	{
		public double value { get => Get<double>(); set => Set(value); }
		public double min { get => Get<double>(); set => Set(value); }
		public double max { get => Get<double>(); set => Set(value); }
		public double low { get => Get<double>(); set => Set(value); }
		public double high { get => Get<double>(); set => Set(value); }
		public double optimum { get => Get<double>(); set => Set(value); }
		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}

	public class HTMLModElement : HTMLElement
	{
		public Uri cite { get => Get<Uri>(); set => Set(value); }
		public string dateTime
		{
			get => Get<string>();
			set => Set(value);
		}
		public OneOf<LocalDate, LocalTime, OffsetDateTime, Null> dateTimeValue
		{
			get => DatesAndTimes.HTMLModElement_dateTime_Parse(dateTime);
			set => dateTime = DatesAndTimes.HTMLModElement_dateTime_Format(value);
		}
	}

	public class HTMLObjectElement : HTMLElement
	{
		public Uri data { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public string useMap { get => Get<string>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public Document? contentDocument => Get<Document?>();
		public Window? contentWindow => Get<Window?>();
		public Document? getSVGDocument() => Method<Document?>().Invoke();

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);
	}

	public class HTMLOListElement : HTMLElement
	{
		public bool reversed { get => Get<bool>(); set => Set(value); }
		public int start { get => Get<int>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
	}

	public class HTMLParagraphElement : HTMLElement { }

	public class HTMLParamElement : HTMLElement
	{
		public string name { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }
	}

	public class HTMLPictureElement : HTMLElement { }

	public class HTMLPreElement : HTMLElement { }

	public class HTMLProgressElement : HTMLElement
	{
		public double value { get => Get<double>(); set => Set(value); }
		public double max { get => Get<double>(); set => Set(value); }
		public double position => Get<double>();
		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}

	public class HTMLQuoteElement : HTMLElement
	{
		public Uri cite { get => Get<Uri>(); set => Set(value); }
	}

	public class HTMLScriptElement : HTMLElement
	{
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public bool noModule { get => Get<bool>(); set => Set(value); }
		public string charset { get => Get<string>(); set => Set(value); }
		public bool async { get => Get<bool>(); set => Set(value); }
		public bool defer { get => Get<bool>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string text { get => Get<string>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;

		// Subresource Integrity
		public string integrity { get => Get<string>(); set => Set(value); }
	}

	public struct AssignedNodesOptions
	{
		public bool flatten { get; set; }
	}

	public class HTMLSlotElement : HTMLElement
	{
		public string name { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<Node> assignedNodes() =>
			Method<ImmutableArray<Node>>().Invoke();
		public IReadOnlyList<Node> assignedNodes(AssignedNodesOptions options) =>
			Method<ImmutableArray<Node>>().Invoke(options);
		public IReadOnlyList<Element> assignedElements() =>
			Method<ImmutableArray<Element>>().Invoke();
		public IReadOnlyList<Element> assignedElements(AssignedNodesOptions options) =>
			Method<ImmutableArray<Element>>().Invoke(options);
		public void assign(IReadOnlyList<Node> nodes) =>
			Method().Invoke(nodes);
	}

#warning This should be a record
	public struct SrcSetItem
	{
		public Uri src { get; set; }
		public int? width { get; set; }
		public double? density { get; set; }

		public static IReadOnlyList<SrcSetItem> Parse(string value) =>
			value.Split(',')
			.Select(item => item.Trim())
			.Select(item => item.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries))
			.Select(parts => new SrcSetItem
			{
				src = new Uri(parts[0], UriKind.RelativeOrAbsolute),
				width =
					parts.Length > 1 && parts[1].EndsWith("w") ? int.Parse(parts[1][0..^1], NumberStyles.None, CultureInfo.InvariantCulture) :
					default(int?),
				density =
					parts.Length > 2 && parts[2].EndsWith("x") ? double.Parse(parts[2][0..^1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) :
					parts.Length > 1 && parts[1].EndsWith("x") ? double.Parse(parts[1][0..^1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) :
					default(double?),
			})
			.ToImmutableArray();

		public static string ToString(IReadOnlyList<SrcSetItem> value) =>
			string.Join(",",
				value.Select(item => new[]
				{
					item.src.ToString(),
					item.width?.ToString(CultureInfo.InvariantCulture),
					item.density?.ToString(CultureInfo.InvariantCulture)
				}.Where(x => x != null))
				.Select(parts => string.Join(' ', parts))
			);
	}

	public class HTMLSourceElement : HTMLElement
	{
		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }

		public IReadOnlyList<SrcSetItem> srcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string sizes { get => Get<string>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
	}

	public class HTMLSpanElement : HTMLElement { }

	public class HTMLStyleElement : HTMLElement
	{
		public bool disabled { get => Get<bool>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }

		public StyleSheet? sheet => Get<StyleSheet?>();
	}

	public class HTMLTableCaptionElement : HTMLElement { }

	public enum TableHeaderCellScope { _, row, col, rowgroup, colgroup }

	public class HTMLTableCellElement : HTMLElement
	{
		public uint colSpan { get => Get<uint>(); set => Set(value); }
		public uint rowSpan { get => Get<uint>(); set => Set(value); }
		public string headers { get => Get<string>(); set => Set(value); }
		public int cellIndex => Get<int>();

		public string abbr { get => Get<string>(); set => Set(value); }
		public TableHeaderCellScope scope { get => Get<TableHeaderCellScope>(); set => Set(value); }
	}

	public class HTMLTableColElement : HTMLElement
	{
		public uint span { get => Get<uint>(); set => Set(value); }
	}

	public class HTMLTableElement : HTMLElement
	{
		public HTMLTableCaptionElement? caption { get => Get<HTMLTableCaptionElement?>(); set => Set(value); }
		public HTMLTableCaptionElement createCaption() => Method<HTMLTableCaptionElement>().Invoke();
		public void deleteCaption() => Method().Invoke();
		public HTMLTableSectionElement? tHead { get => Get<HTMLTableSectionElement?>(); set => Set(value); }
		public HTMLTableSectionElement createTHead() => Method<HTMLTableSectionElement>().Invoke();
		public void deleteTHead() => Method().Invoke();
		public HTMLTableSectionElement? tFoot { get => Get<HTMLTableSectionElement?>(); set => Set(value); }
		public HTMLTableSectionElement createTFoot() => Method<HTMLTableSectionElement>().Invoke();
		public void deleteTFoot() => Method().Invoke();
		public HTMLCollection<HTMLTableSectionElement> tBodies => Get<HTMLCollection<HTMLTableSectionElement>>();
		public HTMLTableSectionElement createTBody() => Method<HTMLTableSectionElement>().Invoke();
		public HTMLCollection<HTMLTableRowElement> rows => Get<HTMLCollection<HTMLTableRowElement>>();
		public HTMLTableRowElement insertRow(int index = -1) => Method<HTMLTableRowElement>().Invoke(index);
		public void deleteRow(int index) => Method().Invoke(index);
		// attribute boolean sortable;
		// void stopSorting();
	}

	public class HTMLTableRowElement : HTMLElement
	{
		public int rowIndex => Get<int>();
		public int sectionRowIndex => Get<int>();
		public HTMLCollection<HTMLTableCellElement> cells => Get<HTMLCollection<HTMLTableCellElement>>();
		public HTMLTableCellElement insertCell(int index = -1) => Method<HTMLTableCellElement>().Invoke(index);
		public void deleteCell(int index) => Method().Invoke(index);
	}

	public class HTMLTableSectionElement : HTMLElement
	{
		public HTMLCollection<HTMLTableRowElement> rows => Get<HTMLCollection<HTMLTableRowElement>>();
		public HTMLTableRowElement insertRow(int index = -1) => Method<HTMLTableRowElement>().Invoke(index);
		public void deleteRow(int index) => Method().Invoke(index);
	}

	public class HTMLTemplateElement : HTMLElement
	{
		public DocumentFragment content => Get<DocumentFragment>();
		// readonly attribute ShadowRoot? shadowRoot;
	}

	public class HTMLTimeElement : HTMLElement
	{
		public string dateTime
		{
			get => Get<string>();
			set => Set(value);
		}

		public OneOf<YearMonth, LocalDate, AnnualDate, LocalTime, LocalDateTime, Offset, OffsetDateTime, IsoWeek, Year, Period, Null> dateTimeValue
		{
			get => DatesAndTimes.HTMLTimeElement_dateTime_Parse(
					Get<string>("dateTime") is string dateTime && !string.IsNullOrEmpty(dateTime)
					? dateTime
					: innerText
				);

			set
			{
				var formatted = DatesAndTimes.HTMLTimeElement_dateTime_Format(value);

				bool isDateTimeEmpty = string.IsNullOrEmpty(dateTime);
				bool isInnerTextEmpty = string.IsNullOrEmpty(innerText);

				if (isDateTimeEmpty && !isInnerTextEmpty)
				{
					Set(formatted, property: "innerText");
				}
				else
				{
					Set(formatted, property: "dateTime");
				}
			}
		}
	}

	public class HTMLTitleElement : HTMLElement
	{
		public string text { get => Get<string>(); set => Set(value); }
	}

	public class HTMLUListElement : HTMLElement
	{
		public string text { get => Get<string>(); set => Set(value); }
	}

	public class HTMLUnknownElement : HTMLElement { }
}
