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

	private static InvokeDispMethodDelegate? InvokeDispMethod;

	private static InvokeDispMethodDelegate Build(Type __comObjectType)
	{
		var type = typeof(Type).Assembly.GetType("System.RuntimeType");
		var method = type!.GetMethod("InvokeDispMethod", BindingFlags.NonPublic | BindingFlags.Instance);
		var InvokeDispMethod = (InvokeDispMethodDelegate)Delegate.CreateDelegate(
			typeof(InvokeDispMethodDelegate)
			,
			__comObjectType
			,
			method!
			);

		return InvokeDispMethod;
	}

	public static object? GetProperty(object comObject, string property)
	{
		if (Marshal.IsComObject(comObject) is false) { throw new InvalidOperationException(); }

		InvokeDispMethod ??= Build(comObject.GetType());

		return InvokeDispMethod(property, BindingFlags.GetProperty, comObject, null, null, 0x0400, null);
	}
}
