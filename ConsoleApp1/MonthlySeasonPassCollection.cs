﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class MonthlySeasonPassCollection : ParkingPass, Subject
	{
		private int NumPassLeft { get; set; }
		private string Status { get; set; }
		public void RefundUnused()
		{
            Console.WriteLine("Refund processed for unused full months.");
            /* Implementation */
        }
		// Other properties and methods
	}
}
