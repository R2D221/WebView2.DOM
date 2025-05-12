using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class ExtendedAttributeIdent : ExtendedAttribute
	{
		public required string Identifier { get; init; }

		private string DebuggerDisplay =>
			$"[ {Name} = {Identifier} ]";

		public override string ToString() => DebuggerDisplay;
	}
}