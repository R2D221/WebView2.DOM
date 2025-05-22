using Refactor.WebView2.DOM.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

		private void CsWebView_DOMContentLoaded(object sender, RoutedEventArgs e)
		{
			var result = Refactor.WebView2.DOM.Window.window;
		}
	}
}