using NodaTime;
using NodaTime.Text;
using System;
using System.Text.Json;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_input_element.idl

	// Note: Most members of the HTMLInputElement type have been split into several subtypes.
	// So, instead of having a single HTMLInputElement type, we have e.g.
	// <input type=checkbox> => HTMLInputElement.checkbox,
	// <input type=date> => HTMLInputElement.date,
	// and so on.
	// This explicitly deviates from the HTML standard, where all members are contained into
	// the HTMLInputElement type, but I hope the separation makes it better to use the
	// properties that actually belong to each input type.

	public enum FileUploadCapture
	{
		_, user, environment
	}

	public partial class HTMLInputElement : HTMLElement, IFormControl, ILabelableElement
	{
		private protected HTMLInputElement() { }

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public HTMLFormElement? form => Get<HTMLFormElement?>();

		public string defaultValue { get => Get<string>(); set => Set(value); }
		public string value { get => Get<string>(); set => Set(value); }

		//public object? valueAsDate { get => Get<object?>(); set => Set(value); }
		//public double valueAsNumber { get => Get<double>(); set => Set(value); }

		public string name { get => Get<string>(); set => Set(value); }
		public FormControlType type { get => Get<FormControlType>(); /*set => Set(value);*/ }

		public bool willValidate => Get<bool>();
		public ValidityState validity => Get<ValidityState>();
		public string validationMessage => Get<string>();
		public bool checkValidity() => Method<bool>().Invoke();
		public bool reportValidity() => Method<bool>().Invoke();
		public void setCustomValidity(string error) => Method().Invoke(error);

		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();

		//// Non-standard APIs
		//attribute bool webkitdirectory;
		//attribute bool incremental;

		#region hidden input

		new public sealed class @hidden : HTMLInputElement
		{
			private @hidden() { }

			public string autocomplete { get => Get<string>(); set => Set(value); }
		}

		#endregion

		#region text inputs

		public abstract class WithText : HTMLInputElement
		{
			private protected WithText() { }

			public string autocomplete { get => Get<string>(); set => Set(value); }
			public int minLength { get => Get<int>(); set => Set(value); }
			public int maxLength { get => Get<int>(); set => Set(value); }
			public string pattern { get => Get<string>(); set => Set(value); }
			public string placeholder { get => Get<string>(); set => Set(value); }
			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
			public uint size { get => Get<uint>(); set => Set(value); }
		}

		public abstract class WithSelectableText : WithText
		{
			private protected WithSelectableText() { }

			public void select() => Method().Invoke();
			public uint selectionStart { get => Get<uint>(); set => Set(value); }
			public uint selectionEnd { get => Get<uint>(); set => Set(value); }
			public SelectionDirection selectionDirection { get => Get<SelectionDirection>(); set => Set(value); }
			public void setRangeText(string replacement) => Method().Invoke(replacement);
			public void setRangeText(string replacement, uint start, uint end) =>
				Method().Invoke(replacement, start, end);
			public void setRangeText(string replacement, uint start, uint end, SelectionMode selectionMode) =>
				Method().Invoke(replacement, start, end, selectionMode);
			public void setSelectionRange(uint start, uint end) =>
				Method().Invoke(start, end);
			public void setSelectionRange(uint start, uint end, SelectionDirection direction) =>
				Method().Invoke(start, end, direction);
		}

		public sealed class @text : WithSelectableText
		{
			private @text() { }

			public string dirName { get => Get<string>(); set => Set(value); }
			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		public sealed class @search : WithSelectableText
		{
			private @search() { }

			public string dirName { get => Get<string>(); set => Set(value); }
			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		public sealed class @tel : WithSelectableText
		{
			private @tel() { }

			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		public sealed class @url : WithSelectableText
		{
			private @url() { }

			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		public sealed class @email : WithText
		{
			private @email() { }

			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		public sealed class @password : WithSelectableText
		{
			private @password() { }
		}

		#endregion

		#region value inputs

		public abstract class WithValue<T> : HTMLInputElement
			where T : struct
		{
			private protected WithValue() { }

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

			public void stepUp(int n = 1)
			{
				switch (n)
				{
				case 1: Method().Invoke(); break;
				default: Method().Invoke(n); break;
				};
			}

			public void stepDown(int n = 1)
			{
				switch (n)
				{
				case 1: Method().Invoke(); break;
				default: Method().Invoke(n); break;
				};
			}
		}

		public sealed class @date : WithValue<LocalDate>
		{
			private @date() { }

			protected override IPattern<LocalDate> Pattern => DatesAndTimes.datePattern;

			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @month : WithValue<YearMonth>
		{
			private @month() { }

			protected override IPattern<YearMonth> Pattern => DatesAndTimes.monthPattern;

			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @week : WithValue<IsoWeek>
		{
			private @week() { }

			protected override IPattern<IsoWeek> Pattern => DatesAndTimes.weekPattern;

			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @time : WithValue<LocalTime>
		{
			private @time() { }

			protected override IPattern<LocalTime> Pattern => DatesAndTimes.timePattern;

			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @datetime_local : WithValue<LocalDateTime>
		{
			private @datetime_local() { }

			protected override IPattern<LocalDateTime> Pattern => DatesAndTimes.localDateAndTimePattern;

			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @number : WithValue<double>
		{
			private @number() { }

			protected override IPattern<double> Pattern => new Pattern<double>
			{
				AppendFormat = null!,
				Format = value => JsonSerializer.Serialize(value),
				Parse = text =>
				{
					try
					{
						return ParseResult<double>.ForValue(JsonSerializer.Deserialize<double>(text));
					}
					catch (Exception ex)
					{
						return ParseResult<double>.ForException(() => ex);
					}
				},
			};

			public string placeholder { get => Get<string>(); set => Set(value); }
			public bool readOnly { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @range : WithValue<double>
		{
			private @range() { }

			protected override IPattern<double> Pattern => new Pattern<double>
			{
				AppendFormat = null!,
				Format = value => JsonSerializer.Serialize(value),
				Parse = text =>
				{
					try
					{
						return ParseResult<double>.ForValue(JsonSerializer.Deserialize<double>(text));
					}
					catch (Exception ex)
					{
						return ParseResult<double>.ForException(() => ex);
					}
				},
			};
		}

		public sealed class @color : HTMLInputElement
		{
			private @color() { }

			public string autocomplete { get => Get<string>(); set => Set(value); }
			public HTMLDataListElement? list => Get<HTMLDataListElement?>();
		}

		#endregion

		#region checked inputs

		public abstract class WithCheckedness : HTMLInputElement
		{
			private protected WithCheckedness() { }

			public bool defaultChecked { get => Get<bool>(); set => Set(value); }
			public bool @checked { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @checkbox : WithCheckedness
		{
			private @checkbox() { }

			public bool indeterminate { get => Get<bool>(); set => Set(value); }
		}

		public sealed class @radio : WithCheckedness
		{
			private @radio() { }
		}

		#endregion

		#region file input

		public sealed class @file : HTMLInputElement
		{
			private @file() { }

			public string accept { get => Get<string>(); set => Set(value); }
			public bool multiple { get => Get<bool>(); set => Set(value); }
			public bool required { get => Get<bool>(); set => Set(value); }
			public FileList files { get => Get<FileList>(); set => Set(value); }

			// HTML Media Capture
			public FileUploadCapture capture { get => Get<FileUploadCapture>(); set => Set(value); }
		}

		#endregion

		#region button inputs

		public sealed class @submit : HTMLInputElement
		{
			private @submit() { }

			public Uri formAction { get => Get<Uri>(); set => Set(value); }
			public Enctype formEnctype { get => Get<Enctype>(); set => Set(value); }
			public Method formMethod { get => Get<Method>(); set => Set(value); }
			public bool formNoValidate { get => Get<bool>(); set => Set(value); }
			public string formTarget { get => Get<string>(); set => Set(value); }
		}

		public sealed class @image : HTMLInputElement
		{
			private @image() { }

			public Uri formAction { get => Get<Uri>(); set => Set(value); }
			public Enctype formEnctype { get => Get<Enctype>(); set => Set(value); }
			public Method formMethod { get => Get<Method>(); set => Set(value); }
			public bool formNoValidate { get => Get<bool>(); set => Set(value); }
			public string formTarget { get => Get<string>(); set => Set(value); }

			public Uri src { get => Get<Uri>(); set => Set(value); }
			public string alt { get => Get<string>(); set => Set(value); }
			public uint width { get => Get<uint>(); set => Set(value); }
			public uint height { get => Get<uint>(); set => Set(value); }
		}

		public sealed class @reset : HTMLInputElement
		{
			private @reset() { }
		}

		public sealed class @button : HTMLInputElement
		{
			private @button() { }
		}

		#endregion
	}
}
