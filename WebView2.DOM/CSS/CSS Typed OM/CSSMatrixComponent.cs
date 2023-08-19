using Microsoft.Web.WebView2.Core;
using System;
using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component_options.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component.idl

	[JsonConverter(typeof(Converter))]
	public record CSSMatrixComponentOptions : JsDictionary
	{
		private class Converter : Converter<CSSMatrixComponentOptions> { }

		public required bool is2D
		{
			get => GetRequired<bool>();
			init => Set(value);
		}
	}

	public class CSSMatrixComponent : CSSTransformComponent
	{
		protected internal CSSMatrixComponent() { }

		public CSSMatrixComponent(DOMMatrixReadOnly matrix) =>
			Construct(matrix);
		public CSSMatrixComponent(DOMMatrixReadOnly matrix, CSSMatrixComponentOptions options) =>
			Construct(matrix, options);

		public DOMMatrix matrix { get => Get<DOMMatrix>(); set => Set(value); }
	}
}
