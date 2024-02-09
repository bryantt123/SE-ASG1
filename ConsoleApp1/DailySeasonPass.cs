using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class DailySeasonPass : ParkingPass
	{
		private double ChargeRate { get; set; }
        // Other properties and methods


        public DailySeasonPass(string pt, int pId, DateTime sm) : base(pt, pId, sm)
        {
            // Derived class constructor logic
            ChargeRate = 1.50;

        }
    }
}
