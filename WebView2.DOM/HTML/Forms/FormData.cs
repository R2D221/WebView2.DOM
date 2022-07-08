using Microsoft.Web.WebView2.Core;
using OneOf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/form_data.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class FormData : JsObject, IEnumerable<KeyValuePair<string, OneOf<File, string>>>
	{
		public FormData() =>
			Construct();

		public FormData(HTMLFormElement form) =>
			Construct(form);

		public void append(string name, string value) =>
			Method().Invoke(name, value);
		public void append(string name, Blob value) =>
			Method().Invoke(name, value);
		public void append(string name, Blob value, string filename) =>
			Method().Invoke(name, value, filename);
		public void delete(string name) =>
			Method().Invoke(name);
		public OneOf<File, string>? get(string name) =>
			Method<OneOf<File, string>?>().Invoke(name);
		public IReadOnlyList<OneOf<File, string>> getAll(string name) =>
			Method<IReadOnlyList<OneOf<File, string>>>().Invoke(name);
		public bool has(string name) =>
			Method<bool>().Invoke(name);
		public void set(string name, string value) =>
			Method().Invoke(name, value);
		public void set(string name, Blob value) =>
			Method().Invoke(name, value);
		public void set(string name, Blob value, string filename) =>
			Method().Invoke(name, value, filename);

		public IEnumerator<KeyValuePair<string, OneOf<File, string>>> GetEnumerator() =>
			SymbolMethod<Iterator<KeyValuePair<string, OneOf<File, string>>>>("iterator").Invoke();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
