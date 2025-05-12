using NodaTime;

namespace WebView2.DOM
{
	public partial class File
	{
		public Instant @lastModified => Instant.FromUnixTimeMilliseconds(Get<long>());
	}

	public partial record FilePropertyBag : BlobPropertyBag
	{
		public Instant @lastModified
		{
			get => Instant.FromUnixTimeMilliseconds(GetRequired<long>());
			init => Set(value.ToUnixTimeMilliseconds());
		}
	}
}
