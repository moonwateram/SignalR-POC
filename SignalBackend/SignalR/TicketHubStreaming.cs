using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace SignalBackend.SignalR
{
	public class TicketHubStreaming : Hub<ITicketHubStreaming>
	{
		public async IAsyncEnumerable<string> TriggerStream(
		int jobsCount,
		[EnumeratorCancellation]
		CancellationToken cancellationToken)
		{
			var i = 1;
			while (!cancellationToken.IsCancellationRequested)
			{
				cancellationToken.ThrowIfCancellationRequested();
				// run forever
				if (i % 2 == 0)
				{
					yield return $"Job running for {i} seconds";
				}
				await Task.Delay(1000, cancellationToken);
				i++;
			}
		}
	}
}
