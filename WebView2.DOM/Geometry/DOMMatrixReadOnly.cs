using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix_read_only.idl

	public class DOMMatrixReadOnly : JsObject
	{
		private static readonly AsyncLocal<JsObject?> _static = new();
		private static JsObject @static => _static.Value ??=
			window.Instance.Get<JsObject>(nameof(DOMMatrixReadOnly));

		protected internal DOMMatrixReadOnly(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public DOMMatrixReadOnly()
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct();

		public DOMMatrixReadOnly(string init)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(init);

		public DOMMatrixReadOnly(IReadOnlyList<double> init)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(init);

		public static DOMMatrixReadOnly fromMatrix(DOMMatrixInit other) =>
			@static.Method<DOMMatrixReadOnly>().Invoke(other);

		public static DOMMatrixReadOnly fromMatrix(DOMMatrixReadOnly other) =>
			@static.Method<DOMMatrixReadOnly>().Invoke(other);

		public static DOMMatrixReadOnly fromFloat32Array(Float32Array array32) =>
			@static.Method<DOMMatrixReadOnly>().Invoke(array32);

		public static DOMMatrixReadOnly fromFloat64Array(Float64Array array64) =>
			@static.Method<DOMMatrixReadOnly>().Invoke(array64);

		// These attributes are simple aliases for certain elements of the 4x4 matrix
		public double a => Get<double>();
		public double b => Get<double>();
		public double c => Get<double>();
		public double d => Get<double>();
		public double e => Get<double>();
		public double f => Get<double>();

		public double m11 => Get<double>();
		public double m12 => Get<double>();
		public double m13 => Get<double>();
		public double m14 => Get<double>();
		public double m21 => Get<double>();
		public double m22 => Get<double>();
		public double m23 => Get<double>();
		public double m24 => Get<double>();
		public double m31 => Get<double>();
		public double m32 => Get<double>();
		public double m33 => Get<double>();
		public double m34 => Get<double>();
		public double m41 => Get<double>();
		public double m42 => Get<double>();
		public double m43 => Get<double>();
		public double m44 => Get<double>();

		public bool is2D => Get<bool>();
		public bool isIdentity => Get<bool>();

		// Immutable transform methods

		public DOMMatrixReadOnly translate(double tx, double ty) =>
			Method<DOMMatrixReadOnly>().Invoke(tx, ty);

		public DOMMatrixReadOnly translate(double tx, double ty, double tz) =>
			Method<DOMMatrixReadOnly>().Invoke(tx, ty, tz);

		public DOMMatrixReadOnly scale(double scale) =>
			Method<DOMMatrixReadOnly>().Invoke(scale);

		public DOMMatrixReadOnly scale(double scaleX, double scaleY, double scaleZ = 1, double originX = 0, double originY = 0, double originZ = 0) =>
			(scaleZ, originX, originY, originZ) switch
			{
				(1, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY),
				(_, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY, scaleZ),
				(_, _, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY, scaleZ, originX),
				(_, _, _, 0) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY, scaleZ, originX, originY),
				(_, _, _, _) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY, scaleZ, originX, originY, originZ),
			};

		[Obsolete("Supported for legacy reasons to be compatible with SVGMatrix as defined in SVG 1.1. Authors are encouraged to use scale() instead.")]
		public DOMMatrixReadOnly scaleNonUniform(double scaleX = 1, double scaleY = 1) =>
			(scaleX, scaleY) switch
			{
				(1, 1) => Method<DOMMatrixReadOnly>().Invoke(),
				(_, 1) => Method<DOMMatrixReadOnly>().Invoke(scaleX),
				(_, _) => Method<DOMMatrixReadOnly>().Invoke(scaleX, scaleY),
			};

		public DOMMatrixReadOnly scale3d(double scale = 1, double originX = 0, double originY = 0, double originZ = 0) =>
			(scale, originX, originY, originZ) switch
			{
				(1, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(),
				(_, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(scale),
				(_, _, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(scale, originX),
				(_, _, _, 0) => Method<DOMMatrixReadOnly>().Invoke(scale, originX, originY),
				(_, _, _, _) => Method<DOMMatrixReadOnly>().Invoke(scale, originX, originY, originZ),
			};

		public DOMMatrixReadOnly rotate(double rotZ) =>
			Method<DOMMatrixReadOnly>().Invoke(rotZ);

		public DOMMatrixReadOnly rotate(double rotX, double rotY, double rotZ) =>
			Method<DOMMatrixReadOnly>().Invoke(rotX, rotY, rotZ);

		public DOMMatrixReadOnly rotateFromVector(double x = 0, double y = 0) =>
			(x, y) switch
			{
				(0, 0) => Method<DOMMatrixReadOnly>().Invoke(),
				(_, 0) => Method<DOMMatrixReadOnly>().Invoke(x),
				(_, _) => Method<DOMMatrixReadOnly>().Invoke(x, y),
			};

		public DOMMatrixReadOnly rotateAxisAngle(double x = 0, double y = 0, double z = 0, double angle = 0) =>
			(x, y, z, angle) switch
			{
				(0, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(),
				(_, 0, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(x),
				(_, _, 0, 0) => Method<DOMMatrixReadOnly>().Invoke(x, y),
				(_, _, _, 0) => Method<DOMMatrixReadOnly>().Invoke(x, y, z),
				(_, _, _, _) => Method<DOMMatrixReadOnly>().Invoke(x, y, z, angle),
			};

		public DOMMatrixReadOnly skewX(double sx = 0) =>
			Method<DOMMatrixReadOnly>().Invoke(sx);

		public DOMMatrixReadOnly skewY(double sy = 0) =>
			Method<DOMMatrixReadOnly>().Invoke(sy);

		public DOMMatrixReadOnly multiply(DOMMatrixInit other) =>
			Method<DOMMatrixReadOnly>().Invoke(other);

		public DOMMatrixReadOnly multiply(DOMMatrixReadOnly other) =>
			Method<DOMMatrixReadOnly>().Invoke(other);

		public DOMMatrixReadOnly flipX() =>
			Method<DOMMatrixReadOnly>().Invoke();

		public DOMMatrixReadOnly flipY() =>
			Method<DOMMatrixReadOnly>().Invoke();

		public DOMMatrixReadOnly inverse() =>
			Method<DOMMatrixReadOnly>().Invoke();

		public DOMPointReadOnly transformPoint(DOMPointInit point) =>
			Method<DOMPointReadOnly>().Invoke(point);

		public DOMPointReadOnly transformPoint(DOMPointReadOnly point) =>
			Method<DOMPointReadOnly>().Invoke(point);

		public Float32Array toFloat32Array() =>
			Method<Float32Array>().Invoke();

		public Float64Array toFloat64Array() =>
			Method<Float64Array>().Invoke();

		public override string ToString() => Method<string>("toString").Invoke();
		public DOMMatrixInit toJSON() => Method<DOMMatrixInit>().Invoke();
	}
}
