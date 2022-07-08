using System.Dynamic;
using System.Text.Json;

namespace WebView2.DOM
{
	public class any : DynamicObject
	{
		public JsonElement json { get; set; }
		public JsonSerializerOptions? options { get; set; }

		public override bool TryConvert(ConvertBinder binder, out object? result)
		{
			result = JsonSerializer.Deserialize(json, binder.Type, options);
			return true;
		}
	}
}
