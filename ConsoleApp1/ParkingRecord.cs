﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class ParkingRecord
	{
		private DateTime Entry { get; set; }
		
		private DateTime Exit { get; set; }
		
		private int ParkingId { get; set; }
		
		private double Amount { get; set; }
		
		private Carpark carpark { get; set; }

		private Vehicle vehicle { get; set; }

		public void purgeRecord()
		{
			//implementation
			Console.WriteLine("Purge record");
		}
		public void calculateRevenue()
		{
			//implementation
			Console.WriteLine("Revenue Calculated");
		}
		public ParkingPass TransferPass()
		{
			// Implementation 
			return new ParkingPass();
		}
		// Other properties and methods
	}
}
