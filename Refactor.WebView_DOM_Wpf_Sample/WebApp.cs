using Refactor.WebView2.DOM;
using System.Diagnostics;
using static Refactor.WebView2.DOM.Window;

namespace Refactor.WebView2_DOM_Wpf_Sample;

internal static class WebApp
{
	internal static void DOMContentLoaded()
	{
		var width = window.innerWidth;
		var height = window.innerHeight;

		//window.alert($"{width}, {height}");

		//window.queueMicrotask(() => window.alert($"{width}, {height}"));

		var document = window.document;
		document.body.append(document.createElement("a"));
		document.body.append(document.createElement("a"));
		document.body.append(document.createElement("a"));
		document.body.append(document.createElement("a"));

		var iterator = document.createNodeIterator(document.body, 1, node => throw new InvalidOperationException());
		var list = new List<Node>();

		while (iterator.nextNode() is { } currentNode)
		{
			list.Add(currentNode);
		}

		_ = list;
		Debugger.Break();
	}
}
