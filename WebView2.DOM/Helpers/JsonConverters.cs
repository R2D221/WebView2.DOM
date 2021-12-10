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
			&& reader.TokenType == JsonTokenType.EndObject
			)
			{
				return (I?)(object?)References.GetNullable<JsObject>(referenceId);
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
			writer.WriteString("referenceId", obj.referenceId);
			writer.WriteEndObject();
		}
	}

	internal sealed class TaskJsonConverterFactory : JsonConverterFactory
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

	internal sealed class ActionJsonConverterFactory : JsonConverterFactory
	{
		private static readonly ImmutableDictionary<Type, Type> converters =
			ImmutableDictionary<Type, Type>.Empty
			.Add(typeof(Action<>/*	*/), typeof(ActionJsonConverter<>/*	*/))
			.Add(typeof(Action<,>/*	*/), typeof(ActionJsonConverter<,>/*	*/))
			.Add(typeof(Action<,,>/*	*/), typeof(ActionJsonConverter<,,>/*	*/))
			.Add(typeof(Action<,,,>/*	*/), typeof(ActionJsonConverter<,,,>/*	*/))
			.Add(typeof(Action<,,,,>/*	*/), typeof(ActionJsonConverter<,,,,>/*	*/))
			.Add(typeof(Action<,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,,,,,>/*	*/))
			.Add(typeof(Action<,,,,,,,,,,,,,,,>/*	*/), typeof(ActionJsonConverter<,,,,,,,,,,,,,,,>/*	*/))
			;

		public override bool CanConvert(Type typeToConvert) =>
			typeToConvert.IsGenericType && converters.ContainsKey(typeToConvert.GetGenericTypeDefinition());

		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			(JsonConverter)Activator.CreateInstance(converters[typeToConvert.GetGenericTypeDefinition()].MakeGenericType(typeToConvert.GetGenericArguments()))!;
	}

	internal sealed class ActionJsonConverter : JsonConverter<Action?>
	{
		public override Action? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1> : JsonConverter<Action<T1>?>
	{
		public override Action<T1>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2> : JsonConverter<Action<T1, T2>?>
	{
		public override Action<T1, T2>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3> : JsonConverter<Action<T1, T2, T3>?>
	{
		public override Action<T1, T2, T3>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4> : JsonConverter<Action<T1, T2, T3, T4>?>
	{
		public override Action<T1, T2, T3, T4>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5> : JsonConverter<Action<T1, T2, T3, T4, T5>?>
	{
		public override Action<T1, T2, T3, T4, T5>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<Action<T1, T2, T3, T4, T5, T6>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>? value, JsonSerializerOptions options)
		{
			if (value is null) { writer.WriteNullValue(); return; }

			var callbackId = References.AddCallback(value);

			writer.WriteStartObject();
			writer.WriteString("callbackId", callbackId);
			writer.WriteEndObject();
		}
	}

	internal sealed class ActionJsonConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : JsonConverter<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>?>
	{
		public override Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>? value, JsonSerializerOptions options)
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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T9>(element.GetRawText(), options)!; } catch { }

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

			try { return JsonSerializer.Deserialize<T0>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T1>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T2>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T3>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T4>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T5>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T6>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T7>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T8>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T9>(element.GetRawText(), options)!; } catch { }
			try { return JsonSerializer.Deserialize<T10>(element.GetRawText(), options)!; } catch { }

			return JsonSerializer.Deserialize<T0>("null")!;
		}

		public override void Write(Utf8JsonWriter writer, OneOf<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(writer, value.Value, options);
	}
}
