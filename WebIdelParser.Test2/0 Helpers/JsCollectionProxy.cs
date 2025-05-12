using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	internal class JsCollectionProxy
	{
		private readonly ICollection jsCollection;

		public JsCollectionProxy(ICollection jsCollection)
		{
			this.jsCollection = jsCollection;
		}

		public int Count
		{
			get
			{
				Debugger.NotifyOfCrossThreadDependency();
				return jsCollection.Count;
			}
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
