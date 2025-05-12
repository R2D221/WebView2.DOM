using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class NamespaceDefinition : Definition
	{
		public required string Name { get; init; }
		public required ImmutableArray<Member> Members { get; init; }

		private string DebuggerDisplay =>
			$"namespace {Name} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}