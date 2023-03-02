using NodaTime;
using OverloadResolution;
using System;

namespace WebView2.DOM
{
	public partial class Window : WindowOrWorkerGlobalScope
	{
		public TimeoutID setTimeout(Action handler, Duration timeout) =>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds);
		public TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireStruct<TArg>? _ = null)
			where TArg : struct
			=>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg);
		public TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg? arg, RequireStruct<TArg>? _ = null)
			where TArg : struct
			=>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg);
		public TimeoutID setTimeout<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireNullableClass<TArg>? _ = null)
			where TArg : class?
			=>
			Method<TimeoutID>().Invoke(handler, timeout.TotalMilliseconds, arg);

		public void clearTimeout(TimeoutID id) =>
			Method().Invoke(id);

		public IntervalID setInterval(Action handler, Duration timeout) =>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds);
		public IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireStruct<TArg>? _ = null)
			where TArg : struct
			=>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg);
		public IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg? arg, RequireStruct<TArg>? _ = null)
			where TArg : struct
			=>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg);
		public IntervalID setInterval<TArg>(Action<TArg> handler, Duration timeout, TArg arg, RequireNullableClass<TArg>? _ = null)
			where TArg : class?
			=>
			Method<IntervalID>().Invoke(handler, timeout.TotalMilliseconds, arg);

		public void clearInterval(IntervalID id) =>
			Method().Invoke(id);
	}
}
