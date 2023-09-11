using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WebView2.DOM.Components;

internal class NodeExtraInfo
{
	private static ConditionalWeakTable<Node, NodeExtraInfo> dict = new();

	public static NodeExtraInfo For(Node node) => dict.GetValue(node, node => new(node));

	private readonly Node node;

	private NodeExtraInfo(Node node)
	{
		this.node = node;
	}

	private readonly HashSet<NodeExtraInfo> childNodes = new();

	public IEnumerable<Node> ChildNodes => childNodes.Select(x => x.node);

	public static void AppendChild(Node parent, Node child) => For(parent).childNodes.Add(For(child));
	public static void RemoveChild(Node parent, Node child) => For(parent).childNodes.Remove(For(child));

	//public bool IsEmbeddedContent =>
	//	node is
	//		SVGElement { tagName: "svg" }
	//		//or MathMLElement { tagName: "math" }
	//		or HTMLElement
	//		{
	//			tagName:
	//				"AUDIO"
	//				or "CANVAS"
	//				or "EMBED"
	//				or "IFRAME"
	//				or "IMG"
	//				or "OBJECT"
	//				or "PICTURE"
	//				or "VIDEO"
	//		};

	public bool IsPhrasingContent =>
		// link: Phrasing (if it's allowed in the body)
		node is
			Text
			//or HTMLElement { tagName: "meta", itemprop: not (null or "") }

			// Embedded content
			or SVGElement { tagName: "svg" }
			//or MathMLElement { tagName: "math" }

			or HTMLElement
			{
				tagName:

					// Embedded content
					//"AUDIO"
					//or
					//"CANVAS"
					//or
					"EMBED"
					or "IFRAME"
					or "IMG"
					//or "OBJECT"
					or "PICTURE"
					//or "VIDEO"

					or "ABBR"
					or "AREA"
					or "B"
					or "BDI"
					or "BDO"
					or "BR"
					or "BUTTON"
					or "CITE"
					or "CODE"
					or "DATA"
					or "DATALIST"
					or "DFN"
					or "EM"
					or "I"
					or "INPUT"
					or "KBD"
					or "KEYGEN"
					or "LABEL"
					or "MARK"
					or "METER"
					or "NOSCRIPT"
					or "OUTPUT"
					or "PROGRESS"
					or "Q"
					or "RUBY"
					or "S"
					or "SAMP"
					or "SCRIPT"
					or "SELECT"
					or "SLOT"
					or "SMALL"
					or "SPAN"
					or "STRONG"
					or "SUB"
					or "SUP"
					or "TEMPLATE"
					or "TEXTAREA"
					or "TIME"
					or "U"
					or "VAR"
					or "WBR"
			}
		|| IsTransparentPhrasingContent
		;

	public bool IsTransparentPhrasingContent =>
		node is HTMLElement { tagName: "A" or "INS" or "DEL" or "MAP" or "CANVAS" } ? childNodes.All(x => x.IsPhrasingContent) :
		node is HTMLElement { tagName: "AUDIO" or "VIDEO" } ? childNodes.Where(x => x.node is not HTMLElement { tagName: "TRACK" or "SOURCE" }).All(x => x.IsPhrasingContent) :
		node is HTMLElement { tagName: "OBJECT" } ? childNodes.Where(x => x.node is not HTMLElement { tagName: "PARAM" }).All(x => x.IsPhrasingContent) :
		false;

	public bool IsSectioningContent =>
		node is HTMLElement
		{
			tagName:
				"ARTICLE"
				or "ASIDE"
				or "NAV"
				or "SECTION"
		};

	public bool ContainsSectioningContent =>
		IsSectioningContent || childNodes.Any(x => x.ContainsSectioningContent);

	public bool IsHeadingContent =>
		node is HTMLElement
		{
			tagName:
				"H1"
				or "H2"
				or "H3"
				or "H4"
				or "H5"
				or "H6"
				or "HGROUP"
		};

	public bool ContainsHeadingContent =>
		IsHeadingContent || childNodes.Any(x => x.ContainsHeadingContent);

	public bool IsFlowContent =>
		IsPhrasingContent
		|| IsHeadingContent
		|| IsSectioningContent
		|| node is HTMLElement
		{
			tagName:
				"ADDRESS"
				or "BLOCKQUOTE"
				or "DETAILS"
				or "DIALOG"
				or "DIV"
				or "DL"
				or "FIELDSET"
				or "FIGURE"
				or "FOOTER"
				or "FORM"
				or "HEADER"
				or "HR"
				or "MAIN"
				or "MENU"
				or "OL"
				or "P"
				or "PRE"
				or "SEARCH"
				or "TABLE"
				or "UL"
		}
		|| IsTransparentFlowContent
		;

	public bool IsTransparentFlowContent =>
		node is HTMLElement { tagName: "A" or "INS" or "DEL" or "MAP" or "CANVAS" } ? childNodes.All(x => x.IsFlowContent) :
		node is HTMLElement { tagName: "AUDIO" or "VIDEO" } ? childNodes.Where(x => x.node is not HTMLElement { tagName: "TRACK" or "SOURCE" }).All(x => x.IsFlowContent) :
		node is HTMLElement { tagName: "OBJECT" } ? childNodes.Where(x => x.node is not HTMLElement { tagName: "PARAM" }).All(x => x.IsFlowContent) :
		false;

	public bool IsInteractiveContent =>
		node is
			HTMLAnchorElement { tagName: "A", href: { OriginalString: not (null or "") } }
			or HTMLMediaElement { controls: true }
			or HTMLElement { tagName: "BUTTON" }
			or HTMLElement { tagName: "DETAILS" }
			or HTMLElement { tagName: "EMBED" }
			or HTMLElement { tagName: "IFRAME" }
			or HTMLImageElement { tagName: "IMG", useMap: not (null or "") }
			or HTMLInputElement { tagName: "INPUT", type: not FormControlType.hidden }
			or HTMLElement { tagName: "LABEL" }
			or HTMLElement { tagName: "SELECT" }
			or HTMLElement { tagName: "TEXTAREA" }
		;

	public bool ContainsInteractiveContent =>
		IsInteractiveContent || childNodes.Any(x => x.ContainsInteractiveContent);

	public bool ContainsA =>
		node is HTMLAnchorElement || childNodes.Any(x => x.ContainsA);

	public bool ContainsAddress =>
		node is HTMLElement { tagName: "ADDRESS" } || childNodes.Any(x => x.ContainsAddress);

	public bool ContainsHeader =>
		node is HTMLElement { tagName: "HEADER" } || childNodes.Any(x => x.ContainsHeader);

	public bool ContainsFooter =>
		node is HTMLElement { tagName: "FOOTER" } || childNodes.Any(x => x.ContainsFooter);

	public bool ContainsMediaElements =>
		node is HTMLMediaElement || childNodes.Any(x => x.ContainsMediaElements);

	public bool ContainsInteractiveContentExceptForAButtonInput =>
		(IsInteractiveContent && node is not (HTMLAnchorElement or HTMLButtonElement or HTMLInputElement { type: FormControlType.checkbox or FormControlType.radio or FormControlType.button })) || childNodes.Any(x => x.ContainsInteractiveContentExceptForAButtonInput);

	public bool ContainsDfn =>
		node is HTMLElement { tagName: "DFN" } || childNodes.Any(x => x.ContainsDfn);

	public bool ContainsForm =>
		node is HTMLElement { tagName: "FORM" } || childNodes.Any(x => x.ContainsForm);

	public bool ContainsLabel =>
		node is HTMLElement { tagName: "LABEL" } || childNodes.Any(x => x.ContainsLabel);

	public bool ContainsMeter =>
		node is HTMLElement { tagName: "METER" } || childNodes.Any(x => x.ContainsMeter);

	public bool ContainsProgress =>
		node is HTMLElement { tagName: "PROGRESS" } || childNodes.Any(x => x.ContainsProgress);
}


