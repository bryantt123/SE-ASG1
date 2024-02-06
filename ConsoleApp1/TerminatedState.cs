using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TerminatedState : PPState
    {
        private ParkingPass parkingPass;

        public TerminatedState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. Your pass has been terminated");
            parkingPass.IsParked = true;
        }
        public void exit()
        {
            Console.WriteLine("You cannot exit. Your pass has been terminated.");
            parkingPass.IsParked = false;
        }
    }
}
