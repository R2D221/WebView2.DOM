using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class IncludesDefinition : Definition
	{
		public required string Interface { get; init; }
		public required string Mixin { get; init; }

		private string DebuggerDisplay =>
			$"{Interface} includes {Mixin} ;";

		public override string ToString() => DebuggerDisplay;
	}
}