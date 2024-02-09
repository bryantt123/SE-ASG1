using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Carpark
	{
		private int CarparkId { get; set; }

		private string Description { get; set; }
		
		private string Location { get; set; }
		
		public List<ParkingRecord> ParkingRecords { get; set; }
	}
}
