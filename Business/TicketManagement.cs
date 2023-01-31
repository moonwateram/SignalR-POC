using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public class TicketManagement : ITicketManagement
	{
		private readonly ITicketRepository _ticketRepository;
		
		public TicketManagement (ITicketRepository ticketRepository)
		{
			_ticketRepository = ticketRepository;
		}
		bool ITicketManagement.GetTicket(TicketModel ticket)
		{
			if (ticket.Username.StartsWith('a'))
			{
				return _ticketRepository.GetTicketData(ticket);
			}
			else
			{
				return false;
			}
		}
	}
}
