namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_fe_merge_node_element.idl

	public sealed class SVGFEMergeNodeElement : SVGElement
	{
		private SVGFEMergeNodeElement() { }

		public SVGAnimatedString in1 => GetCached<SVGAnimatedString>();
	}
}