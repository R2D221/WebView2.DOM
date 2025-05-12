namespace WebView2.DOM
{
	public enum DataTransferItemKind
	{
		/// <summary>
		/// "file"
		/// </summary>
		file,

		/// <summary>
		/// "string"
		/// </summary>
		@string,
	}

	public partial class DataTransferItem
	{
		public DataTransferItemKind kind => Get<DataTransferItemKind>();
	}
}