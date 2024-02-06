using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class ParkingPass
	{
		private bool isParked { get; set; }
		public bool IsParked { get; set; }
		private double ChargeRate { get; set; }
		private int NumPass { get; set; }
		
		private PPState validState;
		private PPState expiredState;
		private PPState terminatedState;

		private PPState state;

        public void setState(PPState state)
        {
            this.state = state;
        }

		public ParkingPass()
		{	
			validState = new ValidState(this);
			expiredState = new ExpiredState(this);
			terminatedState = new TerminatedState(this);

			state = validState; // or pending approval???
		}
	
		public void ApplyPass()
		{
			// Implementation
		}

		public void RenewPass()
		{
			// Implementation 
		}
		public void TerminatePass()
		{
			/* Implementation */
		}
		public void TransferPass()
		{
			/* Implementation */
		}
		// Other properties and methods
	}
}
