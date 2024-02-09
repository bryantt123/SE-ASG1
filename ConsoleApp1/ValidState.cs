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
        public void renewPass(ParkingPass p)
        {
            //implementation
            // Use case Step 4: System verifies season pass type 
            string passType = p.PassType;
            DateTime month = p.EndMonth;
            DateTime newMonth = month.AddMonths(1);
            Console.WriteLine("New end month: " + newMonth);

            // Use case step 6: System prompts for confirmation.
            Console.Write("Confirm renewal: [1] Confirm [0] Cancel: ");
            int confirmation = Convert.ToInt32(Console.ReadLine());

            // Use case step 7: User confirms renewal.
                if (confirmation == 1)
                {
                    // Use case step 8: System executes Payment use case.
                    Console.WriteLine("Executing Payment...");

                    // Use case step 9: System return payment successful.
                    Console.WriteLine("Payment successfull!");

                    // Use case step 10: System records new end month
                    p.EndMonth = newMonth;

                    // Use case step 11: System displays successful renewal.

                    Console.WriteLine("Renewal successful!");
                    // Use case step 12: Use case ends.
                    Console.WriteLine("Renewed! ");
            }
                else if (confirmation == 0)
                {
                    Console.WriteLine("Cancelled");
                }

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
