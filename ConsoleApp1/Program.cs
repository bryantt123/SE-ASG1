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
            //Applicants applicants = new Applicants();
            //Applicants applicants = new Applicants(PPData);
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
               
                else if (option == 1) // apply
                {
                    int passType;
                    Console.WriteLine("[1] Daily\n[2] Monthly");

                    Console.Write("Which pass are you applying for? ");
                    passType = Convert.ToInt32(Console.ReadLine());

                    //user selects to apply for daily
                    if (passType == 1)
                    {

                        Console.WriteLine("Please input the following information:\n - Name\n " +
                   "- Month Number for Application \n - Mobile Number\n - Payment mode (cash or card)\n - Vehicle type (car or bike)\n - License plate number\n -" +
                   " IU number\n  Each field should be separated by commas");

                        // User provides the system with all the information required
                        string collatedInfo = Console.ReadLine();
                        string[] applicationInfo = collatedInfo.Split(',');

                        // Executing payment use case
                        Console.WriteLine("Redirecting you to payment...");
                        Console.WriteLine("Payment Successful!");

                        // Convert the month number to a DateTime object
                        int monthNumber = Convert.ToInt32(applicationInfo[1]);
                        DateTime startMonth = new DateTime(DateTime.Now.Year, monthNumber, 1);

                        // Populate vehicle in applicants
                        applicant.Vehicles.Add(new Vehicle
                        {
                            VehicleType = applicationInfo[4],
                            LicensePlateNo = applicationInfo[5],
                            IuNo = Convert.ToInt32(applicationInfo[6])
                        });

                        // Populate the rest of the details in applicants
                        applicantList.Add(new Applicants
                        {
                            Name = applicationInfo[0],
                            StartMonth = startMonth,
                            MobileNo = applicationInfo[2],
                            PaymentMode = applicationInfo[3]
                        });

                        // Create a DailySeasonPass object
                        //setting state to pending 
                        foreach (Applicants a in applicantList)
                        {
                            if (a.Name == applicationInfo[0])
                            {
                                //a.PpList.Add(new ParkingPass { PassId = 5, PassType = "Monthly", EndMonth = (startMonth.AddMonths(1)) });
                                //a.PpList[0].setPending();
                                break;
                            }
                        }
                        Console.WriteLine("Application Successful!");

                    }
                    //user selects to apply for monthly
                    else if (passType == 2)
                    {
                        MonthlySeasonPassCollection waitingList = MonthlySeasonPassCollection.getInstance();

                        if (waitingList.NumPassLeft == 0)
                        {
                            Console.WriteLine("No Monthly passes left. Sign up for waiting list? [Y/N]");
                            string signUp = Console.ReadLine().ToLower();

                            if (signUp == "Y")
                            {

                                waitingList.registerObserver(applicant);
                                Console.WriteLine("You are now in the waiting list for Monthly passes.");

                            }
                            else if (signUp == "N")
                            {
                                Console.WriteLine("You have decided opt out.\nUse case ends.");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Please input the following information:\n - Name\n " +
                      "- Month Number for Application \n - Mobile Number\n - Payment mode (cash or card)\n - Vehicle type (car or bike)\n - License plate number\n -" +
                      " IU number\n  Each field should be separated by commas");

                            //user provides the system with all the information required
                            string collatedInfo = Console.ReadLine();
                            string[] applicationInfo = collatedInfo.Split(',');

                            //executing payment use case
                            Console.WriteLine("Redirecting you to payment...");
                            Console.WriteLine("Payment Successful!");

                            //convert the month number to a DateTime object
                            int monthNumber = Convert.ToInt32(applicationInfo[1]);
                            DateTime startMonth = new DateTime(DateTime.Now.Year, monthNumber, 1);

                            //populate vehicle in applicants
                            applicant.Vehicles.Add(new Vehicle
                            {
                                VehicleType = applicationInfo[4],
                                LicensePlateNo = applicationInfo[5],
                                IuNo = Convert.ToInt32(applicationInfo[6])
                            });

                            //populate the rest of the details in applicants
                            applicantList.Add(new Applicants
                            {
                                Name = applicationInfo[0],
                                StartMonth = startMonth,
                                MobileNo = applicationInfo[2],
                                PaymentMode = applicationInfo[3]
                            });

                            
                            //setting state to pending 
                            foreach (Applicants a in applicantList)
                            {
                                if (a.Name == applicationInfo[0])
                                {
                                    //a.PpList.Add(new ParkingPass { PassId = 5, PassType = "Monthly", EndMonth = (startMonth.AddMonths(1)) } );
                                    //a.PpList[0].setPending();
                                    break;
                                }
                            }                           
                            Console.WriteLine("Application Successful!");                            
                        }
                    }
                }
                else if (option == 2) //renew
                {
                    Console.WriteLine("test");
                    // Use case step 2: System displays user’s season pass.
                    foreach (ParkingPass pp in applicant.PpList)
                    {
                        Console.WriteLine("[" + pp.PassId +"] :" + pp.PassType);
                    }

                    // Use case Step 3: User selects a season pass.
                    Console.Write("Enter a season pass ID: ");
                    int passOption = Convert.ToInt32(Console.ReadLine())-1;

                    // Use case Step 4: System verifies season pass type 
                    ParkingPass p = applicant.PpList[passOption];
                    string passType = p.PassType;
                    DateTime month = p.EndMonth;
                    // daily/vaild monthly: continue
                    if (passType == "Daily" || (passType == "Monthly" && month <= DateTime.Today))
                    {
                        //Use case step 5: System displays new end month.
                        DateTime newMonth = month.AddMonths(1);
                        Console.WriteLine("New end month: " + newMonth);

                        // Use case step 6: System prompts for confirmation.
                        Console.Write("Confirm renewal: [1] Confirm [0] Cancel");
                        int confirmation = Convert.ToInt32(Console.ReadLine()) ;
                        // Use case step 7: User confirms renewal.
                        if (confirmation == 1)
                        {
                            // EXECUTE RENEW()
                            // Use case step 8: System executes Payment use case.
                            Console.WriteLine("Executing Payment");

                            // Use case step 9: System return payment successful.
                            Console.WriteLine("Payment successfull!");

                            // Use case step 10: System records new end month
                            p.EndMonth = newMonth;

                            // Use case step 11: System displays successful renewal.

                            Console.WriteLine("Renewal successful!");
                            // Use case step 12: Use case ends.
                        }
                        else if(confirmation == 0)
                        {
                            //break
                        }
                    }
                    // expired/terminated daily pass
                    else
                    {
                        Console.WriteLine("Unable to renew pass.");
                    }
                }
                else if (option == 3) //transfer
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

                    // display user's season passes
                    int passIdOg;
                    int iuNoNew;
                    foreach (Vehicle veh in applicant.Vehicles)
                    {
                        if (veh.ParkingPass != null)
                        {
                            Console.WriteLine("Pass ID: [" + veh.ParkingPass.PassId + "] Plate No: [" + veh.LicensePlateNo + "] Pass Type: "+ veh.ParkingPass.PassType, "Vehicle Type: ",veh.VehicleType);
                        }
                    }

                    // user chooses a season pass to transfer
                    Console.Write("Enter a season pass ID to transfer: ");
                    passIdOg = Convert.ToInt32(Console.ReadLine());
                    int opt = passIdOg - 1;
                    // display vehicles registered to user
                    foreach (Vehicle veh in applicant.Vehicles)
                    {
                        if (veh.ParkingPass == null)
                        {
                            Console.WriteLine("Plate No: [" + veh.LicensePlateNo + "] IU No: [" + veh.IuNo + "] Type: " + veh.VehicleType);
                        }
                    }

                    // choose vehicle
                    Console.Write("Enter the vehicle's IU No. to transfer to, or enter 0 to add a new vehicle: ");
                    int iu = Convert.ToInt32(Console.ReadLine());
                    iuNoNew = iu;
                    if (iu != 0)
                    {
                        iu -= 1;
                    }
                    else
                    {
                        // add vehicle
                        Console.Write("Enter new vehicle details to add (VehicleType,LicensePlateNo,IuNo): ");
                        string newVeh = Console.ReadLine();
                        string[] newVehDetails = newVeh.Split(',');
                        applicant.Vehicles.Add(new Vehicle { VehicleType = newVehDetails[0],LicensePlateNo = newVehDetails[1], IuNo=Convert.ToInt32(newVehDetails[2]) });

                        //display new set of vehicles
                        foreach (Vehicle veh in applicant.Vehicles)
                        {
                            if (veh.ParkingPass == null)
                            {
                                Console.WriteLine("Plate No: [" + veh.LicensePlateNo + "] IU No: [" + veh.IuNo + "] Type: " + veh.VehicleType);
                            }
                        }

                        //choose vehicle
                        Console.Write("Enter the vehicle's IU No. to transfer to: ");
                        iu = Convert.ToInt32(Console.ReadLine()) - 1;
                        iuNoNew = iu + 1;
                    }
                    Console.Write("Type confirm to transfer pass ID [{0}] to Vehicle with Iu No [{1}]: ", passIdOg, iuNoNew);
                    string confirmation = Console.ReadLine();
                    if (confirmation == "confirm")
                    {
                        foreach (Vehicle veh in applicant.Vehicles)
                        {
                            if (veh.ParkingPass != null && veh.ParkingPass.PassId == passIdOg)
                            {
                                Vehicle ogVeh = veh;
                                foreach (Vehicle veh2 in applicant.Vehicles)
                                {
                                    if(veh2.IuNo == iuNoNew)
                                    {
                                        veh2.ParkingPass = veh.ParkingPass;
                                        veh.ParkingPass = null;
                                        Console.WriteLine("Transfer Successful.");
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        foreach (Vehicle veh in applicant.Vehicles)
                        {
                            if (veh.ParkingPass != null)
                            {
                                Console.WriteLine("Pass ID: [" + veh.ParkingPass.PassId + "] Plate No: [" + veh.LicensePlateNo + "] Pass Type: " + veh.ParkingPass.PassType);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Confirmation cancelled, transfer cancelled.");
                    }
                }
                else if (option == 4) //terminate
                {
                    
                    //terminate
                    //For commit comments
                    Console.WriteLine("What is the reason for terminating the season pass?");

                    string reason = Console.ReadLine();
                    Console.WriteLine("What type of season pass would you like to terminate? Daily / Monthly? (Case Sensitive, Please Copy Paste) :");
                    parkingPass.PassType = Console.ReadLine();
                    if (parkingPass.PassType == "Daily" || parkingPass.PassType == "Monthly")
                    {
                        //parkingPass.TerminatePass(reason, parkingPass.PassType, applicants);
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

        }

    }
}

