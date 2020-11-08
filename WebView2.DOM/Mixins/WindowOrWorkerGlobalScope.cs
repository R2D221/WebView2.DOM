namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window_or_worker_global_scope.idl

	public interface WindowOrWorkerGlobalScope
	{
		//// ImageBitmap
		//[CallWith=ScriptState, RaisesException] Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, optional ImageBitmapOptions options = {});
		//[CallWith=ScriptState, RaisesException] Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, long sx, long sy, long sw, long sh, optional ImageBitmapOptions options = {});

		//readonly attribute boolean crossOriginIsolated;
	}
}
