using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Maplike : Member
	{
		public required bool IsReadOnly { get; init; }
		public required TypeWithExtendedAttributes TKey { get; init; }
		public required TypeWithExtendedAttributes TValue { get; init; }

		private string DebuggerDisplay =>
			$"{IsReadOnly switch { true => "readonly ", false => "" }}maplike < {TKey} , {TValue} > ;";

		public override string ToString() => DebuggerDisplay;
	}
}