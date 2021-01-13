using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebView2.DOM.Tests
{
	public static class AssertExtensions
	{
#pragma warning disable RCS1175, IDE0060 // Quitar el parámetro no utilizado
		public static void IsInstanceOfType<T>(this Assert that, object? value, out T result)
			where T : notnull
		{
			Assert.IsInstanceOfType(value, typeof(T));
			result = (T)value!;
		}
#pragma warning restore IDE0060, RCS1175 // Quitar el parámetro no utilizado
	}
}
