namespace WebIdlParser
{
	internal sealed class Short : Type
	{
		private Short() : base("short") { }

		public static Short Instance { get; } = new();
	}
}