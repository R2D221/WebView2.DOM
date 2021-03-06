﻿using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_query_list.idl

	public class MediaQueryList : EventTarget
	{
		protected internal MediaQueryList(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public string media => Get<string>();
		public bool matches => Get<bool>();
		public event EventHandler<MediaQueryListEvent> onchange { add => AddEvent(value); remove => RemoveEvent(value); }
	}
}
