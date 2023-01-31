using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class TicketModel
	{
		public string Username { get; set; } = string.Empty;

		public int Seconds { get; set; }

		public bool IsSolved { get; set; } = false;
	}
}
