using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using WebView2.DOM;

namespace TestXaml.Library
{
	public sealed class WebView2 : DependencyObject
	{
		private WebView2() { }

		public static readonly DependencyProperty DocumentProperty =
			DependencyProperty.RegisterAttached(
				name: "Document",
				propertyType: typeof(global::WebView2.Markup.html),
				ownerType: typeof(WebView2),
				defaultMetadata: new PropertyMetadata(propertyChangedCallback));

		private static async void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var webView = (Microsoft.Web.WebView2.Wpf.WebView2?)d;

			if (webView is null) { return; }

			if (e.OldValue != e.NewValue && e.NewValue is global::WebView2.Markup.html html)
			{
				await webView.EnsureCoreWebView2Async();

				if (webView.CoreWebView2 is null)
				{
					// Designer
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}

				await WebView2DOM.InitAsync(webView);
				webView.CoreWebView2.DOMContentLoaded += async (s, e) =>
				{
					await webView.InvokeInBrowserContextAsync(window =>
					{
						Render(window.document, window.document.documentElement!, html);
					});
				};
				webView.NavigateToString(
					@"
					<!DOCTYPE html>
					<html>
						<head>
							<meta charset=""utf-8""/>
						</head>
						<body></body>
					</html>
					");
			}
		}

		public static global::WebView2.Markup.html? GetDocument(DependencyObject d)
		{
			return (global::WebView2.Markup.html?)d.GetValue(DocumentProperty);
		}

		public static void SetDocument(DependencyObject d, global::WebView2.Markup.html? value)
		{
			d.SetValue(DocumentProperty, value);
		}

		private static void Render(global::WebView2.DOM.Document document, global::WebView2.DOM.Element documentElement, global::WebView2.Markup.html html)
		{
			foreach (var attr in html.attributes.Values)
			{
				documentElement.setAttributeNS(attr.namespaceURI, attr.qualifiedName, attr.value);
			}

			foreach (var eventGroup in html.events)
			{
				foreach (var @event in eventGroup.Value)
				{
					documentElement.AddEvent(@event, eventGroup.Key);
				}
			}

			var head = html.childNodes.OfType<global::WebView2.Markup.head>().SingleOrDefault();
			if (head is not null)
			{
				foreach (var attr in head.attributes.Values)
				{
					document.head.setAttributeNS(attr.namespaceURI, attr.qualifiedName, attr.value);
				}

				foreach (var eventGroup in head.events)
				{
					foreach (var @event in eventGroup.Value)
					{
						document.head.AddEvent(@event, eventGroup.Key);
					}
				}

				Render(document, document.head, head);
			}

			var body = html.childNodes.OfType<global::WebView2.Markup.body>().SingleOrDefault();
			if (body is not null)
			{
				foreach (var attr in body.attributes.Values)
				{
					document.body.setAttributeNS(attr.namespaceURI, attr.qualifiedName, attr.value);
				}

				foreach (var eventGroup in body.events)
				{
					foreach (var @event in eventGroup.Value)
					{
						document.body.AddEvent(@event, eventGroup.Key);
					}
				}

				Render(document, document.body, body);
			}
		}

		private static void Render(global::WebView2.DOM.Document document, global::WebView2.DOM.Element domElement, global::WebView2.Markup.Element markupElement)
		{
			foreach (var attr in markupElement.attributes.Values)
			{
				domElement.setAttributeNS(attr.namespaceURI, attr.qualifiedName, attr.value);
			}

			foreach (var eventGroup in markupElement.events)
			{
				foreach (var @event in eventGroup.Value)
				{
					domElement.AddEvent(@event, eventGroup.Key);
				}
			}

			foreach (var childNode in markupElement.childNodes)
			{
				switch (childNode)
				{
				case global::WebView2.Markup.Text text:
				{
					domElement.append(text.data);
					break;
				}
				case global::WebView2.Markup.Element childMarkupElement:
				{
					var childDomElement = document.createElementNS(childMarkupElement.namespaceURI, childMarkupElement.qualifiedName);
					domElement.append(childDomElement);

					Render(document, childDomElement, childMarkupElement);

					break;
				}
				default: throw new Exception();
				}
			}
		}
	}
}
