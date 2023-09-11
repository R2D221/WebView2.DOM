using NodaTime;
using System;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM.Components;

public static class @input
{
	public sealed class @hidden : HTMLInputElementBuilder<HTMLInputElement.hidden>
	{
		protected override HTMLInputElement.hidden CreateElement() =>
			document.createHTMLInputElement(InputType.hidden);

		/// <summary>
		/// Hint for form autofill feature
		/// </summary>
		public AttributeBuilder<string> autocomplete
		{
			get => new(value => element.autocomplete = value);
			set => element.autocomplete = value.GetConstantValue();
		}

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// Value of the form control
		/// </summary>
		public TwoWayAttributeBuilder<string> value
		{
			get => new(() => element.value, x => element.onchange += x);
			set => element.value = value.GetConstantValue();
		}
	}
	public sealed class @text : HTMLInputElementWithTextBuilder<HTMLInputElement.text>
	{
		protected override HTMLInputElement.text CreateElement() =>
			document.createHTMLInputElement(InputType.text);

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @search : HTMLInputElementWithTextBuilder<HTMLInputElement.search>
	{
		protected override HTMLInputElement.search CreateElement() =>
			document.createHTMLInputElement(InputType.search);

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @tel : HTMLInputElementWithTextBuilder<HTMLInputElement.tel>
	{
		protected override HTMLInputElement.tel CreateElement() =>
			document.createHTMLInputElement(InputType.tel);

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @url : HTMLInputElementWithTextBuilder<HTMLInputElement.url>
	{
		protected override HTMLInputElement.url CreateElement() =>
			document.createHTMLInputElement(InputType.url);

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @email : HTMLInputElementWithTextBuilder<HTMLInputElement.email>
	{
		protected override HTMLInputElement.email CreateElement() =>
			document.createHTMLInputElement(InputType.email);

		/// <summary>
		/// Name of form control to use for sending the element's directionality in form submission
		/// </summary>
		public AttributeBuilder<string> dirname
		{
			get => new(value => element.dirName = value);
			set => element.dirName = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @password : HTMLInputElementWithTextBuilder<HTMLInputElement.password>
	{
		protected override HTMLInputElement.password CreateElement() =>
			document.createHTMLInputElement(InputType.password);
	}
	public sealed class @date : HTMLInputElementWithValueBuilder<HTMLInputElement.date, LocalDate>
	{
		protected override HTMLInputElement.date CreateElement() =>
			document.createHTMLInputElement(InputType.date);

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @month : HTMLInputElementWithValueBuilder<HTMLInputElement.month, YearMonth>
	{
		protected override HTMLInputElement.month CreateElement() =>
			document.createHTMLInputElement(InputType.month);

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @week : HTMLInputElementWithValueBuilder<HTMLInputElement.week, IsoWeek>
	{
		protected override HTMLInputElement.week CreateElement() =>
			document.createHTMLInputElement(InputType.week);

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @time : HTMLInputElementWithValueBuilder<HTMLInputElement.time, LocalTime>
	{
		protected override HTMLInputElement.time CreateElement() =>
			document.createHTMLInputElement(InputType.time);

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @datetime_local : HTMLInputElementWithValueBuilder<HTMLInputElement.datetime_local, LocalDateTime>
	{
		protected override HTMLInputElement.datetime_local CreateElement() =>
			document.createHTMLInputElement(InputType.datetime_local);

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @number : HTMLInputElementWithValueBuilder<HTMLInputElement.number, double>
	{
		protected override HTMLInputElement.number CreateElement() =>
			document.createHTMLInputElement(InputType.number);

		/// <summary>
		/// User-visible label to be placed within the form control
		/// </summary>
		public AttributeBuilder<string> placeholder
		{
			get => new(value => element.placeholder = value);
			set => element.placeholder = value.GetConstantValue();
		}

		/// <summary>
		/// Whether to allow the value to be edited by the user
		/// </summary>
		public AttributeBuilder<bool> @readonly
		{
			get => new(value => element.readOnly = value);
			set => element.readOnly = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}
	}
	public sealed class @range : HTMLInputElementWithValueBuilder<HTMLInputElement.range, double>
	{
		protected override HTMLInputElement.range CreateElement() =>
			document.createHTMLInputElement(InputType.range);
	}
	public sealed class @color : HTMLInputElementBuilder<HTMLInputElement.color>
	{
		protected override HTMLInputElement.color CreateElement() =>
			document.createHTMLInputElement(InputType.color);

		/// <summary>
		/// Hint for form autofill feature
		/// </summary>
		public AttributeBuilder<string> autocomplete
		{
			get => new(value => element.autocomplete = value);
			set => element.autocomplete = value.GetConstantValue();
		}

		/// <summary>
		/// List of autocomplete options
		/// </summary>
		public AttributeBuilder<string?> list
		{
			get => new(value => SetOrRemoveAttribute(nameof(list), value));
			set => SetOrRemoveAttribute(nameof(list), value.GetConstantValue());
		}
	}
	public sealed class @checkbox : HTMLInputElementWithCheckednessBuilder<HTMLInputElement.checkbox>
	{
		protected override HTMLInputElement.checkbox CreateElement() =>
			document.createHTMLInputElement(InputType.checkbox);
	}
	public sealed class @radio : HTMLInputElementWithCheckednessBuilder<HTMLInputElement.radio>
	{
		protected override HTMLInputElement.radio CreateElement() =>
			document.createHTMLInputElement(InputType.radio);
	}
	public sealed class @file : HTMLInputElementBuilder<HTMLInputElement.file>
	{
		protected override HTMLInputElement.file CreateElement() =>
			document.createHTMLInputElement(InputType.file);

		/// <summary>
		/// Hint for expected file type in file upload controls
		/// </summary>
		public AttributeBuilder<string> accept
		{
			get => new(value => element.accept = value);
			set => element.accept = value.GetConstantValue();
		}

		/// <summary>
		/// Whether to allow multiple values
		/// </summary>
		public AttributeBuilder<bool> multiple
		{
			get => new(value => element.multiple = value);
			set => element.multiple = value.GetConstantValue();
		}

		/// <summary>
		/// Whether the control is required for form submission
		/// </summary>
		public AttributeBuilder<bool> required
		{
			get => new(value => element.required = value);
			set => element.required = value.GetConstantValue();
		}

		/// <summary>
		/// List of selected files
		/// </summary>
		public TwoWayAttributeBuilder<FileList> files
		{
			get => new(() => element.files, x => element.onchange += x);
			set => element.files = value.GetConstantValue();
		}
	}
	public sealed class @submit : HTMLInputElementBuilder<HTMLInputElement.submit>
	{
		protected override HTMLInputElement.submit CreateElement() =>
			document.createHTMLInputElement(InputType.submit);

		/// <summary>
		/// Value of the form control
		/// </summary>
		public AttributeBuilder<string> value
		{
			get => new(value => element.value = value);
			set => element.value = value.GetConstantValue();
		}

		/// <summary>
		/// URL to use for form submission
		/// </summary>
		public AttributeBuilder<Uri> formaction
		{
			get => new(value => element.formAction = value);
			set => element.formAction = value.GetConstantValue();
		}

		/// <summary>
		/// Entry list encoding type to use for form submission
		/// </summary>
		public AttributeBuilder<Enctype> formenctype
		{
			get => new(value => element.formEnctype = value);
			set => element.formEnctype = value.GetConstantValue();
		}

		/// <summary>
		/// Variant to use for form submission
		/// </summary>
		public AttributeBuilder<Method> formmethod
		{
			get => new(value => element.formMethod = value);
			set => element.formMethod = value.GetConstantValue();
		}

		/// <summary>
		/// Bypass form control validation for form submission
		/// </summary>
		public AttributeBuilder<bool> formnovalidate
		{
			get => new(value => element.formNoValidate = value);
			set => element.formNoValidate = value.GetConstantValue();
		}

		/// <summary>
		/// Navigable for form submission
		/// </summary>
		public AttributeBuilder<string> formtarget
		{
			get => new(value => element.formTarget = value);
			set => element.formTarget = value.GetConstantValue();
		}
	}
	public sealed class @image : HTMLInputElementBuilder<HTMLInputElement.image>
	{
		protected override HTMLInputElement.image CreateElement() =>
			document.createHTMLInputElement(InputType.image);

		/// <summary>
		/// Value of the form control
		/// </summary>
		public AttributeBuilder<string> value
		{
			get => new(value => element.value = value);
			set => element.value = value.GetConstantValue();
		}

		/// <summary>
		/// URL to use for form submission
		/// </summary>
		public AttributeBuilder<Uri> formaction
		{
			get => new(value => element.formAction = value);
			set => element.formAction = value.GetConstantValue();
		}

		/// <summary>
		/// Entry list encoding type to use for form submission
		/// </summary>
		public AttributeBuilder<Enctype> formenctype
		{
			get => new(value => element.formEnctype = value);
			set => element.formEnctype = value.GetConstantValue();
		}

		/// <summary>
		/// Variant to use for form submission
		/// </summary>
		public AttributeBuilder<Method> formmethod
		{
			get => new(value => element.formMethod = value);
			set => element.formMethod = value.GetConstantValue();
		}

		/// <summary>
		/// Bypass form control validation for form submission
		/// </summary>
		public AttributeBuilder<bool> formnovalidate
		{
			get => new(value => element.formNoValidate = value);
			set => element.formNoValidate = value.GetConstantValue();
		}

		/// <summary>
		/// Navigable for form submission
		/// </summary>
		public AttributeBuilder<string> formtarget
		{
			get => new(value => element.formTarget = value);
			set => element.formTarget = value.GetConstantValue();
		}

		/// <summary>
		/// Address of the resource
		/// </summary>
		public AttributeBuilder<Uri> src
		{
			get => new(value => element.src = value);
			set => element.src = value.GetConstantValue();
		}

		/// <summary>
		/// Replacement text for use when images are not available
		/// </summary>
		public AttributeBuilder<string> alt
		{
			get => new(value => element.alt = value);
			set => element.alt = value.GetConstantValue();
		}

		/// <summary>
		/// Horizontal dimension
		/// </summary>
		public AttributeBuilder<uint> width
		{
			get => new(value => element.width = value);
			set => element.width = value.GetConstantValue();
		}

		/// <summary>
		/// Vertical dimension
		/// </summary>
		public AttributeBuilder<uint> height
		{
			get => new(value => element.height = value);
			set => element.height = value.GetConstantValue();
		}
	}
	public sealed class @reset : HTMLInputElementBuilder<HTMLInputElement.reset>
	{
		protected override HTMLInputElement.reset CreateElement() =>
			document.createHTMLInputElement(InputType.reset);
	}
	public sealed class @button : HTMLInputElementBuilder<HTMLInputElement.button>
	{
		protected override HTMLInputElement.button CreateElement() =>
			document.createHTMLInputElement(InputType.button);
	}
}


