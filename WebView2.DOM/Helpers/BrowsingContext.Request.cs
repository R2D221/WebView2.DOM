using Microsoft.Extensions.ObjectPool;
using System;
using System.Windows.Media;

namespace WebView2.DOM
{
	public sealed partial class BrowsingContext
	{
		public abstract class Request
		{
			public Request(string memberType) => this.memberType = memberType;
			public string memberType { get; }
			public required JsObject? obj { get; set; }

			public sealed class Constructor : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Constructor>
				{
					public override Constructor Create() => new() { obj = null, typeName = "", args = Array.Empty<object?>() };
					public override bool Return(Constructor obj)
					{
						obj.typeName = "";
						obj.args = Array.Empty<object?>();
						return true;
					}
				}
				private static ObjectPool<Constructor> pool = new DefaultObjectPool<Constructor>(new Policy());
				internal static Constructor FromPool(string typeName, object?[] args)
				{
					var request = pool.Get();
					request.typeName = typeName;
					request.args = args;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Constructor() : base("constructor") { }
				public required string typeName { get; set; }
				public required object?[] args { get; set; }
			}

			public sealed class Get : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Get>
				{
					public override Get Create() => new() { obj = null, property = "" };
					public override bool Return(Get obj)
					{
						obj.obj = null;
						obj.property = "";
						return true;
					}
				}
				private static ObjectPool<Get> pool = new DefaultObjectPool<Get>(new Policy());
				internal static Get FromPool(JsObject obj, string property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Get() : base("getter") { }
				public required string property { get; set; }
			}

			public sealed class GetUintIndex : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<GetUintIndex>
				{
					public override GetUintIndex Create() => new() { obj = null, property = 0 };
					public override bool Return(GetUintIndex obj)
					{
						obj.obj = null;
						obj.property = 0;
						return true;
					}
				}
				private static ObjectPool<GetUintIndex> pool = new DefaultObjectPool<GetUintIndex>(new Policy());
				internal static GetUintIndex FromPool(JsObject obj, uint property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private GetUintIndex() : base("getter") { }
				public required uint property { get; set; }
			}

			public sealed class GetIntIndex : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<GetIntIndex>
				{
					public override GetIntIndex Create() => new() { obj = null, property = 0 };
					public override bool Return(GetIntIndex obj)
					{
						obj.obj = null;
						obj.property = 0;
						return true;
					}
				}
				private static ObjectPool<GetIntIndex> pool = new DefaultObjectPool<GetIntIndex>(new Policy());
				internal static GetIntIndex FromPool(JsObject obj, int property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private GetIntIndex() : base("getter") { }
				public required int property { get; set; }
			}

			public sealed class Set<T> : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Set<T>>
				{
					public override Set<T> Create() => new() { obj = null, property = "", value = default! };
					public override bool Return(Set<T> obj)
					{
						obj.obj = null;
						obj.property = "";
						obj.value = default!;
						return true;
					}
				}
				private static ObjectPool<Set<T>> pool = new DefaultObjectPool<Set<T>>(new Policy());
				internal static Set<T> FromPool(JsObject obj, string property, T value)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					request.value = value;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Set() : base("setter") { }
				public required string property { get; set; }
				public required T value { get; set; }
			}

			public sealed class SetUintIndex<T> : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<SetUintIndex<T>>
				{
					public override SetUintIndex<T> Create() => new() { obj = null, property = 0, value = default! };
					public override bool Return(SetUintIndex<T> obj)
					{
						obj.obj = null;
						obj.property = 0;
						obj.value = default!;
						return true;
					}
				}
				private static ObjectPool<SetUintIndex<T>> pool = new DefaultObjectPool<SetUintIndex<T>>(new Policy());
				internal static SetUintIndex<T> FromPool(JsObject obj, uint property, T value)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					request.value = value;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private SetUintIndex() : base("setter") { }
				public required uint property { get; set; }
				public required T value { get; set; }
			}

			public sealed class SetIntIndex<T> : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<SetIntIndex<T>>
				{
					public override SetIntIndex<T> Create() => new() { obj = null, property = 0, value = default! };
					public override bool Return(SetIntIndex<T> obj)
					{
						obj.obj = null;
						obj.property = 0;
						obj.value = default!;
						return true;
					}
				}
				private static ObjectPool<SetIntIndex<T>> pool = new DefaultObjectPool<SetIntIndex<T>>(new Policy());
				internal static SetIntIndex<T> FromPool(JsObject obj, int property, T value)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					request.value = value;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private SetIntIndex() : base("setter") { }
				public required int property { get; set; }
				public required T value { get; set; }
			}

			public sealed class Delete : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Delete>
				{
					public override Delete Create() => new() { obj = null, property = "" };
					public override bool Return(Delete obj)
					{
						obj.obj = null;
						obj.property = "";
						return true;
					}
				}
				private static ObjectPool<Delete> pool = new DefaultObjectPool<Delete>(new Policy());
				internal static Delete FromPool(JsObject obj, string property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Delete() : base("deleter") { }
				public required string property { get; set; }
			}

			public sealed class DeleteUintIndex : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<DeleteUintIndex>
				{
					public override DeleteUintIndex Create() => new() { obj = null, property = 0 };
					public override bool Return(DeleteUintIndex obj)
					{
						obj.obj = null;
						obj.property = 0;
						return true;
					}
				}
				private static ObjectPool<DeleteUintIndex> pool = new DefaultObjectPool<DeleteUintIndex>(new Policy());
				internal static DeleteUintIndex FromPool(JsObject obj, uint property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private DeleteUintIndex() : base("deleter") { }
				public required uint property { get; set; }
			}

			public sealed class DeleteIntIndex : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<DeleteIntIndex>
				{
					public override DeleteIntIndex Create() => new() { obj = null, property = 0 };
					public override bool Return(DeleteIntIndex obj)
					{
						obj.obj = null;
						obj.property = 0;
						return true;
					}
				}
				private static ObjectPool<DeleteIntIndex> pool = new DefaultObjectPool<DeleteIntIndex>(new Policy());
				internal static DeleteIntIndex FromPool(JsObject obj, int property)
				{
					var request = pool.Get();
					request.obj = obj;
					request.property = property;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private DeleteIntIndex() : base("deleter") { }
				public required int property { get; set; }
			}

			public sealed class Invoke : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Invoke>
				{
					public override Invoke Create() => new() { obj = null, method = "", args = Array.Empty<object?>() };
					public override bool Return(Invoke obj)
					{
						obj.obj = null;
						obj.method = "";
						obj.args = Array.Empty<object?>();
						return true;
					}
				}
				private static ObjectPool<Invoke> pool = new DefaultObjectPool<Invoke>(new Policy());
				internal static Invoke FromPool(JsObject obj, string method, object?[] args)
				{
					var request = pool.Get();
					request.obj = obj;
					request.method = method;
					request.args = args;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Invoke() : base("invoke") { }
				public required string method { get; set; }
				public required object?[] args { get; set; }
			}

			public sealed class SymbolInvoke : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<SymbolInvoke>
				{
					public override SymbolInvoke Create() => new() { obj = null, method = "", args = Array.Empty<object?>() };
					public override bool Return(SymbolInvoke obj)
					{
						obj.obj = null;
						obj.method = "";
						obj.args = Array.Empty<object?>();
						return true;
					}
				}
				private static ObjectPool<SymbolInvoke> pool = new DefaultObjectPool<SymbolInvoke>(new Policy());
				internal static SymbolInvoke FromPool(JsObject obj, string method, object?[] args)
				{
					var request = pool.Get();
					request.obj = obj;
					request.method = method;
					request.args = args;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private SymbolInvoke() : base("invokeSymbol") { }
				public required string method { get; set; }
				public required object?[] args { get; set; }
			}

			public sealed class AddEvent : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<AddEvent>
				{
					public override AddEvent Create() => new() { obj = null, @event = "" };
					public override bool Return(AddEvent obj)
					{
						obj.obj = null;
						obj.@event = "";
						return true;
					}
				}
				private static ObjectPool<AddEvent> pool = new DefaultObjectPool<AddEvent>(new Policy());
				internal static AddEvent FromPool(JsObject obj, string @event)
				{
					var request = pool.Get();
					request.obj = obj;
					request.@event = @event;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private AddEvent() : base("addevent") { }
				public required string @event { get; set; }
			}

			public sealed class RemoveEvent : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<RemoveEvent>
				{
					public override RemoveEvent Create() => new() { obj = null, @event = "" };
					public override bool Return(RemoveEvent obj)
					{
						obj.obj = null;
						obj.@event = "";
						return true;
					}
				}
				private static ObjectPool<RemoveEvent> pool = new DefaultObjectPool<RemoveEvent>(new Policy());
				internal static RemoveEvent FromPool(JsObject obj, string @event)
				{
					var request = pool.Get();
					request.obj = obj;
					request.@event = @event;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private RemoveEvent() : base("removeevent") { }
				public required string @event { get; set; }
			}

			public sealed class Return : Request, IDisposable
			{
				private class Policy : PooledObjectPolicy<Return>
				{
					public override Return Create() => new() { obj = null, returnValue = null };
					public override bool Return(Return obj)
					{
						obj.returnValue = null;
						return true;
					}
				}
				private static ObjectPool<Return> pool = new DefaultObjectPool<Return>(new Policy());
				internal static Return FromPool(object? returnValue)
				{
					var request = pool.Get();
					request.returnValue = returnValue;
					return request;
				}
				public void Dispose() => pool.Return(this);

				private Return() : base("return") { }
				public required object? returnValue { get; set; }
			}

		}

	}
}
