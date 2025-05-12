namespace WebIdlParser
{
	internal sealed class Object : Type
	{
		private Object() : base("object") { }

		public static Object Instance { get; } = new();
	}
}