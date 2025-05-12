using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Setlike : Member
	{
		public required bool IsReadOnly { get; init; }
		public required TypeWithExtendedAttributes Type { get; init; }

		private string DebuggerDisplay =>
			$"{IsReadOnly switch { true => "readonly ", false => "" }}setlike < {Type} > ;";

		public override string ToString() => DebuggerDisplay;
	}
}