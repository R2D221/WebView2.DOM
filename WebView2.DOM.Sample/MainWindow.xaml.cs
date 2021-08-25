using NodaTime;
using NodaTime.Extensions;
using System.Collections.Generic;
using System.Windows;

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
			await webView.EnsureCoreWebView2Async();
			await WebView2DOM.InitAsync(webView);
			webView.DOMContentLoaded().Handler += async (s, e) =>
			{
				await webView.InvokeInBrowserContextAsync(DOMContentLoaded);
			};
			webView.NavigateToString(@"
				<h1>Welcome to C# DOM</h1>
				<p>The current time is <span id='current-time'></span></p>
				<p>requestAnimationFrame FPS (called from C#) is <span id='fps'></span></p>
				<p>
					<button id='jsAlertButton'>Call JS function</button>
					<br />
					<button id='csAlertButton'>Call C# function</button>
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

		private async void CsAlertButton_onclick(object sender, MouseEvent e)
		{
			await webView.InvokeInWpfContextAsync(() =>
			{
				_ = MessageBox.Show("Hello! You invoked MessageBox.Show()");
			});
		}

		private static string GetCurrentDateTime() =>
			SystemClock.Instance
			.InTzdbSystemDefaultZone()
			.GetCurrentLocalDateTime()
			.ToString();

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
	}
}
