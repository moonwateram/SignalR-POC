namespace SignalBackend.SignalR
{
	public interface ITicketHubStreaming
	{
		IAsyncEnumerable<string> TriggerStream(int jobsCount, CancellationToken cancellationToken);

		IAsyncEnumerable<string> StreamStatusUpdateAsset(string assetName, CancellationToken cancellationToken);

	}
}
