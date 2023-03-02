using OneOf;
using System.Linq;

namespace WebView2.DOM
{
	public partial class Element : ParentNode
	{
		public uint childElementCount => Get<uint>();
		public HTMLCollection<Element> children => Get<HTMLCollection<Element>>();
		public Element? firstElementChild => Get<Element?>();
		public Element? lastElementChild => Get<Element?>();

		public void append(params OneOf<Node, string>[] nodes) =>
			Method().Invoke(args: nodes.Select(x => x.Value).ToArray());
		public void prepend(params OneOf<Node, string>[] nodes) =>
			Method().Invoke(args: nodes.Select(x => x.Value).ToArray());
		public Element? querySelector(string selectors) => Method<Element?>().Invoke(selectors);
		public NodeList<Element> querySelectorAll(string selectors) => Method<NodeList<Element>>().Invoke(selectors);
	}
}
