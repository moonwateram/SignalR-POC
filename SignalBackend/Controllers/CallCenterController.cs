using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using SignalBackend.SignalR;

namespace SignalBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CallCenterController : ControllerBase
	{
		private readonly ITicketManagement _ticketContract;
		private readonly IHubContext<TicketHubContext> _hubContext;

		public CallCenterController(ITicketManagement ticket, IHubContext<TicketHubContext> hubContext)
		{
			_ticketContract = ticket;
			_hubContext = hubContext;
		}

		[HttpGet]
		public bool Get(string username, string seconds, CancellationToken ct)
		{
			if (Int32.TryParse(seconds, out int secondsParsed))
			{
				var ticketMap = new TicketModel()
				{
					Username = username,
					Seconds = secondsParsed,
					IsSolved = false
				};
				return _ticketContract.GetTicket(ticketMap);
			}

			return false;
		}
	}

}