namespace WebView2.DOM
{
	// https://developer.mozilla.org/en-US/docs/Web/API/Transferable

	public interface Transferable { }

	public partial class ArrayBuffer : Transferable { }

	public partial class MessagePort : Transferable { }

	public partial class ImageBitmap : Transferable { }

	public partial class OffscreenCanvas : Transferable { }
}
