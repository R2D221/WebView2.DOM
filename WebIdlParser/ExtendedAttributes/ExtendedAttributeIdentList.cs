using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class ExtendedAttributeIdentList : ExtendedAttribute
	{
		public required ImmutableArray<string> Identifiers { get; init; }

		private string DebuggerDisplay =>
			$"[ {Name} = ( {string.Join(" , ", Identifiers)} ) ]";

		public override string ToString() => DebuggerDisplay;
	}
}