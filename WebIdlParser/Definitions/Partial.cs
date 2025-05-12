using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Partial : Definition
	{
		public required Definition Definition { get; init; }

		private string DebuggerDisplay =>
			$"partial {Definition}";

		public override string ToString() => DebuggerDisplay;
	}
}