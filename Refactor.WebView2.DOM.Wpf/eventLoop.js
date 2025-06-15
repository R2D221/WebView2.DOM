"use strict";

class Exception extends Error {
	/** @type {{ [key: string]: typeof Exception; }} */
	static #classes = {};

	/**
	 * 
	 * @param {Error} wrapper
	 */
	static create(wrapper) {
		const constructor = Exception.#classes[wrapper.name] ??= new Function(`
			return class ${wrapper.name} extends Exception {
				constructor(wrapper) {
					super(wrapper);
				}
			}
		`)();

		return new constructor(wrapper);
	}

	/**
	 * 
	 * @param {any} cause
	 * @returns {ErrorOptions | undefined}
	 */
	static #getOptions(cause) {
		if (cause == null) { return; }

		return { cause: Exception.create(cause) };
	}

	#wrapper;

	/**
	 * 
	 * @param {Error} wrapper
	 */
	constructor(wrapper) {
		super(wrapper.message, Exception.#getOptions(wrapper.cause));
		this.#wrapper = wrapper;
	}

	get wrapper() { return this.#wrapper; }
};

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
	const pack_Memo = new WeakMap();

	/**
		* 
		* @param {any} value
		*/
	function pack(value) {
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

				let result = pack_Memo.get(value);

				if (result === undefined) {
					const inner = () => {
						const w = /** @type {typeof globalThis} */(value.constructor.constructor('return window')());

						if (value instanceof w.Array) {
							return value.map(x => pack(x));
						}

						if (value instanceof w.DOMStringList) {
							return Array.from(value, x => pack(x));
						}

						if (value instanceof w.DOMRectList) {
							return Array.from(value, x => pack(x));
						}

						if (value instanceof w.TouchList) {
							return Array.from(value, x => pack(x));
						}

						if (value instanceof w.CSSNumericArray) {
							return Array.from(value, x => pack(x));
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
								newObj[key] = pack(value[key]);
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
					pack_Memo.set(value, result);
				}

				return result;

			case "function":
			case "symbol":
				throw new Error("Not supported");
		}
	}

	/**
	 * 
	 * @param {any} value
	 * @returns {any}
	 */
	function unpack(value) {
		if (value instanceof Array) {
			for (let i = 0; i < value.length; i++) {
				value[i] = unpack(value[i]);
			}
			return value;
		}

		if (value !== null && typeof value === "function" /* Proxy is a function */) {
			switch (value["#type#"]) {
				case "reference":
					return idToObj.get(value.Id)?.deref();
				case "callback":
					return /** @type {(...args: unknown[]) => unknown} */((...args) => {
						for (let i = 0; i < args.length; i++) {
							args[i] = pack(args[i]);
						}
						value.Call(args);
						return execute();
					});
			}
		}

		return value;
	}

	function execute() {
		const iterator = bridge().GetEnumerator();

		try {
			while (iterator.MoveNext()) {
				const item = iterator.Current;

				let returnException = false;
				try {
					const request = item.Request;
					const obj = /** @type {any} */(idToObj.get(request.RefId)?.deref());

					switch (request.Type) {
						case "getter":
							item.Return(pack(obj[request.Property]));
							break;
						case "setter":
							obj[request.Property] = unpack(request.SetValue);
							item.ReturnVoid();
							break;
						case "invoke":
							const result = obj[request.Method](...request.Args.map(x => unpack(x)));
							if (result === undefined) {
								item.ReturnVoid();
							}
							else {
								item.Return(pack(result));
							}
							break;

						case "return void":
							return;

						case "return":
							return unpack(request.ReturnValue);

						case "throw":
							returnException = true;
							throw Exception.create(request.Exception);

						default:
							throw new Error("Not supported");
					}
				}
				catch (e) {
					if (returnException) { throw e; }

					let errorName = "Error";
					let errorMessage = e?.toString() ?? "";

					if (e !== null && typeof e === "object") {
						const w = /** @type {typeof globalThis} */(e.constructor.constructor('return window')());

						if (e instanceof w.Error || e instanceof w.DOMException) {
							errorName = e.name;
							errorMessage = e.message;
						}
					}

					if (e instanceof Exception) {
						item.ThrowWrapper(e.wrapper);
					}
					else {
						item.Throw(errorName, errorMessage);
					}
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
