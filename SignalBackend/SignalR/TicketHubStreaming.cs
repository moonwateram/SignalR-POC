using Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SignalBackend.SignalR
{
	public class TicketHubStreaming : Hub<ITicketHubStreaming>
	{
		private readonly ITicketManagement _ticketContract;
		public TicketHubStreaming(ITicketManagement ticket)
		{
			_ticketContract = ticket;

		}
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

		public async IAsyncEnumerable<string> StreamStatusUpdateAsset(
		string assetname,
		[EnumeratorCancellation]
		CancellationToken cancellationToken)
		{
			await foreach(var status in _ticketContract.BusinessGetStatus(cancellationToken))
			{
				yield return $"{status} {assetname} status";
			}

		}
	}
}
