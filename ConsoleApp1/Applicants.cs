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

        public bool ApplyPass()
        {

            int passType;
            Console.WriteLine("[1] Daily\n[2] Monthly");

            Console.Write("Which pass are you applying for? ");
            passType = Convert.ToInt32(Console.ReadLine());

            if (passType == 1)
            {

                //Console.WriteLine("Please input the following information:\n - Name\n - Month for application\n - Mobile Number\n - Payment mode\n - License plate number\n - IU number\n - Vehicle type\n");

                ////User provides the system with all the information required
                //string collatedInfo = Console.ReadLine();
                //string[] applicationInfo = collatedInfo.Split(',');

                ////Executing payment use case
                //Console.WriteLine("Redirecting you to payment...");
                //Console.WriteLine("Payment Successful!");

                //DateTime startMonth = Convert.ToDateTime(applicationInfo[1]);
                //DailySeasonPass dailySeasonPass = new DailySeasonPass("Daily", 1, startMonth);
                //dailySeasonPass.setPending();

                Console.Write("Please enter your Name: ");

                Console.Write("Please enter the Month for application: ");

                Console.Write("Please enter your Mobile Number: ");
                string mobileNo = Console.ReadLine();


                Console.Write("Please enter your Payment mode: ");

                Console.Write("License plate number");

                Console.Write("IU number");

                Console.Write("Vehicle Type");



                Console.WriteLine("Daily Season Pass Object has been created");
            }

            else if (passType == 2)
            {
                MonthlySeasonPassCollection waitingList = MonthlySeasonPassCollection.getInstance();

                if (waitingList.NumPassLeft == 0)
                {
                    Console.WriteLine("No Monthly passes left. Sign up for waiting list? [Y/N]");
                    string signUp = Console.ReadLine().ToLower();

                    if (signUp == "Y")
                    {

                        waitingList.registerObserver(this);

                        Console.WriteLine("You are now in the waiting list for Monthly passes.");
                    }
                    else if (signUp == "N") 
                    {
                        Console.WriteLine("You have decided opt out.\nUse case ends.");
                        
                    }
                    return false;

                }
                else
                {
                    Console.WriteLine("Please input the following information:\n - Name\n - Month for application\n - Mobile Number\n - Payment mode\n - License plate number\n - IU number\n - Vehicle type\n");
                    //User provides the system with all the information required
                    string collatedInfo = Console.ReadLine();
                    string[] applicationInfo = collatedInfo.Split(',');
                }
                
            }
            return true;

        }
    }

}
