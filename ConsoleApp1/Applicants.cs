using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Applicants : Observer
    {
        private Subject ppData;
        private string name { get; set; }

        public string Name { get; set; }
        private string ID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string mobileNo { get; set; }
        public string MobileNo { get; set; }
        private string paymentMode { get; set; }
        public string PaymentMode { get; set; }

        private DateTime startMonth { get; set; }
        public DateTime StartMonth { get; set; }

        private DateTime endMonth { get; set; }
        public DateTime EndMonth { get; set; }


        private List<Vehicle> vehicles { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        private bool paymentMade { get; set; }
        public bool PaymentMade { get; set; }
        private List<ParkingPass> ppList { get; set; }
        public List<ParkingPass> PpList { get; set; }

        public Applicants() { }


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

			Vehicles = new List<Vehicle>
			{
				new Vehicle { VehicleType = "car" ,LicensePlateNo = "ABC1234D", IuNo = 1, ParkingPass = new ParkingPass { PassId = 1, PassType = "Monthly", EndMonth = new DateTime(2024, 1, 21)} },
				new Vehicle { VehicleType = "motorbike", LicensePlateNo = "BCDE2345F", IuNo= 2},
				new Vehicle { VehicleType = "car" ,LicensePlateNo = "CDEF3456G", IuNo = 3 }
			};

        }

		public void Update()
		{
			Console.WriteLine("There are monthly passes available!");
		}

    }

}
