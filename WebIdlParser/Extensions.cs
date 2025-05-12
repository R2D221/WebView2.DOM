using System.Text.RegularExpressions;

#if !NET7_0_OR_GREATER
internal static class Extensions
{
	public static IEnumerable<ValueMatch> EnumerateMatches(this Regex @this, ReadOnlySpan<char> input)
	{
		var inputString = new string(input.ToArray());

		return inner();
		IEnumerable<ValueMatch> inner()
		{
			var matches = @this.Matches(inputString);

			foreach (Match match in matches)
			{
				yield return new ValueMatch(match.Index, match.Length);
			}
		}
	}


	///// <summary>
	///// Searches an input span for all occurrences of a regular expression and returns a <see cref="ValueMatchEnumerator"/> to iterate over the matches.
	///// </summary>
	///// <remarks>
	///// Each match won't actually happen until <see cref="ValueMatchEnumerator.MoveNext"/> is invoked on the enumerator, with one match being performed per <see cref="ValueMatchEnumerator.MoveNext"/> call.
	///// Since the evaluation of the match happens lazily, any changes to the passed in input in between calls to <see cref="ValueMatchEnumerator.MoveNext"/> will affect the match results.
	///// The enumerator returned by this method, as well as the structs returned by the enumerator that wrap each match found in the input are ref structs which
	///// make this method be amortized allocation free.
	///// </remarks>
	///// <param name="this">Regex.</param>
	///// <param name="input">The span to search for a match.</param>
	///// <returns>A <see cref="ValueMatchEnumerator"/> to iterate over the matches.</returns>
	//public static Regex_ValueMatchEnumerator EnumerateMatches(this Regex @this, ReadOnlySpan<char> input) =>
	//	new Regex_ValueMatchEnumerator(@this, input, @this.RightToLeft ? input.Length : 0);

	//private static RunSingleMatchDelegate BuildRunSingleMatchDelegate()
	//{
	//	var regexRunnerModeType = typeof(Regex).Assembly.DefinedTypes.Where(x => x.Name == "RegexRunnerMode").Single();

	//	var @this = Expression.Parameter(typeof(Regex));
	//	var @param0 = Expression.Parameter(typeof(int));
	//	var @param1 = Expression.Parameter(typeof(int));
	//	var @param2 = Expression.Parameter(typeof(ReadOnlySpan<char>));
	//	var @param3 = Expression.Parameter(typeof(int));

	//	var RunSingleMatch_call =
	//		Expression.Call(
	//			@this,
	//			methodName: "RunSingleMatch",
	//			typeArguments: Array.Empty<Type>(),
	//			Expression.Convert(@param0, regexRunnerModeType),
	//			@param1,
	//			@param2,
	//			@param3);

	//	return
	//		Expression.Lambda<RunSingleMatchDelegate>(RunSingleMatch_call,
	//			@this,
	//			@param0,
	//			@param1,
	//			@param2,
	//			@param3).Compile();
	//}

	//private static RunSingleMatchDelegate runSingleMatchDelegate = BuildRunSingleMatchDelegate();

	//public static (bool Success, int Index, int Length, int TextPosition) RunSingleMatch(this Regex @this, RegexRunnerMode mode, int prevlen, ReadOnlySpan<char> input, int startat)
	//{
	//	return runSingleMatchDelegate(@this, (int)mode, prevlen, input, startat);
	//}
}

//internal delegate (bool Success, int Index, int Length, int TextPosition) RunSingleMatchDelegate(Regex regex, int mode, int prevlen, ReadOnlySpan<char> input, int startat);

namespace System.Text.RegularExpressions
{
	//	internal enum RegexRunnerMode
	//	{
	//		ExistenceRequired,
	//		BoundsRequired,
	//		FullMatchRequired,
	//	}

	//	/// <summary>
	//	/// Represents an enumerator containing the set of successful matches found by iteratively applying a regular expression pattern to the input span.
	//	/// </summary>
	//	/// <remarks>
	//	/// The enumerator has no public constructor. The <see cref="Regex.EnumerateMatches(ReadOnlySpan{char})"/> method returns a <see cref="Regex.ValueMatchEnumerator"/>
	//	/// object.The enumerator will lazily iterate over zero or more <see cref="ValueMatch"/> objects. If there is at least one successful match in the span, then
	//	/// <see cref="MoveNext"/> returns <see langword="true"/> and <see cref="Current"/> will contain the first <see cref="ValueMatch"/>. If there are no successful matches,
	//	/// then <see cref="MoveNext"/> returns <see langword="false"/> and <see cref="Current"/> throws an <see cref="InvalidOperationException"/>.
	//	///
	//	/// This type is a ref struct since it stores the input span as a field in order to be able to lazily iterate over it.
	//	/// </remarks>
	//	public ref struct Regex_ValueMatchEnumerator
	//	{
	//		private readonly Regex _regex;
	//		private readonly ReadOnlySpan<char> _input;
	//		private ValueMatch _current;
	//		private int _startAt;
	//		private int _prevLen;

	//		/// <summary>
	//		/// Creates an instance of the <see cref="ValueMatchEnumerator"/> for the passed in <paramref name="regex"/> which iterates over <paramref name="input"/>.
	//		/// </summary>
	//		/// <param name="regex">The <see cref="Regex"/> to use for finding matches.</param>
	//		/// <param name="input">The input span to iterate over.</param>
	//		/// <param name="startAt">The position where the engine should start looking for matches from.</param>
	//		internal Regex_ValueMatchEnumerator(Regex regex, ReadOnlySpan<char> input, int startAt)
	//		{
	//			_regex = regex;
	//			_input = input;
	//			_current = default;
	//			_startAt = startAt;
	//			_prevLen = -1;
	//		}

	//		/// <summary>
	//		/// Provides an enumerator that iterates through the matches in the input span.
	//		/// </summary>
	//		/// <returns>A copy of this enumerator.</returns>
	//		public readonly Regex_ValueMatchEnumerator GetEnumerator() => this;

	//		/// <summary>
	//		/// Advances the enumerator to the next match in the span.
	//		/// </summary>
	//		/// <returns>
	//		/// <see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the enumerator cannot find additional matches.
	//		/// </returns>
	//		public bool MoveNext()
	//		{
	//			(bool Success, int Index, int Length, int TextPosition) match = _regex.RunSingleMatch(RegexRunnerMode.BoundsRequired, _prevLen, _input, _startAt);
	//			if (match.Success)
	//			{
	//				_current = new ValueMatch(match.Index, match.Length);
	//				_startAt = match.TextPosition;
	//				_prevLen = match.Length;
	//				return true;
	//			}

	//			return false;
	//		}

	//		/// <summary>
	//		/// Gets the <see cref="ValueMatch"/> element at the current position of the enumerator.
	//		/// </summary>
	//		/// <exception cref="InvalidOperationException">Enumeration has either not started or has already finished.</exception>
	//		public readonly ValueMatch Current => _current;
	//	}

	/// <summary>
	/// Represents the results from a single regular expression match.
	/// </summary>
	/// <remarks>
	/// The <see cref="ValueMatch"/> type is immutable and has no public constructor. An instance of the <see cref="ValueMatch"/> struct is returned by the
	/// <see cref="Regex.ValueMatchEnumerator.Current"/> method when iterating over the results from calling <see cref="Regex.EnumerateMatches(ReadOnlySpan{char})"/>.
	/// </remarks>
	public readonly struct ValueMatch
	{
		private readonly int _index;
		private readonly int _length;

		/// <summary>
		/// Crates an instance of the <see cref="ValueMatch"/> type based on the passed in <paramref name="index"/> and <paramref name="length"/>.
		/// </summary>
		/// <param name="index">The position in the original span where the first character of the captured sliced span is found.</param>
		/// <param name="length">The length of the captured sliced span.</param>
		internal ValueMatch(int index, int length)
		{
			_index = index;
			_length = length;
		}

		/// <summary>
		/// Gets the position in the original span where the first character of the captured sliced span is found.
		/// </summary>
		public int Index => _index;

		/// <summary>
		/// Gets the length of the captured sliced span.
		/// </summary>
		public int Length => _length;
	}
}
#endif
