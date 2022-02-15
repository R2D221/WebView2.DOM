namespace WebView2.Markup
{
	public interface HeadingContent { }
	public interface SectioningContent { }

	public sealed class a/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { /* check docs */ }
	public sealed class area/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { /* check docs */ }
	public sealed class input/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class link/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, headerContent_footerContent { /* check docs */ }
	public sealed class main/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { /* check docs */ }
	public sealed class meta/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, headerContent_footerContent { /* check docs */ }
	public sealed class audio/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class b/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class @base/*					*/: HTMLElement, MetadataContent { }
	public sealed class bdi/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class bdo/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class blockquote/*				*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }

	public sealed class br/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class button/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class canvas/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class caption/*					*/: HTMLElement { }
	public sealed class cite/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class code/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class col/*						*/: HTMLElement { }
	public sealed class colgroup/*				*/: HTMLElement { }
	public sealed class data/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class datalist/*				*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class dd/*						*/: HTMLElement { }
	public sealed class del/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class details/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class dfn/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class dialog/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class div/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class dl/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class dt/*						*/: HTMLElement { }
	public sealed class em/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class embed/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class fieldset/*				*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class figcaption/*				*/: HTMLElement { }
	public sealed class figure/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class form/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class hr/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }

	public sealed class i/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class iframe/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class img/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class ins/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class kbd/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class label/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class legend/*					*/: HTMLElement { }
	public sealed class li/*						*/: HTMLElement { }
	public sealed class map/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class mark/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }

	public sealed class math : HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }

	/* menu : PhrasingContent */

	public sealed class meter/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class noscript/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class @object/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class ol/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class optgroup/*				*/: HTMLElement { }
	public sealed class option/*					*/: HTMLElement { }
	public sealed class output/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class p/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class param/*					*/: HTMLElement { }
	public sealed class picture/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class pre/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class progress/*				*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class q/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class rp/*						*/: HTMLElement { }
	public sealed class rt/*						*/: HTMLElement { }
	public sealed class ruby/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class s/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class samp/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class script/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class select/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class slot/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class small/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class source/*					*/: HTMLElement { }
	public sealed class span/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class strong/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class style/*					*/: HTMLElement, MetadataContent { }
	public sealed class sub/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class summary/*					*/: HTMLElement { }
	public sealed class sup/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }

	public sealed class svg : HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }

	public sealed class table/*					*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class tbody/*					*/: HTMLElement { }
	public sealed class td/*						*/: HTMLElement { }
	public sealed class template/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class textarea/*				*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class tfoot/*					*/: HTMLElement { }
	public sealed class th/*						*/: HTMLElement { }
	public sealed class thead/*					*/: HTMLElement { }
	public sealed class time/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class tr/*						*/: HTMLElement { }
	public sealed class track/*					*/: HTMLElement { }
	public sealed class u/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class ul/*						*/: HTMLElement, FlowContent, addressContent, headerContent_footerContent { }
	public sealed class var/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class video/*					*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
	public sealed class wbr/*						*/: HTMLElement, PhrasingContent, addressContent, headerContent_footerContent { }
}
