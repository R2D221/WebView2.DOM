using Refactor.WebView2.DOM.Interop;
using System;

namespace Refactor.WebView2.DOM.Wpf.Interop;

internal sealed class BrowsingContext_ForWpf(JsDispatcher dispatcher, Action onDOMContentLoaded) : Refactor.WebView2.DOM.Interop.BrowsingContext(dispatcher, onDOMContentLoaded)
{
}
