using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(text))]
	public sealed class title : HTMLElement, MetadataContent
	{
		public override NodeList childNodes { get; } = new TextNodeList();

		public string text
		{
			get => childNodes.Count switch
			{
				0 => "",
				1 => ((Text)childNodes[0]).data,
				_ => throw new System.Exception(),
			};

			set
			{
				childNodes.Clear();
				_ = ((IList)childNodes).Add(value);
			}
		}
	}
}
