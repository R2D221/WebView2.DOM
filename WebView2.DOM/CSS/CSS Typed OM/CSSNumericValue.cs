using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_numeric_value.idl

	public class CSSNumericValue : CSSStyleValue, IEquatable<CSSNumericValue>
	{
		protected internal CSSNumericValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		private static readonly AsyncLocal<Function?> _static = new();
		private static Function @static => _static.Value ??= window.Instance.Get<Function>(nameof(CSSNumericValue));

		public static implicit operator CSSNumericValue(double value) => CSS.number(value);

		public static CSSNumericValue operator +(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("add").Invoke(y);
		public static CSSNumericValue operator -(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("sub").Invoke(y);
		public static CSSNumericValue operator *(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("mul").Invoke(y);
		public static CSSNumericValue operator /(CSSNumericValue x, CSSNumericValue y) =>
			x.Method<CSSNumericValue>("div").Invoke(y);

		// min & max are found in class CSS instead

		public struct EqualityComparer : IEqualityComparer<CSSNumericValue>
		{
			public bool Equals([AllowNull] CSSNumericValue x, [AllowNull] CSSNumericValue y) =>
				ReferenceEquals(x, y)
				||
				(
					!(x is null) && !(y is null)
					&& x.Method<bool>("equals").Invoke(y)
				);

			public int GetHashCode([DisallowNull] CSSNumericValue obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.GetType());

				switch (obj)
				{
				case CSSUnitValue x:
				{
					hashCode.Add(x.unit);
					hashCode.Add(x.value);
					break;
				}
				case CSSMathSum x:
				{
					foreach (var value in x.values)
					{
						hashCode.Add(value);
					}
					break;
				}
				case CSSMathProduct x:
				{
					foreach (var value in x.values)
					{
						hashCode.Add(value);
					}
					break;
				}
				case CSSMathMin x:
				{
					foreach (var value in x.values)
					{
						hashCode.Add(value);
					}
					break;
				}
				case CSSMathMax x:
				{
					foreach (var value in x.values)
					{
						hashCode.Add(value);
					}
					break;
				}
				case CSSMathNegate x:
				{
					hashCode.Add(x.value);
					break;
				}
				case CSSMathInvert x:
				{
					hashCode.Add(x.value);
					break;
				}
				}
				return hashCode.ToHashCode();
			}
		}

		#region IEquatable
		public override int GetHashCode() =>
			default(EqualityComparer).GetHashCode(this);

		public override bool Equals(object? other) => other is CSSNumericValue that &&
			default(EqualityComparer).Equals(this, that);
		public bool Equals([AllowNull] CSSNumericValue that) =>
			default(EqualityComparer).Equals(this, that);
		public static bool operator ==(CSSNumericValue? x, CSSNumericValue? y) =>
			default(EqualityComparer).Equals(x, y);
		public static bool operator !=(CSSNumericValue? x, CSSNumericValue? y) =>
			!default(EqualityComparer).Equals(x, y);
		#endregion

		public CSSUnitValue to(string unit) => Method<CSSUnitValue>().Invoke(unit);
		public CSSMathSum toSum(params string[] units) => Method<CSSMathSum>().Invoke(args: units.ToArray<object?>());
		public CSSNumericType type() => Method<CSSNumericType>().Invoke();

		public static CSSNumericValue parse(string cssText) => @static.Method<CSSNumericValue>().Invoke(cssText);
	}
}
