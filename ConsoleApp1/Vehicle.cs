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
		public string VehicleType { get; set; }
		private string licensePlateNo { get; set; }
		public string LicensePlateNo { get; set; }
		private int iuNo { get; set; }
		public int IuNo { get; set; }
		private List<ParkingRecord> parkingRecords { get; set; }

		private ParkingPass parkingPass { get; set; }
		public ParkingPass ParkingPass { get; set; }

		private Applicants applicant { get; set; }

		public Vehicle() { }
		public Vehicle(string v, string l, int i)
		{
			vehicleType = v;
			licensePlateNo = l;
			iuNo = i;
		}
	}
}
