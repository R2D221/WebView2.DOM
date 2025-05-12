using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class InterfaceMixinDefinition : Definition
	{
		public required string Name { get; init; }
		public required ImmutableArray<Member> Members { get; init; }

		private string DebuggerDisplay =>
			$"interface mixin {Name} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}