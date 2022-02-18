using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The ol element represents a list of items, where the items have been intentionally ordered,
	/// such that changing the order would change the meaning of the document.
	/// </summary>
	[ContentProperty(nameof(olChildNodes))]
	public sealed class ol : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		public ol_ul_NodeList olChildNodes { get; } = new();
		public override NodeList childNodes => olChildNodes;

		/// <summary>
		/// The reversed attribute is a boolean attribute. If present, it indicates that the list is a descending list (..., 3, 2, 1).
		/// If the attribute is omitted, the list is an ascending list (1, 2, 3, ...).
		/// </summary>
		public ol_reversed? reversed
		{
			get => GetAttribute<ol_reversed>();
			set => SetAttribute(value);
		}

		/// <summary>
		/// The start attribute, if present, must be a valid integer. It is used to determine the starting value of the list.
		/// </summary>
		public int? start
		{
			get => GetAttribute() is { } s ? JsonSerializer.Deserialize<int>(s) : null;
			set => SetAttribute(value is { } i ? JsonSerializer.Serialize(i) : null);
		}

		/// <summary>
		/// The type attribute can be used to specify the kind of marker to use in the list, in the cases where that matters (e.g. because
		/// items are to be referenced by their number/letter).
		/// </summary>
		public ol_type? type
		{
			get => GetAttribute() is { } s ? ol_type.Parse(s) : null;
			set => SetAttribute(value is { } i ? i.ToString() : null);
		}
	}

	public enum ol_reversed { reversed }

	[TypeConverter(typeof(ol_type_TypeConverter))]
	public sealed class ol_type
	{
		private readonly string text;
		private ol_type(string text) => this.text = text;
		public override string ToString() => text;

		private static readonly ImmutableDictionary<string, ol_type> valueDict;
		public static readonly IReadOnlyCollection<ol_type> Values;

		/// <summary>
		/// Decimal numbers
		/// </summary>
		public static readonly ol_type @decimal = new ol_type("1");

		/// <summary>
		/// Lowercase latin alphabet
		/// </summary>
		public static readonly ol_type lower_alpha = new ol_type("a");

		/// <summary>
		/// Uppercase latin alphabet
		/// </summary>
		public static readonly ol_type upper_alpha = new ol_type("A");

		/// <summary>
		/// Lowercase roman numerals
		/// </summary>
		public static readonly ol_type lower_roman = new ol_type("i");

		/// <summary>
		/// Uppercase roman numerals
		/// </summary>
		public static readonly ol_type upper_roman = new ol_type("I");

		static ol_type()
		{
			valueDict =
				new[] { @decimal, lower_alpha, upper_alpha, lower_roman, upper_roman }
				.ToImmutableDictionary(x => x.text);

			Values = valueDict.Values.ToImmutableArray();
		}

		public static ol_type Parse(string text) => valueDict[text];
	}

	public sealed class ol_type_TypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			switch (value)
			{
			case string text:
			{
				return ol_type.Parse(text);
			}
			default: throw new InvalidOperationException();
			}
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			switch (value)
			{
			case ol_type type:
			{
				return type.ToString();
			}
			default: throw new InvalidOperationException();
			}
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(ol_type.Values.ToArray());
		}
	}
}
