using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	public static class WebView2DOM
	{
		public static async Task InitAsync(Microsoft.Web.WebView2.WinForms.WebView2 webView) =>
			await InitAsync(Unsafe.As<IWebView2>(webView));

		public static async Task InitAsync(Microsoft.Web.WebView2.Wpf.WebView2 webView) =>
			await InitAsync(Unsafe.As<IWebView2>(webView));

		private static async Task InitAsync(IWebView2 webView)
		{
			webView.ContentLoading_Add(static (sender, args) =>
			{
				if (sender is null) { throw new Exception(); }

				var webView = Unsafe.As<IWebView2>(sender);
				var coreWebView = webView.GetCoreWebView2();

				var prevContext = BrowsingContext.For(webView);

				if (prevContext is not null)
				{
					prevContext.Dispose();
					coreWebView.RemoveHostObjectFromScript("Coordinator");
				}

				var newContext = new BrowsingContext(webView, args.NavigationId);

				BrowsingContext.Set(webView, newContext);
				coreWebView.AddHostObjectToScript("Coordinator", newContext.HostObject);
			});

			_ = await webView.GetCoreWebView2().AddScriptToExecuteOnDocumentCreatedAsync(
				$$"""

				//const GetCoordinator = () => window.chrome.webview.hostObjects.sync.Coordinator;
				//const _Coordinator = window.chrome.webview.hostObjects.sync.Coordinator;
				//const GetCoordinator = () => _Coordinator;

				const Coordinator = window.chrome.webview.hostObjects.sync.Coordinator;

				Guid = (() =>
				{
					const x = {};

					x.NewGuid = function()
					{
						return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c)
						{
							var r = Math.random()*16|0, v = c === 'x' ? r : (r&0x3|0x8);
							return v.toString(16);
						});
					};

					return x;
				})();

				//Coordinator = GetCoordinator();

				WebView2DOM = (() =>
				{

					const objToId = new WeakMap();
					const idToObj = {};
					const refsHeldInCSharp = new Set();

					const idToCallback = {};

					const promises = new WeakMap();

					const registry = new FinalizationRegistry(id =>
					{
						delete idToObj[id];
						Coordinator.{{nameof(BrowsingContext._HostObject.Forget)}}(id);
					});

					const callbackRegistry = new FinalizationRegistry(id =>
					{
						delete idToCallback[id];
						Coordinator.{{nameof(BrowsingContext._HostObject.ForgetCallback)}}(id);
					});

					const x = {};

					x.SetId = function (obj, newId)
					{
						if (obj == null)
						{
							return;
						}

						objToId.set(obj, newId);
						idToObj[newId] = new WeakRef(obj);
						registry.register(obj, newId, obj);
					};

					x.GetId = function (obj)
					{
						if (obj == null)
						{
							return null;
						}

						const existingId = objToId.get(obj);

						if (existingId != null)
						{
							idToObj[existingId] = new WeakRef(obj);
							return existingId;
						}

						const newId = Guid.NewGuid();

						objToId.set(obj, newId);
						idToObj[newId] = new WeakRef(obj);
						registry.register(obj, newId, obj);
						return newId;
					};

					x.Forget = function (obj)
					{
						if (obj == null) { return; }
						const id = objToId.get(obj);

						objToId.delete(obj);
						delete idToObj[id];
						registry.unregister(obj);
						refsHeldInCSharp.delete(obj);
					};

					x.FreeCSharpRef = function (id)
					{
						const obj = WebView2DOM.GetObject(id);

						if (obj == null) { return; }

						refsHeldInCSharp.delete(obj);
					};

					x.GetObject = function (id)
					{
						if (id == null) { return null; }

						var weakRef = idToObj[id];
						if (weakRef == null) { return null; }

						var obj = weakRef.deref();
						if (obj == null)
						{
							//alert('Something is wrong');
							return null;
						}

						return obj;
					};

					x.ExtendPromise = function (promise)
					{
						if (promises.has(promise))
						{
							return promises.get(promise);
						}

						let isPending = true;

						let isFulfilled = false;
						let fulfilledValue = undefined;

						let isRejected = false;
						let rejectedReason = undefined;

						const extendedPromise = promise.then(
							value =>
							{
								isFulfilled = true;
								isPending = false;
								fulfilledValue = value;
								return value;
							},
							ex =>
							{
								isRejected = true;
								isPending = false;
								rejectedReason = ex;
								throw ex;
							}
						);

						extendedPromise.isPending = function () { return isPending };

						extendedPromise.getResult = function ()
						{
							if (isPending)
							{
								return undefined;
							}
							if (isFulfilled)
							{
								return fulfilledValue;
							}
							if (isRejected)
							{
								throw rejectedReason;
							}
						};

						promises.set(promise, extendedPromise);
						return extendedPromise;
					};

					x.pre_stringify = function (obj)
					{
						const objWindow = obj.constructor.constructor('return window')();

						if (typeof obj === 'bigint')
						{
							return { bigint: obj.toString() };
						}
						else if (obj instanceof objWindow.Array)
						{
							return obj.map(x => WebView2DOM.pre_stringify(x));
						}
						else if (false
							|| obj instanceof objWindow.DOMStringList
							|| obj instanceof objWindow.DOMRectList
							|| obj instanceof objWindow.TouchList
							|| obj instanceof objWindow.CSSNumericArray
							)
						{
							return Array.from(obj, x => WebView2DOM.pre_stringify(x));
						}
						else if (obj instanceof objWindow.Promise)
						{
							obj = WebView2DOM.ExtendPromise(obj);

							refsHeldInCSharp.add(obj);

							return { referenceId: WebView2DOM.GetId(obj), referenceType: obj.constructor.name };
						}
						else if (obj != null && typeof obj === 'object' && Object.getPrototypeOf(obj) !== objWindow.Object.prototype)
						{
							refsHeldInCSharp.add(obj);

							if (obj instanceof objWindow.HTMLInputElement)
							{
								return { referenceId: WebView2DOM.GetId(obj), referenceType: obj.constructor.name + ' ' + obj.type.replace('-', '_') };
							}
							else
							{
								return { referenceId: WebView2DOM.GetId(obj), referenceType: obj.constructor.name };
							}
						}
						else if (obj != null && typeof obj === 'object' && obj[objWindow.Symbol.toStringTag] != null)
						{
							refsHeldInCSharp.add(obj);

							return { referenceId: WebView2DOM.GetId(obj), referenceType: obj[objWindow.Symbol.toStringTag] };
						}
						else if (obj != null && typeof obj === 'object' && Object.getPrototypeOf(obj) === objWindow.Object.prototype)
						{
							const newObj = {};
							for (const key in obj)
							{
								newObj[key] = WebView2DOM.pre_stringify(obj[key]);
							}
							return newObj;
						}
						else
						{
							return obj;
						}
					};

					x.post_parse = function (obj)
					{
						if (obj instanceof Array)
						{
							return obj.map(x => WebView2DOM.post_parse(x));
						}
						else if (obj != null && typeof obj === 'object' && typeof obj.bigint === 'string')
						{
							return BigInt(obj.bigint);
						}
						else if (obj != null && typeof obj === 'object' && typeof obj.referenceId === 'string')
						{
							return WebView2DOM.GetObject(obj.referenceId);
						}
						else if (obj != null && typeof obj === 'object' && typeof obj.callbackId === 'string')
						{
							let callback = idToCallback[obj.callbackId]?.deref();

							if (callback == null)
							{
								//debugger;
								//console.log('call');
								//alert('I’m about to add the call');
								//debugger;
								//debugger;
								//debugger;

								callback = (...parameters) => {
									//Coordinator = GetCoordinator();

									//alert('I’m about to call');

									Coordinator.{{nameof(BrowsingContext._HostObject.Call)}}(
										obj.callbackId,
										JSON.stringify(WebView2DOM.pre_stringify(parameters)));
									return WebView2DOM.EventLoop('callback');
								};

								idToCallback[obj.callbackId] = new WeakRef(callback);
								callbackRegistry.register(callback, obj.callbackId);

								//debugger;
								//alert('I added the call');
								//debugger;
								//debugger;
								//debugger;
							}

							return callback;
						}
						else
						{
							return obj;
						}
					};

					x.EventLoop = function (runId)
					{
						const myIterator = {
							[Symbol.iterator]: function() { Coordinator.{{nameof(BrowsingContext._HostObject.iterator)}}(); return this; },
							next: function() { return JSON.parse(Coordinator.{{nameof(BrowsingContext._HostObject.next)}}()); }
						};

						let hasReturnValue = false;
						let returnValue = null;

						for (const item of myIterator)
						{
							try
							{
								const current = item;

								const referenceJson = current.{{nameof(BrowsingContext.Request.obj)}};

								const reference = referenceJson === null ? null : WebView2DOM.GetObject(referenceJson.referenceId);

								switch (current.{{nameof(BrowsingContext.Request.memberType)}})
								{
									case 'constructor':
									(() => {
										const typeName = current.{{nameof(BrowsingContext.Request.Constructor.typeName)}};
										const result = new window[typeName](...WebView2DOM.post_parse(current.{{nameof(BrowsingContext.Request.Constructor.args)}}));
										refsHeldInCSharp.add(result);
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnValue)}}(
											WebView2DOM.GetId(result)
										);
									})();
									break;
									case 'getter':
									(() => {
										const property = current.{{nameof(BrowsingContext.Request.Get.property)}};
										const result = reference[property];
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnValue)}}(
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									})();
									break;
									case 'setter':
									(() => {
										const property = current.{{nameof(BrowsingContext.Request.Set<object?>.property)}};
										reference[property] = WebView2DOM.post_parse(current.{{nameof(BrowsingContext.Request.Set<object?>.value)}});
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
									})();
									break;
									case 'deleter':
									(() => {
										const property = current.{{nameof(BrowsingContext.Request.Delete.property)}};
										delete reference[property];
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
									})();
									break;
									case 'invoke':
									(() => {
										const method = current.{{nameof(BrowsingContext.Request.Invoke.method)}};
										const result = reference[method](...WebView2DOM.post_parse(current.{{nameof(BrowsingContext.Request.Invoke.args)}}));

										if (result === undefined)
										{
											Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
										}
										else
										{
											Coordinator.{{nameof(BrowsingContext._HostObject.ReturnValue)}}(
												JSON.stringify(WebView2DOM.pre_stringify(result))
											);
										}
									})();
									break;
									case 'invokeSymbol':
									(() => {
										const method = current.{{nameof(BrowsingContext.Request.Invoke.method)}};
										const result = reference[Symbol[method]](...WebView2DOM.post_parse(current.{{nameof(BrowsingContext.Request.Invoke.args)}}));
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnValue)}}(
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									})();
									break;
									case 'addevent':
									(() => {
										const _reference = reference;
										const _event = current.{{nameof(BrowsingContext.Request.AddEvent.@event)}};
										_reference[_event] = args =>
										{
											Coordinator.{{nameof(BrowsingContext._HostObject.RaiseEvent)}}(
												JSON.stringify(WebView2DOM.pre_stringify(_reference)),
												_event,
												JSON.stringify(WebView2DOM.pre_stringify(args)));
											WebView2DOM.EventLoop(_event);
											WebView2DOM.Forget(args);
										};
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
									})();
									break;
									case 'removeevent':
									(() => {
										const event = current.{{nameof(BrowsingContext.Request.RemoveEvent.@event)}};
										reference[event] = null;
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
									})();
									break;
									case 'return':
									(() => {
										hasReturnValue = true;
										Coordinator.{{nameof(BrowsingContext._HostObject.ReturnVoid)}}();
										returnValue = WebView2DOM.post_parse(current.{{nameof(BrowsingContext.Request.Return.returnValue)}});
									})();
									break;
									default:
									(() => {
										Coordinator.{{nameof(BrowsingContext._HostObject.Throw)}}(
											JSON.stringify({
												constructor_name: 'SyntaxError',
												name: 'SyntaxError',
												message: 'SyntaxError'
											})
										);
									})();
									break;
								}
							}
							catch (ex)
							{
								let exJson = '{}';

								if (ex instanceof Error)
								{
									exJson =
										JSON.stringify({
											constructor_name: ex.constructor.name,
											name: ex.name,
											message: ex.message
										});
								}
								else if (typeof ex === 'string')
								{
									exJson =
										JSON.stringify({
											message: ex
										});
								}

								Coordinator.{{nameof(BrowsingContext._HostObject.Throw)}}(exJson);
							}
						}

						if (hasReturnValue)
						{
							return returnValue;
						}
					};

					Object.freeze(x);
					return x;
				})();

				WebView2DOM.SetId(window, Coordinator.{{nameof(BrowsingContext._HostObject.GetWindowId)}}());

				window.addEventListener('DOMContentLoaded', () => window.chrome.webview.postMessage('DOMContentLoaded'));
				""");
		}
	}
}
