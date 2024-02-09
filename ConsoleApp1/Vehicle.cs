using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Vehicle
	{
		private string vehicleType { get; set; }
		private string licensePlateNo { get; set; }
		private int iuNo { get; set; }

		public Vehicle(string v, string l, int i)
		{
			vehicleType = v;
			licensePlateNo = l;
			iuNo = i;
		}
	}
}
