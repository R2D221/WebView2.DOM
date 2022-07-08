using EnumsNET;
using OneOf;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebView2.DOM.Helpers
{
	internal static class JSON
	{
		public static JsonSerializerOptions Options { get; } =
			new JsonSerializerOptions
			{
				Converters =
				{
					new EnumJsonConverterFactory(),
					new JsObjectJsonConverterFactory(),
					new DelegateJsonConverterFactory(),
					new anyJsonConverter(),
					//new LocalDateTimeJsonConverter(),
					new KeyValuePairJsonConverterFactory(),
					new OneOfJsonConverterFactory(),
				},
			};
	}

	internal sealed class EnumJsonConverterFactory : JsonConverterFactory
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
		private static readonly EnumFormat customEnumFormat =
			Enums.RegisterCustomEnumFormat(x => x.AsString() == "_" ? "" :
				x.AsString()
				.Replace("_", "-")
			);

		public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
			Enums.Parse<TEnum>(reader.GetString() ?? throw new NullReferenceException(), ignoreCase: false, EnumFormat.EnumMemberValue, customEnumFormat);

		public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
			writer.WriteStringValue(Enums.AsString(value, EnumFormat.EnumMemberValue, customEnumFormat));
	}

	internal sealed class JsObjectJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) => false
			|| typeof(JsObject).IsAssignableFrom(typeToConvert)
			|| typeof(IFormControl).IsAssignableFrom(typeToConvert)
			|| typeof(ILabelableElement).IsAssignableFrom(typeToConvert)
			|| typeof(HTMLHyperlinkElementUtils).IsAssignableFrom(typeToConvert)
			;

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			typeof(JsObject).IsAssignableFrom(typeToConvert)
			? (JsonConverter)Activator.CreateInstance(typeof(JsObjectJsonConverter<>).MakeGenericType(typeToConvert))!
			: (JsonConverter)Activator.CreateInstance(typeof(JsObjectInterfaceJsonConverter<>).MakeGenericType(typeToConvert))!
			;
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
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "referenceType"
			&& reader.Read()
			&& reader.GetString() is string referenceType
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return References2.Load<TJsObject>(referenceId, referenceType);
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
			writer.WriteString("referenceId", References2.GetId(value));
			writer.WriteEndObject();
		}
	}

	internal sealed class JsObjectInterfaceJsonConverter<I> : JsonConverter<I?>
		where I : class //interface
	{
		public override I? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
			&& reader.TokenType == JsonTokenType.PropertyName
			&& reader.GetString() == "referenceType"
			&& reader.Read()
			&& reader.GetString() is string referenceType
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return (I?)(object?)References2.Load<JsObject>(referenceId, referenceType);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, I? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			if (value is not JsObject obj) { throw new InvalidOperationException(); }

			writer.WriteStartObject();
			writer.WriteString("referenceId", References2.GetId(obj));
			writer.WriteEndObject();
		}
	}

	internal sealed class DelegateJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeof(Delegate).IsAssignableFrom(typeToConvert)
			;

		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			new DelegateJsonConverter();
	}

	internal sealed class DelegateJsonConverter : JsonConverter<Delegate>
	{
		public override Delegate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Delegate value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = Callbacks.Register(value);

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

	internal sealed class KeyValuePairJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) =>
			typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);

		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(typeof(KeyValuePairJsonConverter<,>).MakeGenericType(typeToConvert.GetGenericArguments()))!;
	}

	internal sealed class KeyValuePairJsonConverter<TKey, TValue> : JsonConverter<KeyValuePair<TKey, TValue>>
	{
		public override KeyValuePair<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				throw new NullReferenceException();
			}

			if (true
			&& reader.TokenType == JsonTokenType.StartArray
			&& reader.Read()
			&& JsonSerializer.Deserialize<TKey>(ref reader, options) is TKey key
			&& reader.Read()
			&& JsonSerializer.Deserialize<TValue>(ref reader, options) is TValue value
			&& reader.Read()
			&& reader.TokenType == JsonTokenType.EndArray
			)
			{
				return new KeyValuePair<TKey, TValue>(key, value);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public override void Write(Utf8JsonWriter writer, KeyValuePair<TKey, TValue> value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize(writer, new object?[] { value.Key, value.Value }, options);
		}
	}

	internal sealed class OneOfJsonConverterFactory : JsonConverterFactory
	{
		private static readonly ImmutableDictionary<Type, Type> converters =
			ImmutableDictionary<Type, Type>.Empty
			.Add(typeof(OneOf<,>), typeof(OneOfJsonConverter<,>))
			.Add(typeof(OneOf<,,>), typeof(OneOfJsonConverter<,,>))
			.Add(typeof(OneOf<,,,>), typeof(OneOfJsonConverter<,,,>))
			.Add(typeof(OneOf<,,,,>), typeof(OneOfJsonConverter<,,,,>))
			.Add(typeof(OneOf<,,,,,>), typeof(OneOfJsonConverter<,,,,,>))
			.Add(typeof(OneOf<,,,,,,>), typeof(OneOfJsonConverter<,,,,,,>))
			.Add(typeof(OneOf<,,,,,,,>), typeof(OneOfJsonConverter<,,,,,,,>))
			.Add(typeof(OneOf<,,,,,,,,>), typeof(OneOfJsonConverter<,,,,,,,,>))
			.Add(typeof(OneOf<,,,,,,,,,>), typeof(OneOfJsonConverter<,,,,,,,,,>))
			.Add(typeof(OneOf<,,,,,,,,,,>), typeof(OneOfJsonConverter<,,,,,,,,,,>))
			;

		public override bool CanConvert(Type typeToConvert) =>
			typeToConvert.IsGenericType && converters.ContainsKey(typeToConvert.GetGenericTypeDefinition());

		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(converters[typeToConvert.GetGenericTypeDefinition()].MakeGenericType(typeToConvert.GetGenericArguments()))!;
	}

	internal sealed class OneOfJsonConverter<T0, T1> : JsonConverter<OneOf<T0, T1>>
		where T0 : notnull
		where T1 : notnull
	{
		public override OneOf<T0, T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2> : JsonConverter<OneOf<T0, T1, T2>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
	{
		public override OneOf<T0, T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3> : JsonConverter<OneOf<T0, T1, T2, T3>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
	{
		public override OneOf<T0, T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4> : JsonConverter<OneOf<T0, T1, T2, T3, T4>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5, T6> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5, T6>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5, T6, T7> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5, T6, T7>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5, T6, T7, T8> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T9>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}

	internal sealed class OneOfJsonConverter<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : JsonConverter<OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
		where T0 : notnull
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		where T10 : notnull
	{
		public override OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

			try { return JsonSerializer.Deserialize<T0>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T9>(element, options)!; } catch { }
			try { return JsonSerializer.Deserialize<T10>(element, options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}
}
