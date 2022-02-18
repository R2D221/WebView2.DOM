using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(data))]
	[DebuggerDisplay("#text {data}")]
	public sealed class Text : Node, PhrasingContent, addressContent, header_footer_Content, dtContent
	{
		public string data { get; set; }

		public Text(string data) => this.data = data;








		//[EditorBrowsable(EditorBrowsableState.Never)]
		//public bool ShouldSerializedata(XamlDesignerSerializationManager manager)
		//{
		//	//dynamic dynamicManager = new ReflectionDynamicObject(manager);

		//	return manager != null/* && dynamicManager.XmlWriter == null*/;
		//}
	}
}
