using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Const : Member
	{
		public required Type Type { get; init; }
		public required string Name { get; init; }
		public required string Value { get; init; }

		private string DebuggerDisplay =>
			$"const {Type} {Name} = {Value} ;";

		public override string ToString() => DebuggerDisplay;
	}
}