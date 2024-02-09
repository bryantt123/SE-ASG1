using Microsoft.SqlServer.Server;
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
	class ParkingPass
	{
		private bool isParked { get; set; }
		public bool IsParked { get; set; }

        private string passType { get; set; }
        public string PassType { get; set; }
	
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

            state = pendingApprovalState;
            NumPass = 100;
        }

        public ParkingPass(MonthlySeasonPassCollection monthlyPasses)
        {
            this.monthlyPasses = monthlyPasses;
        }

	
		public void ApplyPass()
		{
			// Implementation
		}

		public void RenewPass()
		{
			// Implementation 
		}


        //DateTime endMonth = DateTime.Now;
        //Applicants applicants = new Applicants();
        private MonthlySeasonPassCollection monthlyPasses;
        public void TerminatePass(string reason, string passType, Applicants applicants)
		{
            DateTime applicantEndMonth = applicants.EndMonth;
            //state = validState;

            if (applicantEndMonth  == null)
            {
                applicantEndMonth = DateTime.Now;
                Console.WriteLine($"Applicant end date is {applicantEndMonth}");
            }
            passType = passType.Trim();
            // Check if the reason or passType is empty or null
            if (string.IsNullOrWhiteSpace(reason) || string.IsNullOrWhiteSpace(passType))
            {
                Console.WriteLine("Termination reason and pass type must be provided. Termination aborted.");
                return;
            }

            // Check if the entered pass type is neither "Daily" nor "Monthly"
            if (passType != "Daily" && passType != "Monthly")
            {
                Console.WriteLine("Please enter either 'Daily' or 'Monthly' only. Termination aborted.");
                return;
            }

            // Check if the parking pass is not active, indicating no active pass to terminate
            if (state != validState)
            {
                if (passType == "Daily")
                {
                    Console.WriteLine("Your Daily Season Pass has expired");
                    Console.WriteLine("Please choose if you would like to renew or terminate your season pass");


                    Console.WriteLine("---------------------Menu---------------------");
                    Console.WriteLine("[1] Renew Daily Season Pass");
                    Console.WriteLine("[2] Terminate Daily Season Pass");
                    Console.WriteLine("[3] Exit");
                    Console.WriteLine("----------------------------------------------");

                    Console.Write("Select option: ");

                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 0)
                    {
                        return;
                    }
                    else if (option == 1) //Renew
                    {
                        /* Method to call renew */

                        Console.WriteLine("Your Daily Season Pass has been renewd");
                        return;
                    }

                    else if (option == 2)
                    {
                        Console.WriteLine("Daily Season Pass has been terminated");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No active season parking pass found. Termination process aborted.");
                    return;
                }
                
                return;
            }


            // Check if the passType argument matches the Type of the ParkingPass
            else if (this.passType == passType)
            {
                state = terminatedState;
                // If the season pass is "Daily"
                if (passType == "Daily")
                {
                    Console.WriteLine("Daily Season Pass is terminated.");
                    return;
                }
                // If the season pass is "Monthly" and there are full months left to refund
                else if (passType == "Monthly" && applicantEndMonth > DateTime.Now)
                {
                    double refundAmount = CalculateRefund();
                    Console.WriteLine($"Monthly season pass terminated. Refund of ${refundAmount} processed.");
                    NumPass += 1; // Assuming NumPass is the number of passes left, and you increment it since one is now available.
                    Console.WriteLine($"Number of Monthly Season Pass left is {NumPass}");
                    Console.WriteLine("There are available Monthly Season Pass now!");
                    this.monthlyPasses.availablePass();

                    return;
                }
                // If the season pass is "Monthly" but there are no full months left to refund
                else if (passType == "Monthly")
                {
                    Console.WriteLine("Monthly season pass terminated without a refund.");
                    NumPass += 1; // Assuming NumPass is the number of passes left, and you increment it since one is now available.
                    Console.WriteLine($"Number of Monthly Season Pass left is {NumPass}");
                    Console.WriteLine("There are available Monthly Season Pass now!");
                    this.monthlyPasses.availablePass();
                    return;
                }
                Console.WriteLine("Season Pass Terminated for reason: " + reason);
                return;
            }
            
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
