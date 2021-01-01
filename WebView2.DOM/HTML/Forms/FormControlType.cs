using Microsoft.Web.WebView2.Core;
using OneOf;
using System;

namespace WebView2.DOM
{
	public enum FormControlType
	{
		// input

		hidden,
		text,
		search,
		tel,
		url,
		email,
		password,
		date,
		month,
		week,
		time,
		datetime_local,
		number,
		range,
		color,
		checkbox,
		radio,
		file,
		image,

		// input, button

		submit,
		reset,
		button,

		// select

		select_one,
		select_multiple,

		// textarea

		textarea,

		// output

		output,

		// fieldset

		fieldset,

		// object

		@object,
	}
}