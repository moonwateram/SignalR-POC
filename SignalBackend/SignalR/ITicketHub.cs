namespace SignalBackend.SignalR
{
	public interface ITicketHub
	{
		Task SendHelp(string user, string messageback);

		Task SendFood(string user, string messageback);
	}
}
