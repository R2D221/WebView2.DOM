namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component_options.idl
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_matrix_component.idl

	public class CSSMatrixComponentOptions
	{
		public bool is2D { get; init; }
	}

	public class CSSMatrixComponent : CSSTransformComponent
	{
		public CSSMatrixComponent(DOMMatrixReadOnly matrix) => Construct(matrix);
		public CSSMatrixComponent(DOMMatrixReadOnly matrix, CSSMatrixComponentOptions options) => Construct(matrix, options);
		public DOMMatrix matrix { get => Get<DOMMatrix>(); set => Set(value); }
	}
}
