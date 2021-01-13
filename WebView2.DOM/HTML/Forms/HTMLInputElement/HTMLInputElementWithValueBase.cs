using Microsoft.Web.WebView2.Core;
using NodaTime.Text;
using System.Text.Json;

namespace WebView2.DOM
{
	public abstract class HTMLInputElementWithValueBase<T> : HTMLInputElement
		where T : struct
	{
		protected internal HTMLInputElementWithValueBase(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected abstract IPattern<T> Pattern { get; }

		public string autocomplete { get => Get<string>(); set => Set(value); }
		public HTMLDataListElement? list => Get<HTMLDataListElement?>();

		new public T? defaultValue
		{
			get => Get<string>() switch
			{
				null or "" => null,
				string value => Pattern.Parse(value).Value,
			};
			set => Set(value switch
			{
				null => "",
				T x => Pattern.Format(x),
			});
		}

		new public T? value
		{
			get => Get<string>() switch
			{
				null or "" => null,
				string value => Pattern.Parse(value).Value,
			};
			set => Set(value switch
			{
				null => "",
				T x => Pattern.Format(x),
			});
		}

		public T? min
		{
			get => Get<string>() switch
			{
				null or "" => null,
				string value => Pattern.Parse(value).Value,
			};
			set => Set(value switch
			{
				null => "",
				T x => Pattern.Format(x),
			});
		}

		public T? max
		{
			get => Get<string>() switch
			{
				null or "" => null,
				string value => Pattern.Parse(value).Value,
			};
			set => Set(value switch
			{
				null => "",
				T x => Pattern.Format(x),
			});
		}

		public double step
		{
			get => JsonSerializer.Deserialize<double>(Get<string>());
			set => Set(JsonSerializer.Serialize(value));
		}

		public void stepUp(int n = 1) =>
			_ = n switch
			{
				1 => Method().Invoke(),
				_ => Method().Invoke(n),
			};

		public void stepDown(int n = 1) =>
			_ = n switch
			{
				1 => Method().Invoke(),
				_ => Method().Invoke(n),
			};
	}
}
