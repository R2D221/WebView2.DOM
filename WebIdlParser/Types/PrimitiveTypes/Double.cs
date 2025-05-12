namespace WebIdlParser
{
	internal sealed class Double : Type
	{
		private Double() : base("double") { }

		public static Double Instance { get; } = new();
	}
}