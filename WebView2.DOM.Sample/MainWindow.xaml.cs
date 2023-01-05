using System.Windows;
using WebView2.DOM.Sample.Shared;

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

			HtmlCodeBehind.Init(webView);
		}
	}
}
