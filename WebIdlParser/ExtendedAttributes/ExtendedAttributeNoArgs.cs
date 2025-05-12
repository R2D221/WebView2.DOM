using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class ExtendedAttributeNoArgs : ExtendedAttribute
	{
		private string DebuggerDisplay =>
			$"[ {Name} ]";

		public override string ToString() => DebuggerDisplay;
	}
}