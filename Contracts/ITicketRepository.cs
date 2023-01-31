﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface ITicketRepository
	{
		bool GetTicketData(TicketModel ticket);
	}
}
