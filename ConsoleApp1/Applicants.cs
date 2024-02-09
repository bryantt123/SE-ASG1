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
		private string Name { get; set; }
		private string ID { get; set; }
		private string Username { get; set; }
		private string Password { get; set; }
		private int MobileNo { get; set; }
		private string PaymentMode { get; set; }
		private List<Vehicle> vehicles { get; set; }
		public List<Vehicle> Vehicles { get; set; }
        private bool paymentMade { get; set; }
		public bool PaymentMade { get; set; }
        private List<ParkingPass> ppList { get; set; }
        public List<ParkingPass> PpList { get; set; }
        //     public Applicants(Subject pp, string n, string id, string un, string pw, int mn, string pm, string v, string l, int i)
        //     {
        //this.ppData = pp;
        //ppData.registerObserver(this);
        //Name = n;
        //ID = id;
        //Username = un;
        //Password = pw;
        //MobileNo = mn;
        //PaymentMode = pm;
        //Vehicle vehicle = new Vehicle(v, l, i);
        //vehicles.Add(vehicle);
        //// data
        //PpList = new List<ParkingPass>
        //{
        //	// Expired (daily still can renew)
        //             new ParkingPass { PassId = 1, PassType = "Monthly", EndMonth = new DateTime(2024, 1, 21)},
        //	new ParkingPass { PassId = 2, PassType = "Weekly", EndMonth = new DateTime(2024, 1, 21)},
        //	// Valid (both can renew)
        //	new ParkingPass { PassId = 3, PassType = "Monthly", EndMonth = new DateTime(2024, 3, 21)},
        //	new ParkingPass { PassId = 4, PassType = "Weekly", EndMonth = new DateTime(2024, 3, 21) }
        //// Add more hardcoded data as needed
        //};


        //     }

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

		public void addVehicle(string v, string l, int i)
		{
			Vehicle veh = new Vehicle(v, l, i);
			vehicles.Add(veh);
		}

		public bool verifyUser(string un, string pw)
		{
			if (un == Username && pw == Password)
			{
				Console.WriteLine("Authentication success!");
				return true;
			}
			else
			{
				return false;
			}
		}
	}

}
