using System.Threading;
using System.Threading.Channels;

internal static class ChannelExtensions
{
	public static bool WaitToRead<T>(this ChannelReader<T> reader, CancellationToken cancellationToken = default)
	{
		// I'm trying to find alternatives, but I think the best way that works is just
		// doing a blocking wait on the task.

		return reader.WaitToReadAsync(cancellationToken).AsTask().GetAwaiter().GetResult();

		//var vt = reader.WaitToReadAsync(cancellationToken);
		//var awaiter = vt.GetAwaiter();

		//if (awaiter.IsCompleted is false)
		//{
		//	var signal = new ManualResetEventSlim();
		//	awaiter.UnsafeOnCompleted(signal.Set);
		//	signal.Wait(cancellationToken);
		//	return awaiter.GetResult();
		//}

		//return awaiter.GetResult();
	}
}
