# WebView2.DOM
<a href="https://www.nuget.org/packages/WebView2.DOM/"><img src="https://img.shields.io/nuget/v/WebView2.DOM" /></a>

C# DOM bindings to be used with WebView2.

**This is still beta software, not ready for production**

## Introduction

With this library you can control the contents of a WebView2 directly within C#, with all the benefits of type safety that C# gives. For example, you can do this:

```csharp
using WebView2.DOM;
using static WebView2.DOM.HTMLElementTag;

// ...

var document = window.document;

// Type-safe element creation
var b = document.createHTMLElement(button); // b is HTMLButtonElement

// C# events
b.onclick += (s, e) => window.alert("Hi from C#!"); 

// Notice the use of LINQ
var divs = document.body.children.Where(x => x is HTMLDivElement);
```

## Requirements

You can install the library from NuGet. https://www.nuget.org/packages/WebView2.DOM/

You need .NET 5.0 and [Microsoft Edge WebView2](https://docs.microsoft.com/en-us/microsoft-edge/webview2/).

This library is mainly tested with WPF, but WinForms should work as well. I haven't tested WinUI yet, but can be included in the future.

## How to use it

you need to set up the WebView2 this way:

```csharp
using WebView2.DOM;

// ...

// webView is a WPF WebView2
await webView.EnsureCoreWebView2Async();
// InitAsync will register the necessary JS for the magic to work
await WebView2DOM.InitAsync(webView);
// CoreWebView2 already includes a DOMContentLoadedEvent, but it's not present
// in the WPF object. We use this helper for simplicity.
webView.DOMContentLoaded().Handler += async (s, e) =>
{
	// With this we get the DOM available in C#
	await webView.InvokeInBrowserContextAsync(DOMContentLoaded);
};

void DOMContentLoaded(WebView2.DOM.Window window)
{
	// window is the JS Window object, with all the properties you expect
}
```

You can also see the sample project for more scenarios.

## How does it work

With the help of ExecuteScriptAsync and host objects, we run a loop in JavaScript where we listen to commands requested from C#. All DOM objects inherit from JsObject, and when a property or method is invoked, JsObject serializes the call and sends it to the JS loop, and waits for the response. You can see the source code for more details.

## Benefits

* Controlling the DOM from C#. This is my main motivation, since I like C#'s type safety and .NET's standard library. I'm not too fond of TypeScript because it ultimately has the same quirks as JavaScript.
* Easier communication between the web view's code and the host code. You can invoke a change in WPF's UI directly from a JavaScript event.

## Caveats

* This will be slower than just running JavaScript directly, since every time you invoke a property or method, the C# process needs to talk to the WebView2 process and vice versa. I haven't done any benchmarks yet for precise numbers.
* This is a work in progress, so I haven't finished all bindings (I'm doing them manually to ensure type safety, especially with enums and other special values). If you need a specific feature to be supported, you can open an issue.
* You can only use this in desktop projects. This is not a way to use C# directly on a web browser.

## Similar projects (not mine)

* [Bridge.NET](https://github.com/bridgedotnet/Bridge). Compiles C# to JavaScript. Can be run in the browser.
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). Compiles C# to WebAssembly. Can also be run in the browser.

## License

MIT
