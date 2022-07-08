namespace WebView2.DOM
{
	public sealed partial class BrowsingContext
	{
		public abstract record Request(string memberType, JsObject obj)
		{
			public sealed record Constructor(JsObject obj, string typeName, object?[] args) : Request("constructor", obj);
			public sealed record Get(JsObject obj, string property) : Request("getter", obj);
			public sealed record GetUintIndex(JsObject obj, uint property) : Request("getter", obj);
			public sealed record GetIntIndex(JsObject obj, int property) : Request("getter", obj);
			public sealed record Set<T>(JsObject obj, string property, T value) : Request("setter", obj);
			public sealed record SetUintIndex<T>(JsObject obj, uint property, T value) : Request("setter", obj);
			public sealed record SetIntIndex<T>(JsObject obj, int property, T value) : Request("setter", obj);
			public sealed record Delete(JsObject obj, string property) : Request("deleter", obj);
			public sealed record DeleteUintIndex(JsObject obj, uint property) : Request("deleter", obj);
			public sealed record DeleteIntIndex(JsObject obj, int property) : Request("deleter", obj);
			public sealed record Invoke(JsObject obj, string method, object?[] args) : Request("invoke", obj);
			public sealed record SymbolInvoke(JsObject obj, string method, object?[] args) : Request("invokeSymbol", obj);
			public sealed record AddEvent(JsObject obj, string @event) : Request("addevent", obj);
			public sealed record RemoveEvent(JsObject obj, string @event) : Request("removeevent", obj);
		}
	}
}
