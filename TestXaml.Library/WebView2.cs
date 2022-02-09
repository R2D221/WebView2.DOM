using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Windows;
using WebView2.DOM;

namespace TestXaml.Library
{
	public sealed class WebView2 : DependencyObject
	{
		private WebView2() { }

		//public static readonly DependencyProperty DocumentProperty =
		//	DependencyProperty<WebView2>.Register(
		//		property: x => x.Document,
		//		defaultValue: null,
		//		propertyChangedCallback: (x, oldValue, newValue) =>
		//		{

		//		});

		public static readonly DependencyProperty DocumentProperty =
			DependencyProperty.RegisterAttached(
				name: "Document",
				propertyType: typeof(global::WebView2.Markup.HTMLElement),
				ownerType: typeof(WebView2),
				defaultMetadata: new PropertyMetadata(propertyChangedCallback));

		private static async void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var webView = (Microsoft.Web.WebView2.Wpf.WebView2)d!;

			if (e.OldValue != e.NewValue && e.NewValue != null)
			{
				await webView.EnsureCoreWebView2Async();
				await WebView2DOM.InitAsync(webView);
				webView.CoreWebView2.DOMContentLoaded += async (s, e) =>
				{
					await webView.InvokeInBrowserContextAsync(window =>
					{
						global::WebView2.DOM.HTMLDivElement div;
						try
						{
							div = window.document.createHTMLElement(HTMLElementTag.div);
						}
						catch (Exception ex)
						{
							throw;
						}
						div.innerText = "Hello, World!";
					});
				};
				webView.NavigateToString(@"<html></html>");
			}
		}

		public static global::WebView2.Markup.HTMLElement? GetDocument(DependencyObject d)
		{
			return (global::WebView2.Markup.HTMLElement?)d.GetValue(DocumentProperty);
		}

		public static void SetDocument(DependencyObject d, global::WebView2.Markup.HTMLElement? value)
		{
			d.SetValue(DocumentProperty, value);
		}
	}
}
