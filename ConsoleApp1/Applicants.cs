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
		private List<Vehicle> vehicles { get; set; }

		public Applicants(Subject pp, string n, string id, string un, string pw, int mn, string pm, string v, string l, int i)
		{
			this.ppData = pp;
			ppData.registerObserver(this);
			Name = n;
			ID = id;
			Username = un;
			Password = pw;
			MobileNo = mn;
			PaymentMode = pm;
			Vehicle vehicle = new Vehicle(v, l, i);
			vehicles.Add(vehicle);
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

                Console.WriteLine("Please input the following information:\n - Name\n - Month for application\n - Mobile Number\n - Payment mode\n - License plate number\n - IU number\n - Vehicle type\n");

                //User provides the system with all the information required
                string collatedInfo = Console.ReadLine();
                string[] applicationInfo = collatedInfo.Split(',');

                //Executing payment use case
                Console.WriteLine("Redirecting you to payment...");
                Console.WriteLine("Payment Successful!");

                DateTime startMonth = Convert.ToDateTime(applicationInfo[1]);
                DailySeasonPass dailySeasonPass = new DailySeasonPass("Daily", 1, startMonth);
                dailySeasonPass.setPending();



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
                
            }
            return true;

        }
    }

}
