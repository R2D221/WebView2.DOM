namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/processing_instruction.idl

	public class ProcessingInstruction : CharacterData
	{
		public string target => Get<string>();

		// ProcessingInstruction implements LinkStyle
		// http://dev.w3.org/csswg/cssom/#requirements-on-user-agents-implementing-the-xml-stylesheet-processing-instruction
		public StyleSheet? sheet => Get<StyleSheet?>();
	}
}