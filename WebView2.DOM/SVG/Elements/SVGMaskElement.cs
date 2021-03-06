﻿using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/svg/svg_mask_element.idl

	public partial class SVGMaskElement : SVGElement
	{
		protected internal SVGMaskElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public SVGAnimatedEnumeration<SVGUnitType> maskUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedEnumeration<SVGUnitType> maskContentUnits =>
			Get<SVGAnimatedEnumeration<SVGUnitType>>();
		public SVGAnimatedLength x =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedLength y =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedLength width =>
			Get<SVGAnimatedLength>();
		public SVGAnimatedLength height =>
			Get<SVGAnimatedLength>();
	}

	public partial class SVGMaskElement : SVGTests
	{
		public SVGStringList requiredExtensions => Get<SVGStringList>();

		public SVGStringList systemLanguage => Get<SVGStringList>();
	}
}