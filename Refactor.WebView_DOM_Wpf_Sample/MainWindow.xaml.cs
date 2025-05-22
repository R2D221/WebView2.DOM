using System.Windows;

namespace Refactor.WebView2_DOM_Wpf_Sample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void CsWebView_DOMContentLoaded(object sender, RoutedEventArgs e) => WebApp.DOMContentLoaded();
	}
}