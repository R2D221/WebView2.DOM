namespace WebIdlParser
{
	internal sealed class UnsignedShort : Type
	{
		private UnsignedShort() : base("unsigned short") { }

		public static UnsignedShort Instance { get; } = new();
	}
}