﻿using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/events/event.idl

	public enum EventPhase : ushort
	{
		NONE/*	*/= 0,
		CAPTURING_PHASE/*	*/= 1,
		AT_TARGET/*	*/= 2,
		BUBBLING_PHASE/*	*/= 3,
	}

	public class Event : JsObject
	{
		private protected Event() { }

		private protected static void GenericInvoke<TEvent>(EventTarget eventTarget, Delegate handler, TEvent args)
			where TEvent : Event
		{
			((EventHandler<TEvent>)handler).Invoke(eventTarget, args);
		}

		internal virtual void Invoke(EventTarget eventTarget, Delegate handler) =>
			GenericInvoke(eventTarget, handler, this);

		public string type => Get<string>();
		public EventTarget? target => Get<EventTarget?>();
		public EventTarget? currentTarget => Get<EventTarget?>();
		public IReadOnlyList<EventTarget> composedPath() => Method<ImmutableArray<EventTarget>>().Invoke();

		public EventPhase eventPhase => Get<EventPhase>();

		public void stopPropagation() => Method().Invoke();
		public void stopImmediatePropagation() => Method().Invoke();

		public bool bubbles => Get<bool>();
		public bool cancelable => Get<bool>();
		public void preventDefault() => Method().Invoke();
		public bool defaultPrevented => Get<bool>();

		public bool composed => Get<bool>();

		public bool isTrusted => Get<bool>();

		public Duration timeStamp => Duration.FromNanoseconds(Math.Round(Get<double>() * 1000) * 1000);

		// Non-standard APIs
		//public EventTarget srcElement => Get<EventTarget>();
		//public bool returnValue { get => Get<bool>(); set => Set(value); }
		//public bool cancelBubble { get => Get<bool>(); set => Set(value); }
		//public IReadOnlyList<EventTarget> path => Get<ImmutableArray<EventTarget>>();
	}
}