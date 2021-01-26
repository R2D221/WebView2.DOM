using NodaTime;
using System;

namespace WebView2.DOM
{
	public partial class Window : WindowOrWorkerGlobalScope
	{
		public TimeoutID setTimeout(Action handler, Duration timeout) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds);
		public TimeoutID setTimeout<T1>(Action<T1> handler, Duration timeout, T1 arg1) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1);
		public TimeoutID setTimeout<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2);
		public TimeoutID setTimeout<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3);
		public TimeoutID setTimeout<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		public TimeoutID setTimeout<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

		public void clearTimeout(TimeoutID id) =>
			Method().Invoke(id);

		public IntervalID setInterval(Action handler, Duration timeout) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds);
		public IntervalID setInterval<T1>(Action<T1> handler, Duration timeout, T1 arg1) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1);
		public IntervalID setInterval<T1, T2>(Action<T1, T2> handler, Duration timeout, T1 arg1, T2 arg2) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2);
		public IntervalID setInterval<T1, T2, T3>(Action<T1, T2, T3> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3);
		public IntervalID setInterval<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4);
		public IntervalID setInterval<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		public IntervalID setInterval<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler, Duration timeout, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

		public void clearInterval(IntervalID id) =>
			Method().Invoke(id);
	}
}
