using NodaTime;
using System;

namespace WebView2.DOM
{
	public enum EventPhase : ushort
	{
		NONE = 0,
		CAPTURING_PHASE = 1,
		AT_TARGET = 2,
		BUBBLING_PHASE = 3,
	}

	public partial class Event
	{
		private protected static void GenericInvoke<TEvent>(EventTarget eventTarget, Delegate handler, TEvent args)
			where TEvent : Event
		{
			((EventHandler<TEvent>)handler).Invoke(eventTarget, args);
		}

		internal virtual void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public Duration timeStamp => Duration.FromNanoseconds(Math.Round(Get<double>() * 1000) * 1000);

		private ushort @NONE/*            */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort @CAPTURING_PHASE/* */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort @AT_TARGET/*       */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort @BUBBLING_PHASE/*  */=> throw new NotImplementedException("Implemented as an enum instead");

		public EventPhase eventPhase => Get<EventPhase>();

		private EventTarget? @srcElement => throw new NotImplementedException("legacy");

		private bool @cancelBubble
		{
			get => throw new NotImplementedException("legacy alias of .stopPropagation()");
			set => throw new NotImplementedException("legacy alias of .stopPropagation()");
		}

		public bool @returnValue
		{
			get => throw new NotImplementedException("legacy");
			set => throw new NotImplementedException("legacy");
		}

		public void @initEvent(string @type) => throw new NotImplementedException("legacy");
	}
}
