using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Refactor.WebView2.DOM.Interop;

internal static class ComObject
{
	private delegate object? InvokeDispMethodDelegate(
		string name,
		BindingFlags invokeAttr,
		object target,
		object?[]? args,
		bool[]? byrefModifiers,
		int culture,
		string[]? namedParameters);

	private static readonly Assembly assembly = typeof(Type).Assembly;

	private static readonly InvokeDispMethodDelegate InvokeDispMethod =
		(InvokeDispMethodDelegate)Delegate.CreateDelegate(
			typeof(InvokeDispMethodDelegate),
			assembly.GetType("System.__ComObject"),
			assembly.GetType("System.RuntimeType")!.GetMethod("InvokeDispMethod", BindingFlags.NonPublic | BindingFlags.Instance)!);

	public static object? GetProperty(object comObject, string property)
	{
		if (Marshal.IsComObject(comObject) is false) { throw new InvalidOperationException(); }

		return InvokeDispMethod(property, BindingFlags.GetProperty, comObject, null, null, 0x0400, null);
	}
}
