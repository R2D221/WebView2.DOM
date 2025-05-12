using System;

namespace WebView2.DOM
{
	public enum FileReaderReadyState
	{
		EMPTY = 0,
		LOADING = 1,
		DONE = 2,
	}

	public partial class FileReader
	{
		private ushort EMPTY/*   */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort LOADING/* */=> throw new NotImplementedException("Implemented as an enum instead");
		private ushort DONE/*    */=> throw new NotImplementedException("Implemented as an enum instead");

		public FileReaderReadyState readyState => Get<FileReaderReadyState>();
	}
}
