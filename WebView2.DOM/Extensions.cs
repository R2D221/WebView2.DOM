using System.Collections.Generic;

internal static class Extensions
{
#if NETFRAMEWORK
	public static bool TryPeek<T>(this Stack<T> @this, out T result)
	{
		if (@this.Count == 0)
		{
			result = default!;
			return false;
		}
		else
		{
			result = @this.Peek();
			return true;
		}
	}
#endif
}