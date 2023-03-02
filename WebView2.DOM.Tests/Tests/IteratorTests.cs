using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOf;
using System;
using System.Linq;
using System.Threading.Tasks;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class IteratorTests
	{
		[TestMethod("StylePropertyMapReadOnly Iterator")]
		public async Task StylePropertyMapReadOnly_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var styleMap = window.document.body.computedStyleMap();
				var enumerator = styleMap.GetEnumerator();
			});
		}

		[TestMethod("DOMTokenList Iterator")]
		public async Task DOMTokenList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var classList = window.document.body.classList;
				var enumerator = classList.GetEnumerator();
			});
		}


		[TestMethod("TextTrackList Iterator")]
		public async Task TextTrackList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var textTracks = window.document.createHTMLElement(HTMLElementTag.video).textTracks;
				var enumerator = textTracks.GetEnumerator();
			});
		}


		[TestMethod("TextTrackCueList Iterator")]
		public async Task TextTrackCueList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var video = window.document.createHTMLElement(HTMLElementTag.video);
				var track = video.addTextTrack(TextTrackKind.subtitles);
				var cues = track.cues!;
				var enumerator = cues.GetEnumerator();
			});
		}


		[TestMethod("FileList Iterator")]
		public async Task FileList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var file = window.document.createHTMLInputElement(InputType.file);
				file.multiple = true;
				var fileList = file.files;
				var enumerator = fileList.GetEnumerator();
			});
		}


		[TestMethod("SVGList Iterator")]
		public async Task SVGList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var tspan = window.document.createSVGElement(SVGElementTag.tspan);
				var enumerator = tspan.x.baseVal.GetEnumerator();
			});
		}


		[TestMethod("FormData Iterator")]
		public async Task FormData_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var formData = new FormData();
				var enumerator = formData.GetEnumerator();
			});
		}


		[TestMethod("StyleSheetList Iterator")]
		public async Task StyleSheetList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var styleSheetList = window.document.styleSheets;
				var enumerator = styleSheetList.GetEnumerator();
			});
		}


		[TestMethod("CSSRuleList Iterator")]
		public async Task CSSRuleList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var style = window.document.createHTMLElement(HTMLElementTag.style);
				_ = window.document.head.appendChild(style);
				var cssRuleList = window.document.styleSheets.OfType<CSSStyleSheet>().First().cssRules;
				style.remove();
				var enumerator = cssRuleList.GetEnumerator();
			});
		}


		[TestMethod("CSSStyleDeclaration Iterator")]
		public async Task CSSStyleDeclaration_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var style = window.document.createHTMLElement(HTMLElementTag.style);
				style.innerHTML = "body { }";
				_ = window.document.head.appendChild(style);
				var cssRuleList = window.document.styleSheets.OfType<CSSStyleSheet>().First().cssRules;
				var cssStyleDeclaration = cssRuleList.OfType<CSSStyleRule>().First().style;
				style.remove();
				var enumerator = cssStyleDeclaration.GetEnumerator();
			});
		}


		[TestMethod("MediaList Iterator")]
		public async Task MediaList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var style = window.document.createHTMLElement(HTMLElementTag.style);
				_ = window.document.head.appendChild(style);
				var mediaList = window.document.styleSheets.OfType<CSSStyleSheet>().First().media;
				style.remove();
				var enumerator = mediaList.GetEnumerator();
			});
		}


		[TestMethod("DataTransferItemList Iterator")]
		public async Task DataTransferItemList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				_ = typeof(DataTransferItemList);
				Assert.Inconclusive("No way to test this without firing events");
			});
		}


		[TestMethod("CSSTransformValue Iterator")]
		public async Task CSSTransformValue_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var transform = new CSSTransformValue(new[] { new CSSTranslate(new CSSUnitValue(0, "px"), new CSSUnitValue(0, "px")) });
				var enumerator = transform.GetEnumerator();
			});
		}


		[TestMethod("CSSUnparsedValue Iterator")]
		public async Task CSSUnparsedValue_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var transform = new CSSUnparsedValue(new OneOf<string, CSSVariableReferenceValue>[] { "4deg" });
				var enumerator = transform.GetEnumerator();
			});
		}


		[TestMethod("HTMLCollection Iterator")]
		public async Task HTMLCollection_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var htmlCollection = window.document.forms;
				var enumerator = htmlCollection.GetEnumerator();
			});
		}


		[TestMethod("NodeList Iterator")]
		public async Task NodeList_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var nodeList = window.document.querySelectorAll("*");
				var enumerator = nodeList.GetEnumerator();
			});
		}


		[TestMethod("NamedNodeMap Iterator")]
		public async Task NamedNodeMap_Iterator()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var namedNodeMap = window.document.body.attributes;
				var enumerator = namedNodeMap.GetEnumerator();
			});
		}
	}
}
