using NodaTime;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/window_or_worker_global_scope.idl

	public interface WindowOrWorkerGlobalScope
	{
		TimeoutID setTimeout(Action handler, Duration timeout);
		TimeoutID setTimeout<T1>(Action<T1> handler, Duration timeout, T1 arg1);
		TimeoutID setTimeout<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2);
		TimeoutID setTimeout<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3);
		TimeoutID setTimeout<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		TimeoutID setTimeout<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
		TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

		void clearTimeout(TimeoutID id);

		IntervalID setInterval(Action handler, Duration timeout);
		IntervalID setInterval<T1>(Action<T1> handler, Duration timeout, T1 arg1);
		IntervalID setInterval<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2);
		IntervalID setInterval<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3);
		IntervalID setInterval<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		IntervalID setInterval<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
		IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

		void clearInterval(IntervalID id);

		//// ImageBitmap
		//Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, optional ImageBitmapOptions options = {});
		//Promise<ImageBitmap> createImageBitmap(ImageBitmapSource imageBitmap, int sx, int sy, int sw, int sh, optional ImageBitmapOptions options = {});

		//readonly attribute boolean crossOriginIsolated;
	}
}
