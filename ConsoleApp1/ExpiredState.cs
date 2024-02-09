using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ExpiredState : PPState
    {
        private ParkingPass parkingPass;

        public ExpiredState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. Your pass has expired.");
        }

        public void exit()
        {
            Console.WriteLine("You cannot exit. Your pass has expired.");
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
