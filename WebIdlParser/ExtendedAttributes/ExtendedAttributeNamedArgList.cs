using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class ExtendedAttributeNamedArgList : ExtendedAttribute
	{
		public required string Identifier { get; init; }
		public required ImmutableArray<Argument> Arguments { get; init; }

		private string DebuggerDisplay =>
			$"[ {Name} = {Identifier} ( {string.Join(" , ", Arguments)} ) ]";

		public override string ToString() => DebuggerDisplay;
	}
}