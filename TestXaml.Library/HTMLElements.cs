using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public interface head_or_body { }

	public sealed class a/*						*/: HTMLElement { }
	public sealed class abbr/*					*/: HTMLElement { }
	public sealed class address/*				*/: HTMLElement { }
	public sealed class area/*					*/: HTMLElement { }
	public sealed class article/*				*/: HTMLElement { }
	public sealed class aside/*					*/: HTMLElement { }
	public sealed class audio/*					*/: HTMLElement { }
	public sealed class b/*						*/: HTMLElement { }
	public sealed class @base/*					*/: HTMLElement { }
	public sealed class bdi/*						*/: HTMLElement { }
	public sealed class bdo/*						*/: HTMLElement { }
	public sealed class blockquote/*				*/: HTMLElement { }

	[ContentProperty(nameof(bodyChildNodes))]
	public sealed class body : HTMLElement, head_or_body
	{
		public DefaultNodeList bodyChildNodes { get; } = new();
		public override NodeList childNodes => bodyChildNodes;
	}

	public sealed class br/*						*/: HTMLElement { }
	public sealed class button/*					*/: HTMLElement { }
	public sealed class canvas/*					*/: HTMLElement { }
	public sealed class caption/*					*/: HTMLElement { }
	public sealed class cite/*					*/: HTMLElement { }
	public sealed class code/*					*/: HTMLElement { }
	public sealed class col/*						*/: HTMLElement { }
	public sealed class colgroup/*				*/: HTMLElement { }
	public sealed class data/*					*/: HTMLElement { }
	public sealed class datalist/*				*/: HTMLElement { }
	public sealed class dd/*						*/: HTMLElement { }
	public sealed class del/*						*/: HTMLElement { }
	public sealed class details/*					*/: HTMLElement { }
	public sealed class dfn/*						*/: HTMLElement { }
	public sealed class dialog/*					*/: HTMLElement { }
	public sealed class div/*						*/: HTMLElement { }
	public sealed class dl/*						*/: HTMLElement { }
	public sealed class dt/*						*/: HTMLElement { }
	public sealed class em/*						*/: HTMLElement { }
	public sealed class embed/*					*/: HTMLElement { }
	public sealed class fieldset/*				*/: HTMLElement { }
	public sealed class figcaption/*				*/: HTMLElement { }
	public sealed class figure/*					*/: HTMLElement { }
	public sealed class footer/*					*/: HTMLElement { }
	public sealed class form/*					*/: HTMLElement { }
	public sealed class h1/*						*/: HTMLElement { }
	public sealed class h2/*						*/: HTMLElement { }
	public sealed class h3/*						*/: HTMLElement { }
	public sealed class h4/*						*/: HTMLElement { }
	public sealed class h5/*						*/: HTMLElement { }
	public sealed class h6/*						*/: HTMLElement { }

	[ContentProperty(nameof(headChildNodes))]
	public sealed class head : HTMLElement, head_or_body
	{
		public DefaultNodeList headChildNodes { get; } = new();
		public override NodeList childNodes => headChildNodes;
	}

	public sealed class header/*					*/: HTMLElement { }
	public sealed class hgroup/*					*/: HTMLElement { }
	public sealed class hr/*						*/: HTMLElement { }

	[ContentProperty(nameof(htmlChildNodes))]
	public sealed class html : HTMLElement
	{
		public htmlNodeList htmlChildNodes { get; } = new();
		public override NodeList childNodes => htmlChildNodes;

		[ContentWrapper(typeof(head))]
		[ContentWrapper(typeof(body))]
		public sealed class htmlNodeList : NodeList
		{
			public void Add(head_or_body node) => _ = ((IList)this).Add(node);

			protected override bool Validate(Node node)
			{
				switch ((Count, node))
				{
				case (_, Text t) when string.IsNullOrWhiteSpace(t.data): return false;
				case (0, head): return true;
				case (1, body): return true;

				default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
				}
			}
		}
	}

	public sealed class i/*						*/: HTMLElement { }
	public sealed class iframe/*					*/: HTMLElement { }
	public sealed class img/*						*/: HTMLElement { }
	public sealed class input/*					*/: HTMLElement { }
	public sealed class ins/*						*/: HTMLElement { }
	public sealed class kbd/*						*/: HTMLElement { }
	public sealed class label/*					*/: HTMLElement { }
	public sealed class legend/*					*/: HTMLElement { }
	public sealed class li/*						*/: HTMLElement { }
	public sealed class link/*					*/: HTMLElement { }
	public sealed class main/*					*/: HTMLElement { }
	public sealed class map/*						*/: HTMLElement { }
	public sealed class mark/*					*/: HTMLElement { }
	public sealed class meta/*					*/: HTMLElement { }
	public sealed class meter/*					*/: HTMLElement { }
	public sealed class nav/*						*/: HTMLElement { }
	public sealed class noscript/*				*/: HTMLElement { }
	public sealed class @object/*					*/: HTMLElement { }
	public sealed class ol/*						*/: HTMLElement { }
	public sealed class optgroup/*				*/: HTMLElement { }
	public sealed class option/*					*/: HTMLElement { }
	public sealed class output/*					*/: HTMLElement { }
	public sealed class p/*						*/: HTMLElement { }
	public sealed class param/*					*/: HTMLElement { }
	public sealed class picture/*					*/: HTMLElement { }
	public sealed class pre/*						*/: HTMLElement { }
	public sealed class progress/*				*/: HTMLElement { }
	public sealed class q/*						*/: HTMLElement { }
	public sealed class rp/*						*/: HTMLElement { }
	public sealed class rt/*						*/: HTMLElement { }
	public sealed class ruby/*					*/: HTMLElement { }
	public sealed class s/*						*/: HTMLElement { }
	public sealed class samp/*					*/: HTMLElement { }
	public sealed class script/*					*/: HTMLElement { }
	public sealed class section/*					*/: HTMLElement { }
	public sealed class select/*					*/: HTMLElement { }
	public sealed class slot/*					*/: HTMLElement { }
	public sealed class small/*					*/: HTMLElement { }
	public sealed class source/*					*/: HTMLElement { }
	public sealed class span/*					*/: HTMLElement { }
	public sealed class strong/*					*/: HTMLElement { }
	public sealed class style/*					*/: HTMLElement { }
	public sealed class sub/*						*/: HTMLElement { }
	public sealed class summary/*					*/: HTMLElement { }
	public sealed class sup/*						*/: HTMLElement { }
	public sealed class table/*					*/: HTMLElement { }
	public sealed class tbody/*					*/: HTMLElement { }
	public sealed class td/*						*/: HTMLElement { }
	public sealed class template/*				*/: HTMLElement { }
	public sealed class textarea/*				*/: HTMLElement { }
	public sealed class tfoot/*					*/: HTMLElement { }
	public sealed class th/*						*/: HTMLElement { }
	public sealed class thead/*					*/: HTMLElement { }
	public sealed class time/*					*/: HTMLElement { }
	public sealed class title/*					*/: HTMLElement { }
	public sealed class tr/*						*/: HTMLElement { }
	public sealed class track/*					*/: HTMLElement { }
	public sealed class u/*						*/: HTMLElement { }
	public sealed class ul/*						*/: HTMLElement { }
	public sealed class var/*						*/: HTMLElement { }
	public sealed class video/*					*/: HTMLElement { }
	public sealed class wbr/*						*/: HTMLElement { }
}
