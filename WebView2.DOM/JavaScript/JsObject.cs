using Microsoft.Web.WebView2.Core;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WebView2.DOM
{
	public class JsObject
	{
		internal readonly CoreWebView2 coreWebView;
		internal readonly string referenceId;

		protected internal JsObject(CoreWebView2 coreWebView, string referenceId)
		{
			this.coreWebView = coreWebView;
			this.referenceId = referenceId;
		}

		~JsObject()
		{
			try
			{
				var syncContext = coreWebView.GetSynchronizationContext();
				if (syncContext == SynchronizationContext.Current)
				{
					f();
				}
				else
				{
					syncContext.Post(_ => f(), null);
				}

				async void f()
				{
					try
					{
						_ = await coreWebView.ExecuteScriptAsync($@"
							(() => {{
								WebView2DOM.RemoveId('{referenceId}');
							}})()
						");
					}
					catch
					{
						// Don't want bad things to happen
					}
				}
			}
			catch
			{
				// Don't want bad things to happen
			}
		}

		internal @void Construct(params object?[] args)
		{
			coreWebView.References().Add(this);
			coreWebView.Coordinator().Call(new()
			{
				referenceId = referenceId,
				memberType = "constructor",
				memberName = GetType().Name,
				parameters = args,
			});
			return default!;
		}

		internal T Get<T>([CallerMemberName] string property = "") =>
			coreWebView.Coordinator().Call<T>(new()
			{
				referenceId = referenceId,
				memberType = "getter",
				memberName = property,
			});

		internal void Set<T>(T value, [CallerMemberName] string property = "") =>
			coreWebView.Coordinator().Call(new()
			{
				referenceId = referenceId,
				memberType = "setter",
				memberName = property,
				parameters = new object?[] { value },
			});

		internal T IndexerGet<T>(object? index) =>
			coreWebView.Coordinator().Call<T>(new()
			{
				referenceId = referenceId,
				memberType = "indexerGetter",
				parameters = new[] { index },
			});

		internal void IndexerSet<T>(object? index, T value) =>
			coreWebView.Coordinator().Call(new()
			{
				referenceId = referenceId,
				memberType = "indexerSetter",
				parameters = new[] { index, value },
			});

		internal void IndexerDelete(object? index) =>
			coreWebView.Coordinator().Call(new()
			{
				referenceId = referenceId,
				memberType = "indexerDeleter",
				parameters = new[] { index },
			});

		internal Invoker Method([CallerMemberName] string method = "")
			=> new Invoker(this, method);

		internal struct Invoker
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public @void Invoke(params object?[] args) =>
				@this.coreWebView.Coordinator().Call<string?>(new()
				{
					referenceId = @this.referenceId,
					memberType = "invoke",
					memberName = method,
					parameters = args,
				});
		}

		internal Invoker<T> Method<T>([CallerMemberName] string method = "")
			=> new Invoker<T>(this, method);

		internal struct Invoker<T>
		{
			public Invoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public T Invoke(params object?[] args) =>
				@this.coreWebView.Coordinator().Call<T>(new()
				{
					referenceId = @this.referenceId,
					memberType = "invoke",
					memberName = method,
					parameters = args,
				});
		}

		internal SymbolInvoker<T> SymbolMethod<T>([CallerMemberName] string method = "")
			=> new SymbolInvoker<T>(this, method);

		internal struct SymbolInvoker<T>
		{
			public SymbolInvoker(JsObject @this, string method) => (this.@this, this.method) = (@this, method);
			private readonly JsObject @this;
			private readonly string method;

			public T Invoke(params object?[] args) =>
				@this.coreWebView.Coordinator().Call<T>(new()
				{
					referenceId = @this.referenceId,
					memberType = "invokeSymbol",
					memberName = method,
					parameters = args,
				});
		}
	}
}
