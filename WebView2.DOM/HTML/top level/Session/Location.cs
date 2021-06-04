using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/location.idl

	public class Location : JsObject
	{
		protected internal Location(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public void assign(string url) => Method().Invoke(url);

		public void replace(string url) => Method().Invoke(url);
		public void reload() => Method().Invoke();

		public IReadOnlyList<string> ancestorOrigins => Get<ImmutableArray<string>>();

		public Uri href { get => Get<Uri>(); set => Set(value); }
		public override string ToString() => Method<string>("toString").Invoke();
		//public string origin => Get<string>();

		//public string protocol { get => Get<string>(); set => Set(value); }
		//public string host { get => Get<string>(); set => Set(value); }
		//public string hostname { get => Get<string>(); set => Set(value); }
		//public string port { get => Get<string>(); set => Set(value); }
		//public string pathname { get => Get<string>(); set => Set(value); }
		//public string search { get => Get<string>(); set => Set(value); }
		//public string hash { get => Get<string>(); set => Set(value); }
	}
}