using Microsoft.Web.WebView2.Core;
using OneOf;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/html_form_controls_collection.idl

	public class HTMLFormControlsCollection : HTMLCollection<IFormControl>
	{
		private HTMLFormControlsCollection() { }

		new public OneOf<RadioNodeList, IFormControl> this[string name] =>
			IndexerGet<OneOf<RadioNodeList, IFormControl>?>(name) ??
			throw new ArgumentException(message: null, paramName: nameof(name));
	}
}