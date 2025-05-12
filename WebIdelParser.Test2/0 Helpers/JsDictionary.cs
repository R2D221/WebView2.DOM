using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	public abstract record JsDictionary
	{
		private readonly Dictionary<string, JsonElement> elements = new();
		private static JsonSerializerOptions defaultOptions = new JsonSerializerOptions();
		private JsonSerializerOptions options { get; set; } = defaultOptions;

		protected T Get<T>(T defaultValue, [CallerMemberName] string property = null!)
		{
			return elements.TryGetValue(property, out var value) ? JsonSerializer.Deserialize<T>(value, options)! : defaultValue;
		}

		protected T GetRequired<T>([CallerMemberName] string property = null!)
		{
			return JsonSerializer.Deserialize<T>(elements[property], options)!;
		}

		protected void Set<T>(T value, [CallerMemberName] string property = null!)
		{
			elements[property] = JsonSerializer.SerializeToElement(value, options);
		}

		internal class Converter<TJsDictionary> : JsonConverter<TJsDictionary> where TJsDictionary : JsDictionary
		{
			public override TJsDictionary? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				var obj = JsonSerializer.Deserialize<JsonElement>(ref reader);

				switch (obj.ValueKind)
				{
				case JsonValueKind.Null: return null;
				case JsonValueKind.Object:
				{
					var result = (JsDictionary)Activator.CreateInstance(typeToConvert)!;
					result.options = options;

					foreach (var property in obj.EnumerateObject())
					{
						result.elements[property.Name] = property.Value;
					}

					return (TJsDictionary)result;
				}
				default: throw new NotSupportedException();
				}
			}

			public override void Write(Utf8JsonWriter writer, TJsDictionary value, JsonSerializerOptions options)
			{
				JsonSerializer.Serialize(writer, value.elements, options);
			}
		}
	}
}
