using NodaTime;
using NodaTime.Extensions;
using System.Collections.Generic;
using System.Windows;
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
			await webView.EnsureCoreWebView2Async();
			await WebView2DOM.InitAsync(webView);
			webView.CoreWebView2.DOMContentLoaded += async (s, e) =>
			{
				await webView.InvokeInBrowserContextAsync(DOMContentLoaded);
			};
			webView.NavigateToString(@"
				<h1>Welcome to C# DOM</h1>
				<p id='mouse-coords'>Mouse coords: (<span id='x'></span>, <span id='y'></span>)</p>
				<p>The current time is <span id='current-time'></span></p>
				<p>requestAnimationFrame FPS (called from C#) is <span id='fps'></span></p>
				<p>
					<button id='jsAlertButton'>(JS) window.alert</button>
					<br />
					<button id='csAlertButton'>(C#) MessageBox.Show</button>
				</p>
			");
		}

		private void DOMContentLoaded(WebView2.DOM.Window window)
		{
			var document = window.document;

			InitMouseEvent(document);
			InitButtonClicks(document);
			InitAnimationLoop(document);
		}

		private void InitMouseEvent(Document document)
		{
			var mouse_coords = document.getElementById("mouse-coords") as HTMLParagraphElement;
			var x = document.getElementById("x") as HTMLSpanElement;
			var y = document.getElementById("y") as HTMLSpanElement;

			if (mouse_coords is null) { throw new KeyNotFoundException(); }
			if (x is null) { throw new KeyNotFoundException(); }
			if (y is null) { throw new KeyNotFoundException(); }

			mouse_coords.style.position = "absolute";

			window.onmousemove += (s, e) =>
			{
				mouse_coords.style.top = $"{e.y}";
				mouse_coords.style.left = $"{e.x}";

				x.innerText = $"{e.x}";
				y.innerText = $"{e.y}";
			};
		}

		private void InitButtonClicks(Document document)
		{
			var jsAlertButton = document.getElementById("jsAlertButton") as HTMLButtonElement;
			var csAlertButton = document.getElementById("csAlertButton") as HTMLButtonElement;

			if (jsAlertButton is null) { throw new KeyNotFoundException(); }
			if (csAlertButton is null) { throw new KeyNotFoundException(); }

			jsAlertButton.onclick += (s, e) =>
			{
				window.alert("Hello! You invoked window.alert()");
			};

			csAlertButton.onclick += async (s, e) =>
			{
				/*
				Never NEVER use Dispatcher.Invoke() while in the browsing context.
				I'll break your knees if you do.
				*/

				await Dispatcher.InvokeAsync(() =>
				{
					_ = MessageBox.Show("Hello! You invoked MessageBox.Show()");
				});
			};
		}

		private void InitAnimationLoop(Document document)
		{
			var currentTime_span = document.getElementById("current-time") as HTMLElement;
			var fps = document.getElementById("fps") as HTMLElement;

			if (currentTime_span is null) { throw new KeyNotFoundException(); }
			if (fps is null) { throw new KeyNotFoundException(); }

			callback(Duration.Zero);
			void callback(Duration timestamp)
			{
				currentTime_span.innerText = GetCurrentDateTime();
				fps.innerText = $"{calculateFps(timestamp)}";

				_ = window.requestAnimationFrame(x => callback(x));
			}
		}

		private static string GetCurrentDateTime() =>
			SystemClock.Instance
			.InTzdbSystemDefaultZone()
			.GetCurrentLocalDateTime()
			.ToString("o", null);

		private static readonly Queue<Duration> timestamps = new();

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
