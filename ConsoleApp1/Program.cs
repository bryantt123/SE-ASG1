using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingPass parkingPass = new ParkingPass();
            parkingPass.passType = "Monthly";
            while (true)
            {
                displayMenu();
                Console.Write("Enter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                else if (option == 1)
                {
                    //apply season pass
                    Console.WriteLine("Applied! ");
                }
                else if (option == 2)
                {
                    //renew
                    Console.WriteLine("Renewed! ");
                }
                else if (option == 3)
                {
                    // transfer
                    Console.WriteLine("Transfered! ");
                }
                else if (option == 4)
                {
                    
                    //terminate
                    //For commit comments
                    Console.WriteLine("What is the reason for terminating the season pass?");

                    string reason = Console.ReadLine();
                    Console.WriteLine("What type of season pass would you like to terminate? Daily / Monthly? (Case Sensitive, Please Copy Paste) :");
                    parkingPass.passType = Console.ReadLine();
                    if (parkingPass.passType == "Daily" || parkingPass.passType == "Monthly")
                    {
                        parkingPass.TerminatePass(reason, parkingPass.passType);
                        Console.WriteLine("parkingPass.TerminatePass(reason) called");
                        Console.WriteLine($"{parkingPass.passType} season pass Terminated!");
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'Daily' or 'Monthly' only.");
                    }

                    //if (Tpasstype == "Monthly")
                    //{
                    //    //TerminatePass(applicants, reason);
                    //    Console.WriteLine($"{reason}");

                    //    parkingPass.TerminatePass(reason, Tpasstype);
                    //    Console.WriteLine("parkingPass.TerminatePass(reason) called");

                    //    Console.WriteLine("Monthly season pass Terminated! ");
                    //}

                    //else if (Tpasstype == "Daily")
                    //{
                    //    Console.WriteLine($"{reason}");

                    //    parkingPass.TerminatePass(reason, Tpasstype);
                    //    Console.WriteLine("parkingPass.TerminatePass(reason) called");

                    //    Console.WriteLine("Daily season pass Terminated! ");
                    //}

                    //else
                    //{
                    //    Console.WriteLine("Please enter either Daily or Monthly only");
                    //}


                }
                else if (option == 5)
                {
                    //process season pass aplication
                    Console.WriteLine("Processed! ");
                }
                else if (option == 6)
                {
                    // generate financial report
                    Console.WriteLine("Generated! ");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }





            void displayMenu()
            {
                Console.WriteLine("---------------------Menu---------------------");
                Console.WriteLine("[1] Apply season pass");
                Console.WriteLine("[2] Renew season pass");
                Console.WriteLine("[3] Transfer season pass");
                Console.WriteLine("[4] Terminate season pass");
                Console.WriteLine("[5] Process season pass aplication");
                Console.WriteLine("[6] Generate financial report");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("----------------------------------------------");
            }

            

        }
    }
}
