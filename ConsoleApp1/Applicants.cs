using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Applicants : Observer
	{
		private string Name { get; set; }
		private string ID { get; set; }

		private string Username { get; set; }
		private string Password { get; set; }
		private int MobileNo { get; set; }
		private DateTime startMonth { get; set; }
		public DateTime endMonth { get; set; }
		private string PaymentMode { get; set; }
		private string LicensePlateNo { get; set; }
		private int IUNumber { get; set; }
		private string VehicleType { get; set; }
	}

}
