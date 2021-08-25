using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/media_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class MediaList : JsObject, Collections.ICollection<string>
	{
		protected internal MediaList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string mediaText { get => Get<string>(); set => Set(value); }

		public int Count => Get<int>("length");

		public void Add(string medium) => Method("appendMedium").Invoke(medium);

		public void Clear() => mediaText = "";

		public bool Remove(string medium)
		{
			try
			{
				_ = Method("deleteMedium").Invoke(medium);
				return true;
			}
			catch (NotFoundError)
			{
				return false;
			}
		}

		public IEnumerator<string> GetEnumerator() =>
			SymbolMethod<Iterator<string>>("iterator").Invoke();

		public override string ToString() => mediaText;

		bool ICollection<string>.Contains(string medium)
		{
			var original = mediaText;
			Add(medium);
			var @new = mediaText;
			if (original == @new)
			{
				return true;
			}
			else
			{
				_ = Remove(medium);
				return false;
			}
		}
	}
}
