using DependencyPropertyGenerator;
using Microsoft.Web.WebView2.Core;
using Refactor.WebView2.DOM.Interop;
using System;
using System.IO;
using System.Windows;
using WebView = Microsoft.Web.WebView2.Wpf.WebView2;

namespace Refactor.WebView2.DOM.Wpf;

[RoutedEvent("DOMContentLoaded", RoutedEventStrategy.Direct)]
public partial class CsWebView : WebView
{
	private static readonly Lazy<string> eventLoopJs = new(() =>
	{
		using var stream = typeof(CsWebView).Assembly.GetManifestResourceStream("Refactor.WebView2.DOM.Wpf.eventLoop.js");
		using var reader = new StreamReader(stream!);

		return reader.ReadToEnd();
	});

	private BrowsingContext? browsingContext;
	private CoreWebView2? webView;
	private JsDispatcher? dispatcher;

	public CsWebView()
	{
		CoreWebView2InitializationCompleted += (_, args) =>
		{
			if (args.IsSuccess is false) { throw args.InitializationException; }

			webView = CoreWebView2;
			dispatcher = new JsDispatcher();

			webView.ContentLoading += (_, args) =>
			{
				browsingContext?.Dispose();

				browsingContext = new Refactor.WebView2.DOM.Wpf.Interop.BrowsingContext_ForWpf(dispatcher, () => OnDOMContentLoaded());
				webView.AddHostObjectToScript("Bridge", browsingContext.Bridge);
			};

			_ = webView.AddScriptToExecuteOnDocumentCreatedAsync(eventLoopJs.Value);

		};
	}
}