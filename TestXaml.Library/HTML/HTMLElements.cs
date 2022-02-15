namespace WebView2.Markup
{
	public interface HeadingContent { }
	public interface SectioningContent { }

	public sealed class a/*						*/: HTMLElement, PhrasingContent, addressContent { /* check docs */ }
	public sealed class area/*					*/: HTMLElement, PhrasingContent, addressContent { /* check docs */ }
	public sealed class input/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class link/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent { /* check docs */ }
	public sealed class main/*					*/: HTMLElement, FlowContent, addressContent { /* check docs */ }
	public sealed class meta/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent { /* check docs */ }

	public sealed class aside/*					*/: HTMLElement, FlowContent, SectioningContent { }
	public sealed class audio/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class b/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class @base/*					*/: HTMLElement, MetadataContent { }
	public sealed class bdi/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class bdo/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class blockquote/*				*/: HTMLElement, FlowContent, addressContent { }

	public sealed class br/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class button/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class canvas/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class caption/*					*/: HTMLElement { }
	public sealed class cite/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class code/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class col/*						*/: HTMLElement { }
	public sealed class colgroup/*				*/: HTMLElement { }
	public sealed class data/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class datalist/*				*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class dd/*						*/: HTMLElement { }
	public sealed class del/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class details/*					*/: HTMLElement, FlowContent, addressContent { }
	public sealed class dfn/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class dialog/*					*/: HTMLElement, FlowContent, addressContent { }
	public sealed class div/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class dl/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class dt/*						*/: HTMLElement { }
	public sealed class em/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class embed/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class fieldset/*				*/: HTMLElement, FlowContent, addressContent { }
	public sealed class figcaption/*				*/: HTMLElement { }
	public sealed class figure/*					*/: HTMLElement, FlowContent, addressContent { }
	public sealed class footer/*					*/: HTMLElement, FlowContent { }
	public sealed class form/*					*/: HTMLElement, FlowContent, addressContent { }
	public sealed class h1/*						*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class h2/*						*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class h3/*						*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class h4/*						*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class h5/*						*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class h6/*						*/: HTMLElement, FlowContent, HeadingContent { }

	public sealed class header/*					*/: HTMLElement, FlowContent { }
	public sealed class hgroup/*					*/: HTMLElement, FlowContent, HeadingContent { }
	public sealed class hr/*						*/: HTMLElement, FlowContent, addressContent { }

	public sealed class i/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class iframe/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class img/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class ins/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class kbd/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class label/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class legend/*					*/: HTMLElement { }
	public sealed class li/*						*/: HTMLElement { }
	public sealed class map/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class mark/*					*/: HTMLElement, PhrasingContent, addressContent { }

	public sealed class math : HTMLElement, PhrasingContent, addressContent { }

	/* menu : PhrasingContent */

	public sealed class meter/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class nav/*						*/: HTMLElement, FlowContent, SectioningContent { }
	public sealed class noscript/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent { }
	public sealed class @object/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class ol/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class optgroup/*				*/: HTMLElement { }
	public sealed class option/*					*/: HTMLElement { }
	public sealed class output/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class p/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class param/*					*/: HTMLElement { }
	public sealed class picture/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class pre/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class progress/*				*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class q/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class rp/*						*/: HTMLElement { }
	public sealed class rt/*						*/: HTMLElement { }
	public sealed class ruby/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class s/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class samp/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class script/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent { }
	public sealed class section/*					*/: HTMLElement, FlowContent, SectioningContent { }
	public sealed class select/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class slot/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class small/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class source/*					*/: HTMLElement { }
	public sealed class span/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class strong/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class style/*					*/: HTMLElement, MetadataContent { }
	public sealed class sub/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class summary/*					*/: HTMLElement { }
	public sealed class sup/*						*/: HTMLElement, PhrasingContent, addressContent { }

	public sealed class svg : HTMLElement, PhrasingContent, addressContent { }

	public sealed class table/*					*/: HTMLElement, FlowContent, addressContent { }
	public sealed class tbody/*					*/: HTMLElement { }
	public sealed class td/*						*/: HTMLElement { }
	public sealed class template/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent { }
	public sealed class textarea/*				*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class tfoot/*					*/: HTMLElement { }
	public sealed class th/*						*/: HTMLElement { }
	public sealed class thead/*					*/: HTMLElement { }
	public sealed class time/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class tr/*						*/: HTMLElement { }
	public sealed class track/*					*/: HTMLElement { }
	public sealed class u/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class ul/*						*/: HTMLElement, FlowContent, addressContent { }
	public sealed class var/*						*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class video/*					*/: HTMLElement, PhrasingContent, addressContent { }
	public sealed class wbr/*						*/: HTMLElement, PhrasingContent, addressContent { }
}
