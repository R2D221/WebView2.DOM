using System.Runtime.Serialization;

namespace WebView2.DOM
{
	public enum Enctype
	{
		_,
		[EnumMember(Value = "application/x-www-form-urlencoded")] application_x_www_form_urlencoded,
		[EnumMember(Value = "multipart/form-data")] multipart_form_data,
		[EnumMember(Value = "text/plain")] text_plain,
	}
}
