namespace SignalBackend.SignalR
{
	public interface ITicketHubStreaming
	{
		IAsyncEnumerable<string> TriggerStream(int jobsCount, CancellationToken cancellationToken);

	}
}
