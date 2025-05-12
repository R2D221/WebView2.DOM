using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class InterfaceDefinition : Definition
	{
		public required string Name { get; init; }
		public required string? Inheritance { get; init; }
		public required ImmutableArray<Member> Members { get; init; }

		private string DebuggerDisplay =>
			$"interface {Name}{Inheritance switch { null => "", var x => $" : {x}" }} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}