"use strict";

(() => {

	const hostObjects = window.chrome.webview.hostObjects;
	function bridge() { return hostObjects.sync.Bridge; }

	let lastId = 0;

	/** @type {WeakMap<object, number>} */
	const objToId = new WeakMap([[window, 0]]);

	/** @type {Map<number, WeakRef<object>>} */
	const idToObj = new Map([[0, new WeakRef(window)]]);

	/** @type {Set<object>} */
	const heldRefs = new Set();

	/** @type {FinalizationRegistry<number>} */
	const registry = new FinalizationRegistry(id => {
		idToObj.delete(id);
		throw new Error("Not implemented");
		//bridge().Forget(id);
	});

	/**
	 * 
	 * @param {object | null} obj
	 */
	function getId(obj) {
		if (obj === null) { return null; }

		let id = objToId.get(obj);

		if (id === undefined) {
			lastId++;
			id = lastId;
			objToId.set(obj, id);
			idToObj.set(id, new WeakRef(obj));
			registry.register(obj, id, obj);
		}

		return id;
	}

	/** @type {WeakMap<object, any>} */
	const prepareForSerialization_Memo = new WeakMap();

	/**
	 * 
	 * @param {any} value
	 */
	function serialize(value) {
		/**
		 * 
		 * @param {any} value
		 */
		function prepareForSerialization(value) {
			switch (typeof value) {
				case "boolean":
				case "number":
				case "string":
				case "undefined":
					return value;

				case "bigint":
					return value.toString();

				case "object":
					if (value === null) { return null; }

					let result = prepareForSerialization_Memo.get(value);

					if (result === undefined) {
						const inner = () => {
							const w = /** @type {typeof globalThis} */(value.constructor.constructor('return window')());

							if (value instanceof w.Array) {
								return value.map(x => prepareForSerialization(x));
							}

							if (value instanceof w.DOMStringList) {
								return Array.from(value, x => prepareForSerialization(x));
							}

							if (value instanceof w.DOMRectList) {
								return Array.from(value, x => prepareForSerialization(x));
							}

							if (value instanceof w.TouchList) {
								return Array.from(value, x => prepareForSerialization(x));
							}

							if (value instanceof w.CSSNumericArray) {
								return Array.from(value, x => prepareForSerialization(x));
							}

							const kind =
								Object.getPrototypeOf(value) !== w.Object.prototype ? "object" :
									value[w.Symbol.toStringTag] !== undefined ? "namespace" :
										"literal"
								;

							if (kind === "literal") {
								/** @type {{ [key: string]: any }} */
								const newObj = {};

								for (const key in value) {
									newObj[key] = prepareForSerialization(value[key]);
								}

								return newObj;
							}

							heldRefs.add(value);
							const id = getId(value);

							switch (kind) {
								case "namespace":
									return { id: id, type: value[w.Symbol.toStringTag] };
								case "object":
									if (value instanceof w.HTMLInputElement) {
										return { id: id, type: value.constructor.name + ' ' + value.type.replace('-', '_') };
									}
									else {
										return { id: id, type: value.constructor.name };
									}
							}
						};

						result = inner();
						prepareForSerialization_Memo.set(value, result);
					}

					return result;

				case "function":
				case "symbol":
					throw new Error("Not supported");
			}
		}

		return JSON.stringify(prepareForSerialization(value));
	}

	/**
	 * 
	 * @param {any} value
	 * @returns {any}
	 */
	function getValueAfterDeserialization(value) {
		if (value instanceof Array) {
			return value.map(x => getValueAfterDeserialization(x));
		}

		if (value !== null && typeof value === "object") {
			if ("#id" in value) {
				const result = idToObj.get(value["#id"])?.deref();
				console.log(result);
				return result;
			}
		}

		return value;
	}

	function execute() {
		const iterator = bridge().GetEnumerator();

		try {
			while (iterator.MoveNext()) {
				const item = iterator.Current;

				try {
					const request = /** @type {BridgeRequest} */(JSON.parse(item.Request));
					const obj = /** @type {any} */(idToObj.get(request.RefId)?.deref());

					switch (request.Type) {
						case "getter":
							item.Return(serialize(obj[request.Property]));
							break;
						//case "setter":
						//	iterator.Return(request.RefId);
						//	break;
						case "invoke":
							const result = obj[request.Method](...request.Args.map(x => getValueAfterDeserialization(x)));
							item.Return(serialize(result));
							break;

						default:
							throw new Error("Not supported");
					}
				}
				catch (e) {
					let error;

					if (e === null || e === undefined) {
						error = { name: "Error", message: "" };
					}
					else if (typeof e === "object") {
						const w = /** @type {typeof globalThis} */(e.constructor.constructor('return window')());

						if (e instanceof w.Error || e instanceof w.DOMException) {
							error = { name: e.name, message: e.message };
						}
						else {
							error = { name: "Error", message: e.toString() };
						}
					}
					else {
						error = { name: "Error", message: e.toString() };
					}

					item.Throw(JSON.stringify(error));
				}
			}
		}
		finally {
			iterator.Dispose();
		}
	}

	window.addEventListener('DOMContentLoaded', () => {
		bridge().OnDOMContentLoaded();
		execute();
	});

})();
