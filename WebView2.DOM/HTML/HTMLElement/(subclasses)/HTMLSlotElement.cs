using SmartAnalyzers.CSharpExtensions.Annotations;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	[InitOnly]
	public record AssignedNodesOptions
	{
		public bool flatten
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= false;
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
