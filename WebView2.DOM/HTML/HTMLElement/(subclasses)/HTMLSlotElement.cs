using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	public record AssignedNodesOptions
	{
		public required bool flatten { get; init; }
	}

	public sealed class HTMLSlotElement : HTMLElement
	{
		private HTMLSlotElement() { }

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
}
