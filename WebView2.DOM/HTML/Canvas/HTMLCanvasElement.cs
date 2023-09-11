using System;

namespace WebView2.DOM
{
	public interface RenderingContext { } /*(CanvasRenderingContext2D or ImageBitmapRenderingContext or WebGLRenderingContext or WebGL2RenderingContext or GPUCanvasContext)*/

	public sealed class HTMLCanvasElement : HTMLElement
	{
		private HTMLCanvasElement() { }

		public uint width { get => Get<uint>(); set => Set(value); }
		public uint height { get => Get<uint>(); set => Set(value); }

		[Obsolete("Not implemented yet", true)]
		public RenderingContext? getContext(string contextId, object? options = null) =>
			throw new NotImplementedException();

		[Obsolete("Not implemented yet", true)]
		public string toDataURL(string type = "image/png", object? quality = null) =>
			throw new NotImplementedException();

		[Obsolete("Not implemented yet", true)]
		public void toBlob(Action<Blob?> callback, string type = "image/png", object? quality = null) =>
			throw new NotImplementedException();

		[Obsolete("Not implemented yet", true)]
		public OffscreenCanvas transferControlToOffscreen() =>
			throw new NotImplementedException();
	}
}
