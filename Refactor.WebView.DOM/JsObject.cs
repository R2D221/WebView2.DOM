using Refactor.WebView2.DOM.Interop;
using System;
using System.Diagnostics;

namespace Refactor.WebView2.DOM;

public abstract class JsObject
{
	private JsReference? reference;

	protected JsReference JS => reference ?? throw new InvalidOperationException();

	internal ulong Id => JS.Id;

	internal void SetJsReference(JsReference reference)
	{
		Debug.Assert(this.reference is null);

		this.reference = reference;
	}
}