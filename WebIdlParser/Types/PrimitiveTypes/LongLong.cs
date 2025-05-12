namespace WebIdlParser
{
	internal sealed class LongLong : Type
	{
		private LongLong() : base("long long") { }

		public static LongLong Instance { get; } = new();
	}
}