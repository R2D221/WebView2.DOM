using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class TypedefDefinition : Definition
	{
		public required string Name { get; init; }
		public required TypeWithExtendedAttributes Type { get; init; }

		private string DebuggerDisplay =>
			$"typedef {Type} {Name} ;";

		public override string ToString() => DebuggerDisplay;
	}
}