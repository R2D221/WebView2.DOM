using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	[JsonConverter(typeof(Converter))]
	public record AssignedNodesOptions : JsDictionary
	{
		private class Converter : Converter<AssignedNodesOptions> { }

		public required bool flatten
		{
			get => GetRequired<bool>();
			init => Set(value);
		}
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
