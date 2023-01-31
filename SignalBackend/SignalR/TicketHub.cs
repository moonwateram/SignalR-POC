using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalBackend.SignalR
{
	public class TicketHub : Hub<ITicketHub>
	{
		//public async Task SendHelp(string user, string seconds)
		//{
		//	if (Int32.TryParse(seconds, out int secondsParsed))
		//	{
		//		for (int i = 0; i < secondsParsed; i++)
		//		{
		//			await Clients.All.SendAsync("HelpSent", user, $"Sending help in {secondsParsed - i} seconds");
		//			await Task.Delay(1000);
		//		}

		//		await Clients.All.SendAsync("HelpSent", user, "Help sent");
		//	}
		//	else
		//	{
		//		await Clients.All.SendAsync("HelpSent", user, "There was a problem, try again");
		//	}
		//}

		//public async Task SendFood(string user, string message)
		//{
		//	await Clients.All.SendAsync("SendFood", user, "Here is a banana");
		//}

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
