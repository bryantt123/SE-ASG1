using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TerminatedState : PPState
    {
        private ParkingPass parkingPass;

        public TerminatedState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. Your pass has been terminated");
        }
        public void exit()
        {
            Console.WriteLine("You cannot exit. Your pass has been terminated.");
        }
        public void applyPass()
        {
            //implementation
        }
        public void renewPass(ParkingPass p)
        {
            //implementation
            Console.WriteLine("Unable to renew Season Parking Pass.");
        }
        public void transferPass()
        {
            Console.WriteLine("You cannot transfer a pass that has been terminated.");
        }
        public void terminatePass()
        {
            //implementation
        }
    }
}
