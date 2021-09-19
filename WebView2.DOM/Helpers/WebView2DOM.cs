using Microsoft.Web.WebView2.Core;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	public static class WebView2DOM
	{
		public static async Task InitAsync(Microsoft.Web.WebView2.WinForms.WebView2 webView) =>
			await InitAsync(webView.GetCoreWebView());

		public static async Task InitAsync(Microsoft.Web.WebView2.Wpf.WebView2 webView) =>
			await InitAsync(webView.GetCoreWebView());

		public static async Task InitAsync(CoreWebView2 coreWebView)
		{
			coreWebView.AddHostObjectToScript("Coordinator", coreWebView.Coordinator());

			coreWebView.ContentLoading += (_, __) =>
			{
				coreWebView.Coordinator().CancelRunningThreads();
			};

			_ = await coreWebView.AddScriptToExecuteOnDocumentCreatedAsync($@"

				const GetCoordinator = () => window.chrome.webview.hostObjects.sync.Coordinator;

				Guid = (() =>
				{{
					const x = {{}};

					x.NewGuid = function()
					{{
						return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {{  
							var r = Math.random()*16|0, v = c === 'x' ? r : (r&0x3|0x8);  
							return v.toString(16);  
						}});
					}};

					return x;
				}})();

				Coordinator = GetCoordinator();

				WebView2DOM = (() =>
				{{

					const objToId = new WeakMap();
					const idToObj = {{}};
					const registry = new FinalizationRegistry(id =>
					{{
						GetCoordinator().{nameof(Coordinator.References_Remove)}(id);
					}});

					const callbackRegistry = new FinalizationRegistry(id =>
					{{
						GetCoordinator().{nameof(Coordinator.References_RemoveCallback)}(id);
					}});

					const x = {{}};

					x.SetId = function (obj, newId)
					{{
						if (obj == null)
						{{
							return;
						}}

						objToId.set(obj, newId);
						idToObj[newId] = obj;
						registry.register(obj, newId);
					}};

					x.GetId = function (obj)
					{{
						if (obj == null)
						{{
							return null;
						}}

						const existingId = objToId.get(obj);

						if (existingId != null)
						{{
							idToObj[existingId] = obj;
							return existingId;
						}}

						const newId = Guid.NewGuid();

						if (obj instanceof HTMLInputElement)
						{{
							Coordinator.{nameof(Coordinator.References_AddHTMLInputElement)}(newId, obj.type);
						}}
						else
						{{
							Coordinator.{nameof(Coordinator.References_Add)}(newId, obj.constructor.name);
						}}

						objToId.set(obj, newId);
						idToObj[newId] = obj;
						registry.register(obj, newId);
						return newId;
					}};

					x.GetObject = function (id)
					{{
						if (id == null) {{ return null; }}
						if (idToObj[id] == null) {{ return null; }}
						return idToObj[id];
					}};

					x.RemoveId = function (id)
					{{
						var obj = idToObj[id];
						delete idToObj[id];
					}};

					x.GetPromiseId = function (promise)
					{{
						let isComplete = true;
						const promiseId = Guid.NewGuid();
						Coordinator.{nameof(Coordinator.References_AddTask)}(promiseId);
						promise.then(
							value =>
							{{
								Coordinator = GetCoordinator();

								Coordinator.{nameof(Coordinator.FulfillPromise)}(
									WebView2DOM.GetId(window),
									promiseId,
									JSON.stringify(WebView2DOM.pre_stringify(value)),
									isComplete);
								//WebView2DOM.EventLoop();
							}},
							ex =>
							{{
								let exJson = '{{}}';

								if (ex instanceof Error)
								{{
									exJson =
										JSON.stringify({{
											constructor_name: ex.constructor.name,
											name: ex.name,
											message: ex.message
										}});
								}}
								else if (typeof ex === 'string')
								{{
									exJson =
										JSON.stringify({{
											message: ex
										}});
								}}

								Coordinator = GetCoordinator();

								Coordinator.{nameof(Coordinator.RejectPromise)}(
									WebView2DOM.GetId(window),
									promiseId,
									exJson,
									isComplete);
								//WebView2DOM.EventLoop();
							}}
						);
						isComplete = false;
						return promiseId;
					}};

					x.pre_stringify = function (obj)
					{{
						if (obj instanceof Array)
						{{
							return obj.map(x => WebView2DOM.pre_stringify(x));
						}}
						else if (false
							|| obj instanceof DOMStringList
							|| obj instanceof DOMRectList
							|| obj instanceof TouchList
							|| obj instanceof CSSNumericArray
							)
						{{
							return Array.from(obj, x => WebView2DOM.pre_stringify(x));
						}}
						else if (obj instanceof Promise)
						{{
							return {{ promiseId: WebView2DOM.GetPromiseId(obj) }};
						}}
						else if (obj != null && typeof obj === 'object' && Object.getPrototypeOf(obj) !== Object.prototype)
						{{
							return {{ referenceId: WebView2DOM.GetId(obj) }};
						}}
						else if (obj != null && typeof obj === 'object' && obj[Symbol.toStringTag] != null)
						{{
							return {{ referenceId: WebView2DOM.GetId(obj) }};
						}}
						else if (obj != null && typeof obj === 'object' && Object.getPrototypeOf(obj) === Object.prototype)
						{{
							const newObj = {{}};
							for (const key in obj)
							{{
								newObj[key] = WebView2DOM.pre_stringify(obj[key]);
							}}
							return newObj;
						}}
						else
						{{
							return obj;
						}}
					}};

					x.post_parse = function (obj)
					{{
						if (obj instanceof Array)
						{{
							return obj.map(x => WebView2DOM.post_parse(x));
						}}
						else if (obj != null && typeof obj === 'object' && typeof obj.referenceId === 'string')
						{{
							return WebView2DOM.GetObject(obj.referenceId);
						}}
						else if (obj != null && typeof obj === 'object' && typeof obj.callbackId === 'string')
						{{
							const callback = (...parameters) => {{
								Coordinator = GetCoordinator();

								Coordinator.{nameof(Coordinator.OnCallback)}(
									WebView2DOM.GetId(window),
									obj.callbackId,
									JSON.stringify(WebView2DOM.pre_stringify(parameters)));
								WebView2DOM.EventLoop();
							}};
							callbackRegistry.register(callback, obj.callbackId);
							return callback;
						}}
						else
						{{
							return obj;
						}}
					}};

					let alreadyInLoop = false;
					x.EventLoop = function ()
					{{
						if (alreadyInLoop) {{ return; }}
						alreadyInLoop = true;

						const windowId = WebView2DOM.GetId(window);

						const myIterator = {{
							[Symbol.iterator]: function() {{ return this; }},
							next: function() {{ return JSON.parse(Coordinator.{nameof(Coordinator.next)}(windowId)); }}
						}};

						for (const item of myIterator)
						{{
							try
							{{
								const current = JSON.parse(item);

								//if (WebView2DOM.GetId(window) !== current.nameof(CoordinatorCall.windowId))
								//{{
								//	continue;
								//}}

								const reference = WebView2DOM.GetObject(current.{nameof(CoordinatorCall.referenceId)});
								const memberName = current.{nameof(CoordinatorCall.memberName)};

								switch (current.{nameof(CoordinatorCall.memberType)})
								{{
									case 'constructor':
									(() => {{
										const result = new window[memberName](...WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)}));
										WebView2DOM.SetId(result, current.{nameof(CoordinatorCall.referenceId)});
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									case 'getter':
									(() => {{
										const result = reference[memberName];
										Coordinator.{nameof(Coordinator.ReturnValue)}(
											windowId,
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									}})();
									break;
									case 'setter':
									(() => {{
										reference[memberName] = WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)})[0];
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									case 'indexerGetter':
									(() => {{
										const parameters = WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)});
										const index = parameters[0];
										const result = reference[index];
										Coordinator.{nameof(Coordinator.ReturnValue)}(
											windowId,
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									}})();
									break;
									case 'indexerSetter':
									(() => {{
										const parameters = WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)});
										const index = parameters[0];
										const value = parameters[1];
										reference[index] = value;
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									case 'indexerDeleter':
									(() => {{
										const parameters = WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)});
										const index = parameters[0];
										delete reference[index];
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									case 'invoke':
									(() => {{
										const result = reference[memberName](...WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)}));
										Coordinator.{nameof(Coordinator.ReturnValue)}(
											windowId,
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									}})();
									break;
									case 'invokeSymbol':
									(() => {{
										const result = reference[Symbol[memberName]](...WebView2DOM.post_parse(current.{nameof(CoordinatorCall.parameters)}));
										Coordinator.{nameof(Coordinator.ReturnValue)}(
											windowId,
											JSON.stringify(WebView2DOM.pre_stringify(result))
										);
									}})();
									break;
									case 'addevent':
									(() => {{
										const _reference = reference;
										const _memberName = memberName;
										_reference[_memberName] = event =>
										{{
											Coordinator = GetCoordinator();

											Coordinator.{nameof(Coordinator.RaiseEvent)}(
												WebView2DOM.GetId(window),
												WebView2DOM.GetId(_reference),
												_memberName,
												WebView2DOM.GetId(event));
											WebView2DOM.EventLoop();
										}};
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									case 'removeevent':
									(() => {{
										reference[memberName] = null;
										Coordinator.{nameof(Coordinator.ReturnVoid)}(windowId);
									}})();
									break;
									default:
									(() => {{
										Coordinator.{nameof(Coordinator.Throw)}(
											windowId,
											JSON.stringify({{
												constructor_name: 'SyntaxError',
												name: 'SyntaxError',
												message: 'SyntaxError'
											}})
										);
									}})();
									break;
								}}
							}}
							catch (ex)
							{{
								let exJson = '{{}}';

								if (ex instanceof Error)
								{{
									exJson =
										JSON.stringify({{
											constructor_name: ex.constructor.name,
											name: ex.name,
											message: ex.message
										}});
								}}
								else if (typeof ex === 'string')
								{{
									exJson =
										JSON.stringify({{
											message: ex
										}});
								}}

								Coordinator.{nameof(Coordinator.Throw)}(windowId, exJson);
							}}
						}}

						alreadyInLoop = false;
					}};

					Object.freeze(x);
					return x;
				}})();

				window.addEventListener('DOMContentLoaded', () => window.chrome.webview.postMessage('DOMContentLoaded'));
			");
		}
	}
}
