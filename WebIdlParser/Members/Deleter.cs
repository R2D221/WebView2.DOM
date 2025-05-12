using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Deleter : Member
	{
		public required Operation Operation { get; init; }

		private string DebuggerDisplay =>
			$"deleter {Operation}";

		public override string ToString() => DebuggerDisplay;
	}
}