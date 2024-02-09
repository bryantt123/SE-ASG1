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
            List<Applicants> applicantList = new List<Applicants>();

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

                    applicant.ApplyPass();
                    Console.WriteLine("Applied! ");
                }
                else if (option == 2) //renew
                {
                    Console.WriteLine("test");
                    // Use case step 2: System displays user’s season pass.
                    foreach (ParkingPass pp in applicant.PpList)
                    {
                        Console.WriteLine("[" + pp.PassId + "] :" + pp.PassType);
                    }

                    // Use case Step 3: User selects a season pass.
                    Console.Write("Enter a season pass ID: ");
                    int passOption = Convert.ToInt32(Console.ReadLine()) - 1;

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
                        int confirmation = Convert.ToInt32(Console.ReadLine());
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
                        else if (confirmation == 0)
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
                else if (option == 3)
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
                            Console.WriteLine("Pass ID: [" + veh.ParkingPass.PassId + "] Plate No: [" + veh.LicensePlateNo + "] Pass Type: " + veh.ParkingPass.PassType, "Vehicle Type: ", veh.VehicleType);
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
                        applicant.Vehicles.Add(new Vehicle { VehicleType = newVehDetails[0], LicensePlateNo = newVehDetails[1], IuNo = Convert.ToInt32(newVehDetails[2]) });

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
                                    if (veh2.IuNo == iuNoNew)
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
                else if (option == 4)
                {
                    foreach (ParkingPass pp in applicant.PpList)
                    {
                        Console.WriteLine("[" + pp.PassId + "] :" + pp.PassType);
                    }

                    Console.Write("Enter a season pass ID to terminate: ");
                    int terminate = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.WriteLine("What is the reason for terminating the season pass?");
                    string reason = Console.ReadLine();

                    if (applicant.PpList[terminate].PassType == "Monthly")
                    {
                        parkingPass.TerminatePass(reason, applicant.PpList[terminate].PassType, applicant);
                    }
                    else if (applicant.PpList[terminate].PassType == "Daily")
                    {
                        parkingPass.TerminatePass(reason, applicant.PpList[terminate].PassType, applicant);
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'Daily' or 'Monthly' only.");
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
        }
    }
}

