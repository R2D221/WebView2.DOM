using System.Threading;
using System.Windows;

namespace WebView2.DOM.Sample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
		}
	}
}
