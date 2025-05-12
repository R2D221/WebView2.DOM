using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Getter : Member
	{
		public required Operation Operation { get; init; }

		private string DebuggerDisplay =>
			$"getter {Operation}";

		public override string ToString() => DebuggerDisplay;
	}
}