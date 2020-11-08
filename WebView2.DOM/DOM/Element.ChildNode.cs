using OneOf;
using System.Linq;

namespace WebView2.DOM
{
	public partial class Element : ChildNode
	{
		public void after(params OneOf<Node, string>[] nodes) =>
			Method().Invoke(args: nodes.Select(x => x.Value).ToArray<object?>());

		public void before(params OneOf<Node, string>[] nodes) =>
			Method().Invoke(args: nodes.Select(x => x.Value).ToArray<object?>());

		public void remove() => Method().Invoke();

		public void replaceWith(params OneOf<Node, string>[] nodes) =>
			Method().Invoke(args: nodes.Select(x => x.Value).ToArray<object?>());
	}
}
