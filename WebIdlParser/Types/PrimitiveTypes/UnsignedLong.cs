namespace WebIdlParser
{
	internal sealed class UnsignedLong : Type
	{
		private UnsignedLong() : base("unsigned long") { }

		public static UnsignedLong Instance { get; } = new();
	}
}