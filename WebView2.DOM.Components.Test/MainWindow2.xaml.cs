using System.Collections.ObjectModel;

namespace WebView2.DOM.Components.Test;

static class WebApp
{
	private static readonly ToDoAppViewModel app = new();

	public static void Start(Window window)
	{
		var document = window.document;

		_ = document.head.appendChild(new style
		{
			"""
				body
				{
					display: flex;
				}
				section
				{
					flex: 50%;
				}
				li.completed
				{
					color: gray;
					text-decoration: line-through;
				}
				"""
		});

		_ = document.body.appendChild
		(
			new section
			{
				new h2 { "To-do list" },
				new input.text { placeholder = "Add new item...", value = { () => app.NewItem.Description } },
				new button { onclick = { () => app.AddNewItem } }[new()
				{
					"Add"
				}],
			}
		);

		_ = document.body.appendChild
		(
			new section
			{
				new ul
				{
					from item in app.Items
					select new li { @class = { () => item.Completed ? "completed" : "" } }[new()
					{
						new input.checkbox { @checked = { () => item.Completed } },
						() => item.Description,
					}]
				}
			}
		);
	}
}

sealed class ToDoAppViewModel : ViewModelBase
{
	public ObservableCollection<ToDoItemViewModel> Items =>
		Get(() => new ObservableCollection<ToDoItemViewModel>());


	public ToDoItemViewModel NewItem
	{
		get => Get(() => new ToDoItemViewModel());
		set => Set(value);
	}

	public void AddNewItem(object? source, PointerEvent args)
	{
		if (NewItem.Description is not "")
		{
			Items.Add(NewItem);
			NewItem = new();
		}
	}
}

sealed class ToDoItemViewModel : ViewModelBase
{
	public string Description
	{
		get => Get("");
		set => Set(value);
	}

	public bool Completed
	{
		get => Get(false);
		set => Set(value);
	}
}

public partial class MainWindow2 : System.Windows.Window
{
	public MainWindow2()
	{
		InitializeComponent();
	}

	private async void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
	{
		await webView.EnsureCoreWebView2Async();
		await WebView2DOM.InitAsync(webView);
		webView.CoreWebView2.DOMContentLoaded += async (s, e) =>
		{
			await webView.InvokeInBrowserContextAsync(WebApp.Start);
		};
		webView.NavigateToString("");
	}
}
