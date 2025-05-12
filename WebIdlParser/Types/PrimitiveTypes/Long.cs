namespace WebIdlParser
{
	internal sealed class Long : Type
	{
		private Long() : base("long") { }

		public static Long Instance { get; } = new();
	}
}