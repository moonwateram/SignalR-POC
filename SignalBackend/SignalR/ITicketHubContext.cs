namespace SignalBackend.SignalR
{
	public interface ITicketHubContext
	{
		Task SendToys(string user, string messageback);
	}
}
