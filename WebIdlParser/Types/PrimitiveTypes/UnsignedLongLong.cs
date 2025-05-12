namespace WebIdlParser
{
	internal sealed class UnsignedLongLong : Type
	{
		private UnsignedLongLong() : base("unsigned long long") { }

		public static UnsignedLongLong Instance { get; } = new();
	}
}