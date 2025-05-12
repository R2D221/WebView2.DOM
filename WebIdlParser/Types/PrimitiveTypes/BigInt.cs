namespace WebIdlParser
{
	internal sealed class BigInt : Type
	{
		private BigInt() : base("bigint") { }

		public static BigInt Instance { get; } = new();
	}
}