﻿using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/clipboard/data_transfer.idl

	public sealed class DataTransfer : JsObject
	{
		private DataTransfer() { }

		public string dropEffect { get => Get<string>(); set => Set(value); }
		public string effectAllowed { get => Get<string>(); set => Set(value); }

		public DataTransferItemList items => GetCached<DataTransferItemList>();

		public void setDragImage(Element image, int x, int y) => Method().Invoke(image, x, y);

		public IReadOnlyList<string> types => Get<ImmutableArray<string>>();
		public string getData(string format) => Method<string>().Invoke(format);
		public void setData(string format, string data) => Method().Invoke(format, data);
		public void clearData() => Method().Invoke();
		public void clearData(string format) => Method().Invoke(format);
		public FileList files => GetCached<FileList>();
	}
}
