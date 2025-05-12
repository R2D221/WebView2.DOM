using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class CallbackInterfaceDefinition : Definition
	{
		public required string Name { get; init; }
		public required ImmutableArray<Member> Members { get; init; }

		private string DebuggerDisplay =>
			$"callback interface {Name} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}