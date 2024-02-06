using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExpiredState : PPState
    {
        private ParkingPass parkingPass;

        public ExpiredState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. Your pass has expired.");
            parkingPass.IsParked = true;
        }

        public void exit()
        {
            Console.WriteLine("You cannot exit. Your pass has expired.");
            parkingPass.IsParked = false;
        }

    }
}
