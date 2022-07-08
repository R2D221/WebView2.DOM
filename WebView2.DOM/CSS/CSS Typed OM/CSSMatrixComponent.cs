using Microsoft.Web.WebView2.Core;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component_options.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component.idl

	[InitOnly]
	public record CSSMatrixComponentOptions
	{
		public bool is2D
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= false;
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
