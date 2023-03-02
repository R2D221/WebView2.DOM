using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/geometry/dom_matrix.idl

	public class DOMMatrix : DOMMatrixReadOnly
	{
		private static JsObject Static => window.Instance.GetCached<JsObject>(nameof(DOMMatrix));

		public DOMMatrix() =>
			Construct();

		public DOMMatrix(string init) =>
			Construct(init);

		public DOMMatrix(IReadOnlyList<double> init) =>
			Construct(init);

		new public static DOMMatrix fromMatrix(DOMMatrixInit other) =>
			Static.Method<DOMMatrix>().Invoke(other);

		new public static DOMMatrix fromMatrix(DOMMatrixReadOnly other) =>
			Static.Method<DOMMatrix>().Invoke(other);

		new public static DOMMatrix fromFloat32Array(Float32Array array32) =>
			Static.Method<DOMMatrix>().Invoke(array32);

		new public static DOMMatrix fromFloat64Array(Float64Array array64) =>
			Static.Method<DOMMatrix>().Invoke(array64);

		// These attributes are simple aliases for certain elements of the 4x4 matrix
		new public double a { get => Get<double>(); set => Set(value); }
		new public double b { get => Get<double>(); set => Set(value); }
		new public double c { get => Get<double>(); set => Set(value); }
		new public double d { get => Get<double>(); set => Set(value); }
		new public double e { get => Get<double>(); set => Set(value); }
		new public double f { get => Get<double>(); set => Set(value); }

		new public double m11 { get => Get<double>(); set => Set(value); }
		new public double m12 { get => Get<double>(); set => Set(value); }
		new public double m13 { get => Get<double>(); set => Set(value); }
		new public double m14 { get => Get<double>(); set => Set(value); }
		new public double m21 { get => Get<double>(); set => Set(value); }
		new public double m22 { get => Get<double>(); set => Set(value); }
		new public double m23 { get => Get<double>(); set => Set(value); }
		new public double m24 { get => Get<double>(); set => Set(value); }
		new public double m31 { get => Get<double>(); set => Set(value); }
		new public double m32 { get => Get<double>(); set => Set(value); }
		new public double m33 { get => Get<double>(); set => Set(value); }
		new public double m34 { get => Get<double>(); set => Set(value); }
		new public double m41 { get => Get<double>(); set => Set(value); }
		new public double m42 { get => Get<double>(); set => Set(value); }
		new public double m43 { get => Get<double>(); set => Set(value); }
		new public double m44 { get => Get<double>(); set => Set(value); }

		// Mutable transform methods

		public DOMMatrix multiplySelf(DOMMatrixInit other) =>
			Method<DOMMatrix>().Invoke(other);

		public DOMMatrix multiplySelf(DOMMatrixReadOnly other) =>
			Method<DOMMatrix>().Invoke(other);

		public DOMMatrix preMultiplySelf(DOMMatrixInit other) =>
			Method<DOMMatrix>().Invoke(other);

		public DOMMatrix preMultiplySelf(DOMMatrixReadOnly other) =>
			Method<DOMMatrix>().Invoke(other);

		public DOMMatrix translateSelf(double tx, double ty) =>
			Method<DOMMatrix>().Invoke(tx, ty);

		public DOMMatrix translateSelf(double tx, double ty, double tz) =>
			Method<DOMMatrix>().Invoke(tx, ty, tz);

		public DOMMatrix scaleSelf(double scale) =>
			Method<DOMMatrix>().Invoke(scale);

		public DOMMatrix scaleSelf(double scaleX, double scaleY, double scaleZ = 1, double originX = 0, double originY = 0, double originZ = 0) =>
			(scaleZ, originX, originY, originZ) switch
			{
				(1, 0, 0, 0) => Method<DOMMatrix>().Invoke(scaleX, scaleY),
				(_, 0, 0, 0) => Method<DOMMatrix>().Invoke(scaleX, scaleY, scaleZ),
				(_, _, 0, 0) => Method<DOMMatrix>().Invoke(scaleX, scaleY, scaleZ, originX),
				(_, _, _, 0) => Method<DOMMatrix>().Invoke(scaleX, scaleY, scaleZ, originX, originY),
				(_, _, _, _) => Method<DOMMatrix>().Invoke(scaleX, scaleY, scaleZ, originX, originY, originZ),
			};

		public DOMMatrix scale3dSelf(double scale = 1, double originX = 0, double originY = 0, double originZ = 0) =>
			(scale, originX, originY, originZ) switch
			{
				(1, 0, 0, 0) => Method<DOMMatrix>().Invoke(),
				(_, 0, 0, 0) => Method<DOMMatrix>().Invoke(scale),
				(_, _, 0, 0) => Method<DOMMatrix>().Invoke(scale, originX),
				(_, _, _, 0) => Method<DOMMatrix>().Invoke(scale, originX, originY),
				(_, _, _, _) => Method<DOMMatrix>().Invoke(scale, originX, originY, originZ),
			};

		public DOMMatrix rotateSelf(double rotZ) =>
			Method<DOMMatrix>().Invoke(rotZ);

		public DOMMatrix rotateSelf(double rotX, double rotY, double rotZ) =>
			Method<DOMMatrix>().Invoke(rotX, rotY, rotZ);

		public DOMMatrix rotateFromVectorSelf(double x = 0, double y = 0) =>
			(x, y) switch
			{
				(0, 0) => Method<DOMMatrix>().Invoke(),
				(_, 0) => Method<DOMMatrix>().Invoke(x),
				(_, _) => Method<DOMMatrix>().Invoke(x, y),
			};

		public DOMMatrix rotateAxisAngleSelf(double x = 0, double y = 0, double z = 0, double angle = 0) =>
			(x, y, z, angle) switch
			{
				(0, 0, 0, 0) => Method<DOMMatrix>().Invoke(),
				(_, 0, 0, 0) => Method<DOMMatrix>().Invoke(x),
				(_, _, 0, 0) => Method<DOMMatrix>().Invoke(x, y),
				(_, _, _, 0) => Method<DOMMatrix>().Invoke(x, y, z),
				(_, _, _, _) => Method<DOMMatrix>().Invoke(x, y, z, angle),
			};

		public DOMMatrix skewXSelf(double sx = 0) =>
			Method<DOMMatrix>().Invoke(sx);

		public DOMMatrix skewYSelf(double sy = 0) =>
			Method<DOMMatrix>().Invoke(sy);

		public DOMMatrix invertSelf() =>
			Method<DOMMatrix>().Invoke();

		public DOMMatrix setMatrixValue(string transformList) =>
			Method<DOMMatrix>().Invoke(transformList);
	}
}
