using NodaTime;
using NodaTime.Extensions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WebView2.DOM.Sample
{
	using Duration = NodaTime.Duration;
	using Window = System.Windows.Window;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			return;
			await webView.EnsureCoreWebView2Async();
			await WebView2DOM.InitAsync(webView);
			webView.CoreWebView2.DOMContentLoaded += async (s, e) =>
			{
				await webView.InvokeInBrowserContextAsync(DOMContentLoaded);
			};
			webView.NavigateToString(@"
				<h1>Welcome to C# DOM</h1>
				<p>The current time is <span id='current-time'></span></p>
				<p>requestAnimationFrame FPS (called from C#) is <span id='fps'></span></p>
				<p>
					<button id='jsAlertButton'>(JS) Show alert</button>
					<br />
					<button id='csAlertButton'>(C#) Change window size</button>
				</p>
			");
		}

		private void DOMContentLoaded(WebView2.DOM.Window window)
		{
			var jsAlertButton = (HTMLButtonElement)window.document.getElementById("jsAlertButton");
			var csAlertButton = (HTMLButtonElement)window.document.getElementById("csAlertButton");

			jsAlertButton.onclick += JsAlertButton_onclick;
			csAlertButton.onclick += CsAlertButton_onclick;

			var currentTime_span = (HTMLElement)window.document.getElementById("current-time");
			var fps = (HTMLElement)window.document.getElementById("fps");

			callback(Duration.Zero);
			void callback(Duration timestamp)
			{
				currentTime_span.innerText = GetCurrentDateTime();
				fps.innerText = $"{calculateFps(timestamp)}";

				_ = window.requestAnimationFrame(callback);
			}
		}

		private void JsAlertButton_onclick(object sender, MouseEvent e)
		{
			window.alert("Hello! You invoked window.alert()");
		}

		/*
		 * I disabled this method because, now with the new Dispatch.PushFrame mechanism, sending an InvokeAsync
		 * from within the browser context makes the web view hang for several seconds, which the component then
		 * interprets as a CoreWebView2ProcessFailedReason.Unresponsive event.
		 * I'm trying to see if there's a way to disable this timeout, but for now it's best not to invoke anything
		 * that takes several seconds from within the browser context.
		 */
		//private async void CsAlertButton_onclick(object sender, MouseEvent e)
		//{
		//	var result = await Dispatcher.InvokeAsync(() => MessageBox.Show("Hello! You invoked MessageBox.Show()"));

		//	switch (result)
		//	{
		//	case MessageBoxResult.OK: Debugger.Break(); break;
		//	}
		//}

		private void CsAlertButton_onclick(object sender, MouseEvent e)
		{
			Dispatcher.Invoke(() =>
			{
				WindowState = WindowState switch
				{
					WindowState.Maximized => WindowState.Normal,
					WindowState.Normal => WindowState.Maximized,
					_ => WindowState.Minimized,
				};
			});
		}

		private static string GetCurrentDateTime() =>
			SystemClock.Instance
			.InTzdbSystemDefaultZone()
			.GetCurrentLocalDateTime()
			.ToString("o", null);

		private static readonly Queue<Duration> timestamps =
			new Queue<Duration>();

		private static int calculateFps(Duration timestamp)
		{
			while (timestamps.TryPeek(out var first) && first <= timestamp - Duration.FromSeconds(1))
			{
				_ = timestamps.Dequeue();
			}

			timestamps.Enqueue(timestamp);

			return timestamps.Count;
		}

		private void h1_onclick(object sender, MouseEvent e)
		{
			window.alert("Hello from XAML!");
		}
	}
}
