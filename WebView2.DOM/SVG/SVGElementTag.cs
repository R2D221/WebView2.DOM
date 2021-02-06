using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	public static class SVGElementTagExtensions
	{
		public static TSVGElement createSVGElement<TSVGElement>(this Document document, SVGElementTag<TSVGElement> tag)
			where TSVGElement : SVGElement
		{
			return document.Method<TSVGElement>("createElementNS").Invoke("http://www.w3.org/2000/svg", tag.Name);
		}

		public static HTMLCollection<TSVGElement> getSVGElementsByTagName<TSVGElement>(this Document document, SVGElementTag<TSVGElement> tag)
			where TSVGElement : SVGElement
		{
			return document.Method<HTMLCollection<TSVGElement>>("getElementsByTagNameNS").Invoke("http://www.w3.org/2000/svg", tag.Name);
		}

		public static HTMLCollection<TSVGElement> getSVGElementsByTagName<TSVGElement>(this Element element, SVGElementTag<TSVGElement> tag)
			where TSVGElement : SVGElement
		{
			return element.Method<HTMLCollection<TSVGElement>>("getElementsByTagNameNS").Invoke("http://www.w3.org/2000/svg", tag.Name);
		}
	}

	public sealed class SVGElementTag<TSVGElement> where TSVGElement : SVGElement
	{
		public string Name { get; }

		internal SVGElementTag(string name) => Name = name;

		public static implicit operator SVGElementTag<TSVGElement>(SVGElementTag tag)
		{
			return new SVGElementTag<TSVGElement>(tag.Name);
		}
	}


	public sealed class SVGElementTag
	{
		public string Name { get; }

		internal SVGElementTag([CallerMemberName] string name = "") => Name = name;

		public static readonly SVGElementTag<SVGAElement/*	*/> a/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGCircleElement/*	*/> circle/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGClipPathElement/*	*/> clipPath/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGDefsElement/*	*/> defs/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGDescElement/*	*/> desc/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGEllipseElement/*	*/> ellipse/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEBlendElement/*	*/> feBlend/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEColorMatrixElement/*	*/> feColorMatrix/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEComponentTransferElement/*	*/> feComponentTransfer/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFECompositeElement/*	*/> feComposite/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEConvolveMatrixElement/*	*/> feConvolveMatrix/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEDiffuseLightingElement/*	*/> feDiffuseLighting/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEDisplacementMapElement/*	*/> feDisplacementMap/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEDistantLightElement/*	*/> feDistantLight/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEFloodElement/*	*/> feFlood/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEFuncAElement/*	*/> feFuncA/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEFuncBElement/*	*/> feFuncB/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEFuncGElement/*	*/> feFuncG/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEFuncRElement/*	*/> feFuncR/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEGaussianBlurElement/*	*/> feGaussianBlur/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEImageElement/*	*/> feImage/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEMergeElement/*	*/> feMerge/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEMergeNodeElement/*	*/> feMergeNode/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEMorphologyElement/*	*/> feMorphology/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEOffsetElement/*	*/> feOffset/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFEPointLightElement/*	*/> fePointLight/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFESpecularLightingElement/*	*/> feSpecularLighting/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFESpotLightElement/*	*/> feSpotLight/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFETileElement/*	*/> feTile/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFETurbulenceElement/*	*/> feTurbulence/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGFilterElement/*	*/> filter/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGForeignObjectElement/*	*/> foreignObject/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGGElement/*	*/> g/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGImageElement/*	*/> image/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGLineElement/*	*/> line/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGLinearGradientElement/*	*/> linearGradient/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGMarkerElement/*	*/> marker/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGMaskElement/*	*/> mask/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGMetadataElement/*	*/> metadata/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGPathElement/*	*/> path/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGPatternElement/*	*/> pattern/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGPolygonElement/*	*/> polygon/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGPolylineElement/*	*/> polyline/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGRadialGradientElement/*	*/> radialGradient/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGRectElement/*	*/> rect/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGScriptElement/*	*/> script/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGStopElement/*	*/> stop/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGStyleElement/*	*/> style/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGSVGElement/*	*/> svg/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGSwitchElement/*	*/> @switch/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGSymbolElement/*	*/> symbol/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGTextElement/*	*/> text/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGTextPathElement/*	*/> textPath/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGTitleElement/*	*/> title/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGTSpanElement/*	*/> tspan/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGUseElement/*	*/> use/*	*/= new SVGElementTag();
		public static readonly SVGElementTag<SVGViewElement/*	*/> view/*	*/= new SVGElementTag();
	}
}
