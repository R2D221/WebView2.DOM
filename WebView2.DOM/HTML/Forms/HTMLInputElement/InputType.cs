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

		public static readonly InputType<HTMLInputElement.hidden/*         	*/> hidden/*         	*/= new InputType();
		public static readonly InputType<HTMLInputElement.text/*           	*/> text/*           	*/= new InputType();
		public static readonly InputType<HTMLInputElement.search/*         	*/> search/*         	*/= new InputType();
		public static readonly InputType<HTMLInputElement.tel/*            	*/> tel/*            	*/= new InputType();
		public static readonly InputType<HTMLInputElement.url/*            	*/> url/*            	*/= new InputType();
		public static readonly InputType<HTMLInputElement.email/*          	*/> email/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.password/*       	*/> password/*       	*/= new InputType();
		public static readonly InputType<HTMLInputElement.date/*           	*/> date/*           	*/= new InputType();
		public static readonly InputType<HTMLInputElement.month/*          	*/> month/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.week/*           	*/> week/*           	*/= new InputType();
		public static readonly InputType<HTMLInputElement.time/*           	*/> time/*           	*/= new InputType();
		public static readonly InputType<HTMLInputElement.datetime_local/* 	*/> datetime_local/* 	*/= new InputType();
		public static readonly InputType<HTMLInputElement.number/*         	*/> number/*         	*/= new InputType();
		public static readonly InputType<HTMLInputElement.range/*          	*/> range/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.color/*          	*/> color/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.checkbox/*       	*/> checkbox/*       	*/= new InputType();
		public static readonly InputType<HTMLInputElement.radio/*          	*/> radio/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.file/*           	*/> file/*           	*/= new InputType();
		public static readonly InputType<HTMLInputElement.submit/*         	*/> submit/*         	*/= new InputType();
		public static readonly InputType<HTMLInputElement.image/*          	*/> image/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.reset/*          	*/> reset/*          	*/= new InputType();
		public static readonly InputType<HTMLInputElement.button/*         	*/> button/*         	*/= new InputType();
	}
}
