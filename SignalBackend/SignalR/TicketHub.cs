using Microsoft.AspNetCore.SignalR;

namespace SignalBackend.SignalR
{
	public class TicketHub : Hub<ITicketHub>
	{
		public async Task SendHelp(string user, string seconds)
		{
			if (Int32.TryParse(seconds, out int secondsParsed))
			{
				for (int i = 0; i < secondsParsed; i++)
				{

					await Clients.All.SendHelp(user, $"Sending help to {user} in {secondsParsed - i} seconds");

					await Task.Delay(1000);
				}

				await Clients.All.SendHelp(user, "Help Sent");
			}
			else
			{
				await Clients.All.SendHelp(user, "Help was not possible at this time");
			}
		}

		public async Task SendFood(string user, string message)
		{
			await Clients.All.SendFood(user, "Here is a banana");
		}

	}
}
