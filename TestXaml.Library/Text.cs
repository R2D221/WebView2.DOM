using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[ContentProperty(nameof(data))]
	[DebuggerDisplay("#text {data}")]
	public sealed class Text : Node
	{
		public string data { get; set; }

		public Text(string text) => data = text;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializedata(XamlDesignerSerializationManager manager)
		{
			//dynamic dynamicManager = new ReflectionDynamicObject(manager);

			return manager != null/* && dynamicManager.XmlWriter == null*/;
		}
	}
}
