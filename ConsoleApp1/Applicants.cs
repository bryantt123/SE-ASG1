using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Applicants : Observer
	{
		private Subject ppData;
		private string Name { get; set; }
		private string ID { get; set; }
		private string Username { get; set; }
		private string Password { get; set; }
		private int MobileNo { get; set; }
		private string PaymentMode { get; set; }
		private bool paymentMade { get; set; }
		private List<ParkingPass> ppList { get; set; }
        public List<ParkingPass> PpList { get; set; }
        public Applicants(Subject pp)
		{
			this.ppData = pp;
			ppData.registerObserver(this);

            // data
            PpList = new List<ParkingPass>
            {
				// Expired (daily still can renew)
                new ParkingPass { PassId = 1, PassType = "Monthly", EndMonth = new DateTime(2024, 1, 21)},
                new ParkingPass { PassId = 2, PassType = "Weekly", EndMonth = new DateTime(2024, 1, 21)},
				// Valid (both can renew)
				new ParkingPass { PassId = 3, PassType = "Monthly", EndMonth = new DateTime(2024, 3, 21)},
				new ParkingPass { PassId = 4, PassType = "Weekly", EndMonth = new DateTime(2024, 3, 21) }
        // Add more hardcoded data as needed
    };
        }
		public void Update()
		{
			Console.WriteLine("There are monthly passes available!");
		}

	}

}
