﻿using Microsoft.Win32;
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
            List<Applicants> applicantList= new List<Applicants>();

            MonthlySeasonPassCollection subject = new MonthlySeasonPassCollection();
            Applicants applicant = new Applicants(subject);

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
                else if (option == 2) //renew
                {
                    Console.WriteLine("test");
                    // Use case step 2: System displays user’s season pass.
                    foreach (ParkingPass pp in applicant.PpList)
                    {
                        Console.WriteLine("[" + pp.PassId +"]: " + pp.PassType + "Season Pass");
                    }

                    // Use case Step 3: User selects a season pass.
                    Console.Write("Enter a season pass ID: ");
                    int passOption = Convert.ToInt32(Console.ReadLine())-1;
                    ParkingPass p = applicant.PpList[passOption];
                    // call renew
                    p.renewPass();

                    //// Use case Step 4: System verifies season pass type 
                    //string passType = p.PassType;
                    //DateTime month = p.EndMonth;
                    //// daily/vaild monthly: continue
                    //if (passType == "Daily" || (passType == "Monthly" && month <= DateTime.Today))
                    //{
                    //    //Use case step 5: System displays new end month.
                    //    DateTime newMonth = month.AddMonths(1);
                    //    Console.WriteLine("New end month: " + newMonth);

                    //    // Use case step 6: System prompts for confirmation.
                    //    Console.Write("Confirm renewal: [1] Confirm [0] Cancel: ");
                    //    int confirmation = Convert.ToInt32(Console.ReadLine()) ;
                    //    // Use case step 7: User confirms renewal.
                    //    if (confirmation == 1)
                    //    {
                    //        // EXECUTE RENEW()
                    //        // Use case step 8: System executes Payment use case.
                    //        Console.WriteLine("Executing Payment");

                    //        // Use case step 9: System return payment successful.
                    //        Console.WriteLine("Payment successfull!");

                    //        // Use case step 10: System records new end month
                    //        p.EndMonth = newMonth;

                    //        // Use case step 11: System displays successful renewal.

                    //        Console.WriteLine("Renewal successful!");
                    //        // Use case step 12: Use case ends.
                    //    }
                    //    else if(confirmation == 0)
                    //    {
                    //        //break
                    //    }


                  //  }



                    
                }
                else if (option == 3)
                {

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

                    if (Tpasstype == "Monthly")
                    {
                        //TerminatePass(applicants, reason);
                        Console.WriteLine($"{reason}");

                        parkingPass.TerminatePass(reason, Tpasstype);
                        Console.WriteLine("parkingPass.TerminatePass(reason) called");

                        Console.WriteLine("Monthly season pass Terminated! ");
                    }

                    else if (Tpasstype == "Daily")
                    {
                        Console.WriteLine($"{reason}");

                        parkingPass.TerminatePass(reason, Tpasstype);
                        Console.WriteLine("parkingPass.TerminatePass(reason) called");

                        Console.WriteLine("Daily season pass Terminated! ");
                    }

                    else
                    {
                        Console.WriteLine("Please enter either Daily or Monthly only");
                    }


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
                    DailySeasonPass dailySeasonPass = new DailySeasonPass("Daily", 1, startMonth);
                    dailySeasonPass.setPending();


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

            void transferPass()
            {
                /* 
                    display season passes
                    choose season pass
                    display vehicles
                    choose vehicle/add vehicle
                    confirm trasnfer
                    change season pass details
                    display success
                    */

                Console.WriteLine("Enter your username registered to your season pass: ");
                string un = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string pw = Console.ReadLine();
                foreach (Applicants applicant in applicantList)
                {
                    if (applicant.verifyUser(un, pw) == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error authenticating user!");
                        return;
                    }
                }


            }

        }
    }
}
