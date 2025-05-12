namespace WebView2.DOM
{
	public class ArrayBuffer : JsObject, Transferable, BufferSource
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(ArrayBuffer));

		public ArrayBuffer(uint length) => Construct(length);

		public static bool isView(JsObject arg) =>
			Static.Method<bool>().Invoke(arg);

		public uint byteLength =>
			Get<uint>();

		public ArrayBuffer slice(uint start) =>
			Method<ArrayBuffer>().Invoke(start);

		public ArrayBuffer slice(uint start, int end) =>
			Method<ArrayBuffer>().Invoke(start, end);
	}
}
