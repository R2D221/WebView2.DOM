using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using WebView2.DOM;

namespace WebView2.DOM.Sample
{
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
				await webView.Run(DOMContentLoaded);
			};
			webView.NavigateToString(@"
				<h1>Welcome to C# DOM</h1>
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
		}

		private void JsAlertButton_onclick(object sender, MouseEvent e)
		{
			window.alert("Hello! You invoked window.alert()");
		}

		private async void CsAlertButton_onclick(object sender, MouseEvent e)
		{
			try
			{
				await Task.Yield();
				this.Dispatcher.Invoke(() =>
				{
					try
					{
						MessageBox.Show("Hello! You invoked MessageBox.Show()");
					}
					catch (Exception ex)
					{
						Debugger.Break();
					}
				});
			}
			catch (Exception ex)
			{
				Debugger.Break();
			}
		}
	}
}
