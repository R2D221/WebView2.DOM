using System.Linq;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public static class HTMLInputElementExtensions
	{
		public static THTMLInputElement createHTMLInputElement<THTMLInputElement>(this Document document, InputType<THTMLInputElement> tag)
			where THTMLInputElement : HTMLInputElement
		{
			var template = document.createHTMLElement(HTMLElementTag.template);

			template.innerHTML = $"<input type={tag.Name}>";

			return (THTMLInputElement)template.content.children.First().cloneNode(true);
		}
	}

	public sealed class InputType<THTMLInputElement> where THTMLInputElement : HTMLInputElement
	{
		public string Name { get; }

		internal InputType(string name) => Name = name;

		public static implicit operator InputType<THTMLInputElement>(InputType tag)
		{
			return new InputType<THTMLInputElement>(tag.Name);
		}
	}

	public sealed class InputType
	{
		public string Name { get; }

		internal InputType([CallerMemberName] string name = "") => Name = name.Replace("_", "-");

		public static readonly InputType<HTMLHiddenInputElement/*	*/> hidden/*	*/= new InputType();
		public static readonly InputType<HTMLTextInputElement/*	*/> text/*	*/= new InputType();
		public static readonly InputType<HTMLSearchInputElement/*	*/> search/*	*/= new InputType();
		public static readonly InputType<HTMLTelephoneInputElement/*	*/> tel/*	*/= new InputType();
		public static readonly InputType<HTMLURLInputElement/*	*/> url/*	*/= new InputType();
		public static readonly InputType<HTMLEmailInputElement/*	*/> email/*	*/= new InputType();
		public static readonly InputType<HTMLPasswordInputElement/*	*/> password/*	*/= new InputType();
		public static readonly InputType<HTMLDateInputElement/*	*/> date/*	*/= new InputType();
		public static readonly InputType<HTMLMonthInputElement/*	*/> month/*	*/= new InputType();
		public static readonly InputType<HTMLWeekInputElement/*	*/> week/*	*/= new InputType();
		public static readonly InputType<HTMLTimeInputElement/*	*/> time/*	*/= new InputType();
		public static readonly InputType<HTMLLocalDateTimeInputElement/*	*/> datetime_local/*	*/= new InputType();
		public static readonly InputType<HTMLNumberInputElement/*	*/> number/*	*/= new InputType();
		public static readonly InputType<HTMLRangeInputElement/*	*/> range/*	*/= new InputType();
		public static readonly InputType<HTMLColorInputElement/*	*/> color/*	*/= new InputType();
		public static readonly InputType<HTMLCheckboxInputElement/*	*/> checkbox/*	*/= new InputType();
		public static readonly InputType<HTMLRadioButtonInputElement/*	*/> radio/*	*/= new InputType();
		public static readonly InputType<HTMLFileUploadInputElement/*	*/> file/*	*/= new InputType();
		public static readonly InputType<HTMLSubmitInputElement/*	*/> submit/*	*/= new InputType();
		public static readonly InputType<HTMLImageInputElement/*	*/> image/*	*/= new InputType();
		public static readonly InputType<HTMLResetInputElement/*	*/> reset/*	*/= new InputType();
		public static readonly InputType<HTMLButtonInputElement/*	*/> button/*	*/= new InputType();
	}
}
