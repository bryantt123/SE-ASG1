using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ValidState : PPState
    {
        private ParkingPass parkingPass;

        public ValidState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You have parked.");
            parkingPass.IsParked = true;
        }
        public void exit()
        {
            Console.WriteLine("You have exited.");
            parkingPass.IsParked = false;
        }

        public void applyPass()
        {
            //implementation
        }
        public void renewPass()
        {
            //implementation
        }
        public void transferPass()
        {
            //implementation
        }
        public void terminatePass()
        {
            //implementation
        }

    } 
}
