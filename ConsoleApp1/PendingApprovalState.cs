﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PendingApprovalState : PPState
    {
        private ParkingPass parkingPass;

        public PendingApprovalState(ParkingPass pp)
        {
            parkingPass = pp;
        }

        public void park()
        {
            Console.WriteLine("You cannot park. You are still waiting for approval.");
            parkingPass.IsParked = true;
        }
        public void exit()
        {
            Console.WriteLine("You cannot exit. You are still waiting for approval.");
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
