using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                    Console.WriteLine("Terminated! ");
                }
                else if (option == 5)
                {
                    //process season pass aplication
                    Console.WriteLine("Processed! ");
                }
                else if (option == 6)
                {
                    // generate financial report
                    Console.WriteLine("Generate! ");
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
