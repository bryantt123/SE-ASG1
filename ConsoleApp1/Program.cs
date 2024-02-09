using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Management.Instrumentation;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingPass parkingPass = new ParkingPass();
            Subject PPData = new MonthlySeasonPassCollection();
            Applicants applicants = new Applicants(PPData);
            parkingPass.PassType = "";
            MonthlySeasonPassCollection monthlyPassCollection = new MonthlySeasonPassCollection();

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

                    // ApplyPass(observers);
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
                    parkingPass.PassType = Console.ReadLine();
                    if (parkingPass.PassType == "Daily" || parkingPass.PassType == "Monthly")
                    {
                        parkingPass.TerminatePass(reason, parkingPass.PassType, applicants);
                        //Console.WriteLine("parkingPass.TerminatePass(reason) called");
                        //Console.WriteLine($"{parkingPass.PassType} season pass Terminated!");
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

            void ApplyPass(List<Observer> observers)
            {

                Console.WriteLine("Are you applying for Monthly or Daily season parking pass? ");
                string passType = Console.ReadLine();

                if (passType == "Daily")
                {
                    
                    Console.WriteLine("Please input the following information:\n - Name\n - Month for application\n - Mobile Number\n - Payment mode\n - License plate number\n - IU number\n - Vehicle type\n(Separated by commas)");

                    //User provides the system with all the information required
                    string collatedInfo = Console.ReadLine();
                    string[] applicationInfo = collatedInfo.Split(',');

                    //Executing payment use case
                    Console.WriteLine("Redirecting you to payment...");
                    Console.WriteLine("Payment Successful!");

                    DateTime startMonth = Convert.ToDateTime(applicationInfo[1]);
                    DailySeasonPass dailySeasonPass = new DailySeasonPass("daily", 1, startMonth);

                    
                    

                }

                else if (passType == "Monthly")
                {
                    if (NumPassLeft > 0)
                    {
                        
                    }
                    else if (NumPassLeft == 0)
                    {
                        Console.WriteLine("There are no Monthly passes left! Go to waiting list? [Y/N]");
                        string decision = Console.ReadLine();
                        if (decision == "Y")
                        {

                        }
                        if (decision == "N")
                        {
                            
                        }
                    }
                }


            }

        }
    }
}
