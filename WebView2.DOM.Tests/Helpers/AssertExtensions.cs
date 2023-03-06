using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

public static class AssertExtensions
{
	public static void IsInstanceOfType<T>(this Assert that, object? value, out T result)
		where T : notnull
	{
		_ = that;
		Assert.IsInstanceOfType(value, typeof(T));
		result = (T)value!;
	}

	public static T ThrowsExceptionOrDerived<T>(this Assert that, Action action)
		where T : Exception
	{
		_ = that;
		try
		{
			action();
		}
		catch (T ex)
		{
			return ex;
		}
		//didn't catch
		{
			_ = Assert.ThrowsException<T>(() => { });
			throw new Exception();
		}
	}
}
