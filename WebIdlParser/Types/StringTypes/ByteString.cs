namespace WebIdlParser
{
	internal sealed class ByteString : Type
	{
		private ByteString() : base("ByteString") { }

		public static ByteString Instance { get; } = new();
	}
}