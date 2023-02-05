using Microsoft.AspNetCore.SignalR;

namespace SignalBackend.SignalR
{
	public class TicketHubContext: Hub<ITicketHubContext>
	{

		public async Task SendToys(string user, string messageback)
		{
			await Clients.All.SendToys(user, "Here is a monkey wood horse");
		}
	}
}
