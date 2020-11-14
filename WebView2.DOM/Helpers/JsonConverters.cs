using EnumsNET;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebView2.DOM.Helpers
{
	internal sealed class EnumJsonConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeToConvert.IsEnum
			&& !FlagEnums.IsFlagEnum(typeToConvert)
			&& Enums.GetNames(typeToConvert).Any(name => name.Any(c => char.IsLower(c)))
			;

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(typeof(EnumJsonConverter<>).MakeGenericType(typeToConvert))!;
	}

	internal sealed class EnumJsonConverter<TEnum> : JsonConverter<TEnum>
		where TEnum : struct, Enum
	{
		private static readonly EnumFormat enumFormat =
			Enums.RegisterCustomEnumFormat(x => x.AsString() == "_" ? "" : x.AsString().Replace("_", "-"));

		public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
			Enums.Parse<TEnum>(reader.GetString() ?? throw new NullReferenceException(), ignoreCase: false, enumFormat);

		public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
			writer.WriteStringValue(Enums.AsString(value, enumFormat));
	}

	internal sealed class JsObjectJsonConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeof(JsObject).IsAssignableFrom(typeToConvert)
			;

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(typeof(JsObjectJsonConverter<>).MakeGenericType(typeToConvert))!;
	}

	internal sealed class JsObjectJsonConverter<TJsObject> : JsonConverter<TJsObject?>
		where TJsObject : JsObject
	{
		public override TJsObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				return null;
			}

			if (true
			&& reader.TokenType == JsonTokenType.StartObject
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "referenceId"
			&& reader.Read()
			&& reader.GetString() is string referenceId
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return References.GetNullable<TJsObject>(referenceId);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, TJsObject? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			writer.WriteStartObject();
			writer.WriteString("referenceId", value.referenceId);
			writer.WriteEndObject();
		}
	}

	internal sealed class TaskJsonConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeof(Task).IsAssignableFrom(typeToConvert)
			;

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			typeToConvert.GetGenericArguments() is Type[] genericArguments
			&& genericArguments.SingleOrDefault() is Type genericArgument
			? (JsonConverter)Activator.CreateInstance(typeof(TaskJsonConverter<>).MakeGenericType(genericArgument))!
			: new VoidTaskJsonConverter()
			;
	}

	internal sealed class TaskJsonConverter<T> : JsonConverter<Task<T>>
	{
		public override Task<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				throw new NullReferenceException();
			}

			if (true
			&& reader.TokenType == JsonTokenType.StartObject
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "promiseId"
			&& reader.Read()
			&& reader.GetString() is string promiseId
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return References.GetTask(promiseId).ContinueWith(x =>
					JsonSerializer.Deserialize<T>(x.GetAwaiter().GetResult(), options)!
				);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, Task<T> value, JsonSerializerOptions options)
		{
			throw new NotSupportedException();
		}
	}

	internal sealed class VoidTaskJsonConverter : JsonConverter<Task>
	{
		public override Task Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				throw new NullReferenceException();
			}

			if (true
			&& reader.TokenType == JsonTokenType.StartObject
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "promiseId"
			&& reader.Read()
			&& reader.GetString() is string promiseId
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return References.GetTask(promiseId);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options)
		{
			throw new NotSupportedException();
		}
	}

	internal sealed class ActionJsonConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Action<>);

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(typeof(ActionJsonConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()))!;
	}

	internal sealed class ActionJsonConverter<T> : JsonConverter<Action<T>?>
	{
		public override Action<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class anyJsonConverter : JsonConverter<any>
	{
		public override any Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return new any
			{
				json = JsonSerializer.Deserialize<JsonElement>(ref reader, options),
				options = options,
			};
		}

		public override void Write(Utf8JsonWriter writer, any value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}
