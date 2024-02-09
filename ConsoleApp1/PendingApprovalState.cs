using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PendingApprovalState : PPState
    {
        private ParkingPass parkingPass;

        public PendingApprovalState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. You are still waiting for approval.");
        }
        public void exit()
        {
            Console.WriteLine("You cannot exit. You are still waiting for approval.");
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
            Console.WriteLine("You cannot transfer a pass that is awaiting for approval.");
        }
        public void terminatePass()
        {
            //implementation
        }
    }
}
