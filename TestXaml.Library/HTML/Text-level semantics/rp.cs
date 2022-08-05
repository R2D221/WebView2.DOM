using System.Collections;
using System.Windows.Markup;

namespace WebView2.Markup
{
	/// <summary>
	/// The rp element can be used to provide parentheses or other content around a ruby text component
	/// of a ruby annotation, to be shown by user agents that don't support ruby annotations.
	/// </summary>
	[ContentProperty(nameof(text))]
	public sealed class rp : HTMLElement
	{
		public rp() { childNodes = new TextNodeList(this); }
		public override NodeList childNodes { get; }

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
