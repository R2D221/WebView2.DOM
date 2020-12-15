using Microsoft.Web.WebView2.Core;
using NodaTime;
using OneOf;
using OneOf.Types;
using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	#region canvas
	public class HTMLCanvasElement : HTMLElement
	{
		protected internal HTMLCanvasElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}
	}

#endregion
#region forms
#endregion
}
