using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

		public async IAsyncEnumerable<string> BusinessGetStatus([EnumeratorCancellation]
		CancellationToken cancellationToken)
		{
			var i = 1;
			while (!cancellationToken.IsCancellationRequested)
			{
				cancellationToken.ThrowIfCancellationRequested();
				// run forever
				if (i % 2 == 0)
				{
					yield return $"update asset";
				}
				await Task.Delay(1000, cancellationToken);
				i++;
			}
		}
	}
}
