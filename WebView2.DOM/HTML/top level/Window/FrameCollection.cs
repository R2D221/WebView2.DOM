using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed partial class FrameCollection : Window, IReadOnlyCollection<Window?>
	{
		private FrameCollection() { }

		public int Count => Get<int>("length");

		public IEnumerator<Window?> GetEnumerator()
		{
			for (uint i = 0; i < Count; i++)
			{
				yield return IndexerGet<Window?>(i);
			}
		}
	}
}