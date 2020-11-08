using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	internal class JsCollectionProxy
	{
		private readonly IEnumerable jsCollection;

		public JsCollectionProxy(IEnumerable jsCollection)
		{
			this.jsCollection = jsCollection;
		}

		public object?[] Results_View
		{
			get
			{
				Debugger.NotifyOfCrossThreadDependency();
				return jsCollection.Cast<object>().ToArray();
			}
		}
	}
}
