using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public static class HTMLElementTagExtensions
	{
		public static THTMLElement createHTMLElement<THTMLElement>(this Document document, HTMLElementTag<THTMLElement> tag)
			where THTMLElement : HTMLElement
		{
			return document.Method<THTMLElement>("createElementNS").Invoke("http://www.w3.org/1999/xhtml", tag.Name);
		}

		public static HTMLCollection<THTMLElement> getHTMLElementsByTagName<THTMLElement>(this Document document, HTMLElementTag<THTMLElement> tag)
			where THTMLElement : HTMLElement
		{
			return document.Method<HTMLCollection<THTMLElement>>("getElementsByTagNameNS").Invoke("http://www.w3.org/1999/xhtml", tag.Name);
		}

		public static HTMLCollection<THTMLElement> getHTMLElementsByTagName<THTMLElement>(this Element element, HTMLElementTag<THTMLElement> tag)
			where THTMLElement : HTMLElement
		{
			return element.Method<HTMLCollection<THTMLElement>>("getElementsByTagNameNS").Invoke("http://www.w3.org/1999/xhtml", tag.Name);
		}
	}

	public sealed class HTMLElementTag<THTMLElement> where THTMLElement : HTMLElement
	{
		public string Name { get; }

		internal HTMLElementTag(string name) => Name = name;

		public static implicit operator HTMLElementTag<THTMLElement>(HTMLElementTag tag)
		{
			return new HTMLElementTag<THTMLElement>(tag.Name);
		}
	}

	public sealed class HTMLElementTag
	{
		public string Name { get; }

		internal HTMLElementTag([CallerMemberName] string name = "") => Name = name;

		public static readonly HTMLElementTag<HTMLAnchorElement/*	*/> a/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> abbr/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> address/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLAreaElement/*	*/> area/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> article/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> aside/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLAudioElement/*	*/> audio/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> b/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLBaseElement/*	*/> @base/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> bdi/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> bdo/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLQuoteElement/*	*/> blockquote/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLBodyElement/*	*/> body/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLBRElement/*	*/> br/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLButtonElement/*	*/> button/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLCanvasElement/*	*/> canvas/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableCaptionElement/*	*/> caption/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> cite/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> code/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableColElement/*	*/> col/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableColElement/*	*/> colgroup/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDataElement/*	*/> data/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDataListElement/*	*/> datalist/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> dd/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLModElement/*	*/> del/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDetailsElement/*	*/> details/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> dfn/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDialogElement/*	*/> dialog/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDivElement/*	*/> div/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLDListElement/*	*/> dl/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> dt/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> em/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLEmbedElement/*	*/> embed/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLFieldSetElement/*	*/> fieldset/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> figcaption/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> figure/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> footer/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLFormElement/*	*/> form/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h1/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h2/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h3/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h4/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h5/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadingElement/*	*/> h6/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHeadElement/*	*/> head/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> header/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> hgroup/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHRElement/*	*/> hr/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLHtmlElement/*	*/> html/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> i/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLIFrameElement/*	*/> iframe/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLImageElement/*	*/> img/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLInputElement/*	*/> input/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLModElement/*	*/> ins/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> kbd/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLLabelElement/*	*/> label/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLLegendElement/*	*/> legend/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLLIElement/*	*/> li/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLLinkElement/*	*/> link/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> main/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLMapElement/*	*/> map/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> mark/*	*/= new HTMLElementTag();
		//public static readonly HTMLElementTag<HTMLMenuElement/*	*/> menu/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLMetaElement/*	*/> meta/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLMeterElement/*	*/> meter/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> nav/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> noscript/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLObjectElement/*	*/> @object/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLOListElement/*	*/> ol/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLOptGroupElement/*	*/> optgroup/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLOptionElement/*	*/> option/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLOutputElement/*	*/> output/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLParagraphElement/*	*/> p/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLParamElement/*	*/> param/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLPictureElement/*	*/> picture/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLPreElement/*	*/> pre/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLProgressElement/*	*/> progress/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLQuoteElement/*	*/> q/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> rp/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> rt/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> ruby/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> s/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> samp/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLScriptElement/*	*/> script/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> section/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLSelectElement/*	*/> select/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLSlotElement/*	*/> slot/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> small/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLSourceElement/*	*/> source/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLSpanElement/*	*/> span/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> strong/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLStyleElement/*	*/> style/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> sub/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> summary/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> sup/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableElement/*	*/> table/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableSectionElement/*	*/> tbody/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableCellElement/*	*/> td/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTemplateElement/*	*/> template/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTextAreaElement/*	*/> textarea/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableSectionElement/*	*/> tfoot/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableCellElement/*	*/> th/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableSectionElement/*	*/> thead/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTimeElement/*	*/> time/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTitleElement/*	*/> title/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTableRowElement/*	*/> tr/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLTrackElement/*	*/> track/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> u/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLUListElement/*	*/> ul/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> var/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLVideoElement/*	*/> video/*	*/= new HTMLElementTag();
		public static readonly HTMLElementTag<HTMLElement/*	*/> wbr/*	*/= new HTMLElementTag();
	}
}
