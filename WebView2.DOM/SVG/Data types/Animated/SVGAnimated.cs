namespace WebView2.DOM
{
	public abstract class SVGAnimated<SVGValue> : JsObject
		where SVGValue : JsObject
	{
		private protected SVGAnimated() { }

		public SVGValue baseVal => GetCached<SVGValue>();
		public SVGValue animVal => GetCached<SVGValue>();
	}

	public abstract class SVGAnimatedPrimitive<T> : JsObject
	{
		private protected SVGAnimatedPrimitive() { }

		public T baseVal { get => Get<T>(); set => Set(value); }
		public T animVal => Get<T>();
	}
}