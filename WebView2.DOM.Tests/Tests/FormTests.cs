using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using WebView2.DOM.Microsyntaxes;
using static WebView2.DOM.Tests.Global;

namespace WebView2.DOM.Tests
{
	[TestClass]
	public class FormTests
	{
		[TestMethod("Form elements are cast to the correct type")]
		public async Task FormElementsAreCastToTheCorrectType()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = @"
						<form>
							<label><input id='a'></label>
							<label><select id='b'></select></label>
							<label><textarea id='c'></textarea></label>
						</form>
					";

					var form = (HTMLFormElement)body.children.First();

					foreach (var element in form.elements)
					{
						Assert.That.IsInstanceOfType(element, out HTMLElement htmlElement);
						Assert.IsInstanceOfType(htmlElement, htmlElement.id switch
						{
							"a" => typeof(HTMLInputElement),
							"b" => typeof(HTMLSelectElement),
							"c" => typeof(HTMLTextAreaElement),
							_ => throw new InvalidOperationException(),
						});

						Assert.That.IsInstanceOfType(element, out ILabelableElement labelableElement);

						var label = labelableElement.labels.First();
						var labelControl = label.control;
						Assert.AreSame(element, labelControl);
					}
				}
				finally
				{
					body.innerHTML = "";
				}
			});

			//var a = f.elements["a"];
			//var b = f.elements["b"];
			//var c = f.elements["c"];

			//var label = new HTMLLabelElement();
			//var control = label.control;
		}

		[TestMethod("Form elements can be accessed by name")]
		public async Task FormElementsCanBeAccessedByName()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = @"
						<form>
							<input name='a' value='1'>
							<select name='b'>
								<option selected>2.1</option>
								<option selected>2.2</option>
							</select>
							<textarea name='c'>3</textarea>
							<input type='radio' name='d' value='-1'>
							<input type='radio' name='d' value='4' checked>
						</form>
					";

					var form = (HTMLFormElement)body.children.First();

					var a = form.elements["a"];
					var b = form.elements["b"];
					var c = form.elements["c"];
					var d = form.elements["d"];

					Assert.IsInstanceOfType(a.Value, typeof(HTMLInputElement));
					Assert.IsInstanceOfType(b.Value, typeof(HTMLSelectElement));
					Assert.IsInstanceOfType(c.Value, typeof(HTMLTextAreaElement));

					Assert.That.IsInstanceOfType(d.Value, out RadioNodeList dList);

					foreach (var item in dList)
					{
						Assert.IsInstanceOfType(item, typeof(HTMLInputElement.radio));
					}
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod("FormData items are cast to the correct type")]
		public async Task FormData()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var fd = new FormData();
				fd.append("one", "1.1");
				fd.append("one", "1.2");
				fd.append("two", "2");

				var one = fd.getAll("one");
				Assert.AreEqual(2, one.Count);

				var two = fd.get("two");

				two.Switch(
					(File f)/*	*/=> Assert.IsInstanceOfType(f, typeof(string)),
					(string s)/*	*/=> Assert.IsInstanceOfType(s, typeof(string)),
					@null/*	*/=> Assert.IsInstanceOfType(@null, typeof(string))
					);

				var three = fd.get("three");

				three.Switch(
					(File f)/*	*/=> Assert.IsNull(f),
					(string s)/*	*/=> Assert.IsNull(s),
					@null/*	*/=> Assert.IsNull(@null)
					);

				var list = fd.ToImmutableArray();

				Assert.AreEqual(3, list.Length);

				Assert.AreEqual("one", list[0].Key);
				Assert.AreEqual("1.1", list[0].Value.Value);

				Assert.AreEqual("one", list[1].Key);
				Assert.AreEqual("1.2", list[1].Value.Value);

				Assert.AreEqual("two", list[2].Key);
				Assert.AreEqual("2", list[2].Value.Value);
			});
		}

		[TestMethod]
		public async Task InputHidden()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=hidden value='foo'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.hidden input);

					Assert.AreEqual("foo", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputText()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=text value='foo'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.text input);

					Assert.AreEqual("foo", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputSearch()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=search value='foo'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.search input);

					Assert.AreEqual("foo", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputTel()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=tel value='+521234567890'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.tel input);

					Assert.AreEqual("+521234567890", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputUrl()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=url value='https://example.com'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.url input);

					Assert.AreEqual("https://example.com", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputEmail()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=email value='foo@example.com'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.email input);

					Assert.AreEqual("foo@example.com", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputPassword()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=password value='correct horse'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.password input);

					Assert.AreEqual("correct horse", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputDate()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=date value='2000-01-01' min='1970-01-01'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.date input);

					Assert.AreEqual(new LocalDate(2000, 1, 1), input.value);
					Assert.AreEqual(new LocalDate(1970, 1, 1), input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputMonth()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=month value='2000-01' min='1970-01'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.month input);

					Assert.AreEqual(new YearMonth(2000, 1), input.value);
					Assert.AreEqual(new YearMonth(1970, 1), input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputWeek()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=week value='2000-W01' min='1970-W01'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.week input);

					Assert.AreEqual(new IsoWeek(2000, 1), input.value);
					Assert.AreEqual(new IsoWeek(1970, 1), input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputTime()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=time value='04:20:59' min='01:02:03'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.time input);

					Assert.AreEqual(new LocalTime(4, 20, 59), input.value);
					Assert.AreEqual(new LocalTime(1, 2, 3), input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputDateTime()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type='datetime-local' value='2000-01-01T04:20:59' min='1970-01-01T00:00:00'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.datetime_local input);

					Assert.AreEqual(new LocalDateTime(2000, 1, 1, 4, 20, 59), input.value);
					Assert.AreEqual(new LocalDateTime(1970, 1, 1, 0, 0, 0), input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputNumber()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type='number' value='69' min='3'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.number input);

					Assert.AreEqual(69, input.value);
					Assert.AreEqual(3, input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputRange()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type='range' value='69' min='3'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.range input);

					Assert.AreEqual(69, input.value);
					Assert.AreEqual(3, input.min);
					Assert.IsNull(input.max);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputColor()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type='color' value='#abcdef'>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.color input);

					Assert.AreEqual("#abcdef", input.value);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputCheckbox()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=checkbox value='foo' checked>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.checkbox input);

					Assert.AreEqual("foo", input.value);
					Assert.IsTrue(input.@checked);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputRadio()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=radio value='foo' checked>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.radio input);

					Assert.AreEqual("foo", input.value);
					Assert.IsTrue(input.@checked);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputFile()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=file>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.file input);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputSubmit()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=submit>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.submit input);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputImage()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=image>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.image input);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputButton()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=button>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.button input);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}

		[TestMethod]
		public async Task InputReset()
		{
			await wpfSyncContext;
			await webView.InvokeInBrowserContextAsync(window =>
			{
				var body = window.document.body;
				try
				{
					body.innerHTML = "<input type=reset>";
					var _input = body.children.First();

					Assert.That.IsInstanceOfType(_input, out HTMLInputElement.reset input);
				}
				finally
				{
					body.innerHTML = "";
				}
			});
		}
	}
}
