using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Setter : Member
	{
		public required Operation Operation { get; init; }

		private string DebuggerDisplay =>
			$"setter {Operation}";

		public override string ToString() => DebuggerDisplay;
	}
}