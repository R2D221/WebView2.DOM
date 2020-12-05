using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/navigator.idl

	public class Navigator : JsObject
	{
		protected internal Navigator(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		[Obsolete("The value of the Navigator.vendorSub property is always the empty string, in any browser.")]
		public string vendorSub => Get<string>();

		[Obsolete("On Apple Safari and Google Chrome this property always returns 20030107.")]
		public string productSub => Get<string>();

		[Obsolete("The value of the Navigator.vendor property is always \"Google Inc.\".")]
		public string vendor => Get<string>();

		//Navigator includes NavigatorConcurrentHardware;

		public ulong hardwareConcurrency => Get<ulong>();

		//Navigator includes NavigatorCookies;

		public bool cookieEnabled => Get<bool>();

		//Navigator includes NavigatorDeviceMemory;

		public float deviceMemory => Get<float>();

		//Navigator includes NavigatorID;

		[Obsolete("The value of the NavigatorID.appCodeName property is always \"Mozilla\", in any browser.")]
		public string appCodeName => Get<string>();

		[Obsolete("The value of the NavigatorID.appName property is always \"Netscape\", in any browser.")]
		public string appName => Get<string>();

		[Obsolete("Do not rely on this property to return the correct value.")]
		public string appVersion => Get<string>();

		[Obsolete("Do not rely on this property to return the correct value.")]
		public string platform => Get<string>();

		[Obsolete("The value of the NavigatorID.product property is always \"Gecko\", in any browser.")]
		public string product => Get<string>();

		public string userAgent => Get<string>();

		//Navigator includes NavigatorLanguage;

		public string language => Get<string>();

		public IReadOnlyList<string> languages => Get<ImmutableList<string>>();

		//Navigator includes NavigatorOnLine;
		public bool onLine => Get<bool>();

		//Navigator includes NavigatorAutomationInformation;
		public bool webdriver => Get<bool>();

		//Navigator includes NavigatorUA;
		public NavigatorUAData userAgentData => Get<NavigatorUAData>();
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/navigator_ua_data.idl

	public class NavigatorUAData : JsObject
	{
		protected internal NavigatorUAData(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public IReadOnlyList<NavigatorUABrandVersion> brands => Get<ImmutableList<NavigatorUABrandVersion>>();
		public bool mobile => Get<bool>();
		public Task<UADataValues> getHighEntropyValues(IReadOnlyList<string> hints) =>
			Method<Task<UADataValues>>().Invoke(hints);
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/navigator_ua_brand_version.idl

	public class NavigatorUABrandVersion
	{
		public string brand { get; set; } = "";

		public string version { get; set; } = "";
	}

	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/ua_data_values.idl

	public class UADataValues
	{
		public string platform { get; set; } = "";
		public string platformVersion { get; set; } = "";
		public string architecture { get; set; } = "";
		public string model { get; set; } = "";
		public string uaFullVersion { get; set; } = "";
	}
}
