using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Attribute : Member
	{
		public required TypeWithExtendedAttributes Type { get; init; }
		public required string Name { get; init; }
		public required bool IsReadOnly { get; init; }

		protected virtual string DebuggerDisplay =>
			$"{IsReadOnly switch { true => "readonly ", false => "" }}attribute {Type} {Name} ";

		public override string ToString() => DebuggerDisplay;
	}
}