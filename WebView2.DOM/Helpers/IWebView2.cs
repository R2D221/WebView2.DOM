using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	internal interface IWebView2 { }

	internal static class IWebView2Extensions
	{
		public static CoreWebView2 GetCoreWebView2(this IWebView2 webView2) =>
			webView2 switch
			{
				Microsoft.Web.WebView2.WinForms.WebView2 winFormsWebView => winFormsWebView.CoreWebView2,
				Microsoft.Web.WebView2.Wpf.WebView2 wpfWebView => wpfWebView.CoreWebView2,
				_ => throw new InvalidOperationException("webView was of unexpected type"),
			};

		public static void ContentLoading_Add(this IWebView2 webView2, EventHandler<CoreWebView2ContentLoadingEventArgs> handler)
		{
			switch (webView2)
			{
			case Microsoft.Web.WebView2.WinForms.WebView2 winFormsWebView:
			{
				winFormsWebView.ContentLoading += handler;
				break;
			}
			case Microsoft.Web.WebView2.Wpf.WebView2 wpfWebView:
			{
				wpfWebView.ContentLoading += handler;
				break;
			}
			default: throw new InvalidOperationException("webView was of unexpected type");
			}
		}
	}
}
