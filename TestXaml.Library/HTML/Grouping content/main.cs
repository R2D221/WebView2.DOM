namespace WebView2.Markup
{
	public sealed class main : HTMLElement, FlowContent, addressContent, header_footer_Content, dtContent
	{
		// The spec says this:
		//
		// A hierarchically correct main element is one whose ancestor elements are limited to html, body, div,
		// form without an accessible name, and autonomous custom elements. Each main element must be
		// a hierarchically correct main element.
		//
		//
		// Therefore, if I'm understanding correctly, <main> can only be a child of <body>, <div> and <form>.
#warning content model
	}
}
