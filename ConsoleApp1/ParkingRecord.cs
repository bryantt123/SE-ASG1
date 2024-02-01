using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class ParkingRecord
	{
		private DateTime Entry { get; set; }
		private DateTime Exit { get; set; }
		private int ParkingId { get; set; }
		private double Amount { get; set; }
		public ParkingPass TransferPass()
		{
			// Implementation 
			return new ParkingPass();
		}
		// Other properties and methods
	}
}
