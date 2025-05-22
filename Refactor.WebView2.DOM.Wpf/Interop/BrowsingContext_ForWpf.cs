using Refactor.WebView2.DOM.Interop;
using System;

namespace Refactor.WebView2.DOM.Wpf.Interop;

internal sealed class BrowsingContext_ForWpf(JsThread thread, Action onDOMContentLoaded) : Refactor.WebView2.DOM.Interop.BrowsingContext(thread, onDOMContentLoaded)
{
}
