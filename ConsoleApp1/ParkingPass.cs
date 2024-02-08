using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.ParkingPass;

namespace ConsoleApp1
{
	public class ParkingPass
	{
		private bool isParked { get; set; }
		public bool IsParked { get; set; }
		public bool IsActive { get; set; }
		public string Type { get; set; }
		
		private double ChargeRate { get; set; }
		private int NumPass { get; set; }
		
		private PPState validState;
		private PPState expiredState;
		private PPState terminatedState;
		private PPState pendingApprovalState;

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
            pendingApprovalState = new PendingApprovalState(this);

			state = validState; // or pending approval???
            NumPass = 100;
        }
	
		public void ApplyPass()
		{
			// Implementation
		}

		public void RenewPass()
		{
			// Implementation 
		}

        DateTime endMonth = DateTime.Now;
        public void TerminatePass(string reason)
		{
            // Check if the parking pass is not active, indicating no active pass to terminate
            if (!IsActive)
            {
                Console.WriteLine("No active season parking pass found. Termination process aborted.");
                return;
            }
            if (Type == "Daily")
            {
				IsActive = false;
				Console.WriteLine("Daily Season Pass is terminated");
            }

			if (Type == "Monthly" && endMonth > DateTime.Now) // Checks if there are full months left to refund
            {
				double refundAmount = CalculateRefund();
				//paymentSystem.Refund(refundAmount);
				IsActive = false;
				Console.WriteLine($"Monthly season pass terminated. Refund of ${refundAmount} processed.");
				NumPass += 1;
			}

			else // If no full months are left, terminate without a refund 
			{
				IsActive = false;
				Console.WriteLine("Monthly season pass terminated");
			}

   //         else if (Type =="Monthly")
			//{
   //             if (Applicants.endMonth > DateTime.Now) 
   //             {
			//		double refundAmount = CalculateRefund();
			//		paymentSystem.Refund(refundAmount);
			//		IsActive = false;
   //                 Console.WriteLine($"Monthly season pass terminated. Refund of ${refundAmount} processed.");
			//		NumPass += 1;

   //                 //Console.WriteLine($"Terminating monthly pass due to: {reason}");
   //                 //this.setState(terminatedState); // Set the pass state to terminated
   //                 //MonthlySeasonPassCollecton.RefundUnused(); // Process the refund for any unused full months
   //                 //NumPass += 1;  
   //             }
   //             else // If no full months are left, terminate without a refund 
   //             {
			//		IsActive = false;
			//		Console.WriteLine("Monthly season pass terminated");


   //                 //Console.WriteLine("No full months left. Terminating without a refund.");
   //                 //this.setState(terminatedState);
   //                 //NumPass += 1;
   //             }
   //         }
            

			Console.WriteLine("Season Pass Terminated");
            /* Implementation */
        }

		
		public void TransferPass()
		{
			/* Implementation */
		}
		// Other properties and methods



		private double CalculateRefund()
		{
			/* Implementation */
			Console.WriteLine("Refunded");
			double refundAmount = 0;
			return refundAmount;
		}

		public class PaymentSystem
		{
			public void Refund(double amount)
			{
				/* Implementation */
				Console.WriteLine($"Refund {amount}");
			}
		}

	}

	
}
