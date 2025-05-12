using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class StaticMember : Member
	{
		public required Member Member { get; init; }

		private string DebuggerDisplay =>
			$"static {Member}";

		public override string ToString() => DebuggerDisplay;
	}
}