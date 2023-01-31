using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
	public class TicketRepository : ITicketRepository
	{
		bool ITicketRepository.GetTicketData(TicketModel ticket)
		{
			// database simulation
			return ticket.Username.StartsWith("a");
		}
	}
}
