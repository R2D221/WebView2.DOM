namespace WebView2.Markup
{
	public interface HeadingContent { }
	public interface SectioningContent { }

	public sealed class a/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { /* check docs */ }
	public sealed class area/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { /* check docs */ }
	public sealed class input/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class link/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, header_footer_Content, dtContent { /* check docs */ }
	public sealed class meta/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, header_footer_Content, dtContent { /* check docs */ }
	public sealed class audio/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class b/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class @base/*					*/: HTMLElement, MetadataContent { }
	public sealed class bdi/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class bdo/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }

	public sealed class br/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class button/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class canvas/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class caption/*					*/: HTMLElement { }
	public sealed class cite/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class code/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class col/*						*/: HTMLElement { }
	public sealed class colgroup/*				*/: HTMLElement { }
	public sealed class data/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class datalist/*				*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class del/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class details/*					*/: HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent { }
	public sealed class dfn/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class dialog/*					*/: HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent { }
	public sealed class em/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class embed/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class fieldset/*				*/: HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent { }
	public sealed class form/*					*/: HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent { }

	public sealed class i/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class iframe/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class img/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class ins/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class kbd/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class label/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class legend/*					*/: HTMLElement { }
	public sealed class map/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class mark/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }

	public sealed class math : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }


	public sealed class meter/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class noscript/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class @object/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class optgroup/*				*/: HTMLElement { }
	public sealed class option/*					*/: HTMLElement { }
	public sealed class output/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class param/*					*/: HTMLElement { }
	public sealed class picture/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class progress/*				*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class q/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class rp/*						*/: HTMLElement { }
	public sealed class rt/*						*/: HTMLElement { }
	public sealed class ruby/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class s/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class samp/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class script/*					*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class select/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class slot/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class small/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class source/*					*/: HTMLElement { }
	public sealed class span/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class strong/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class style/*					*/: HTMLElement, MetadataContent { }
	public sealed class sub/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class summary/*					*/: HTMLElement { }
	public sealed class sup/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }

	public sealed class svg : HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }

	public sealed class table/*					*/: HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent { }
	public sealed class tbody/*					*/: HTMLElement { }
	public sealed class td/*						*/: HTMLElement { }
	public sealed class template/*				*/: HTMLElement, MetadataContent, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class textarea/*				*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class tfoot/*					*/: HTMLElement { }
	public sealed class th/*						*/: HTMLElement { }
	public sealed class thead/*					*/: HTMLElement { }
	public sealed class time/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class tr/*						*/: HTMLElement { }
	public sealed class track/*					*/: HTMLElement { }
	public sealed class u/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class var/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class video/*					*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
	public sealed class wbr/*						*/: HTMLElement, PhrasingContent, addressContent, header_footer_Content, dtContent { }
}
