using NodaTime;
using OverloadResolution;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window_or_worker_global_scope.idl

	public interface WindowOrWorkerGlobalScope
	{
		TimeoutID setTimeout(Action handler, Duration timeout);
		TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireStruct<TArg>? _ = null) where TArg : struct;
		TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg? arg, RequireStruct<TArg>? _ = null) where TArg : struct;
		TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireNullableClass<TArg>? _ = null) where TArg : class?;

		void clearTimeout(TimeoutID id);

		IntervalID setInterval(Action handler, Duration timeout);
		IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireStruct<TArg>? _ = null) where TArg : struct;
		IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg? arg, RequireStruct<TArg>? _ = null) where TArg : struct;
		IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireNullableClass<TArg>? _ = null) where TArg : class?;

		void clearInterval(IntervalID id);

		//// ImageBitmap
		//Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, optional ImageBitmapOptions options = {});
		//Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, int sx, int sy, int sw, int sh, optional ImageBitmapOptions options = {});

		//readonly attribute boolean crossOriginIsolated;
	}
}
