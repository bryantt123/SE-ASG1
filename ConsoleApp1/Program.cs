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
        }
    }



    public class Applicants
    {
        private string Name { get; set; }
        private string ID { get; set; }

        private string Username { get; set; }
        private string Password { get; set; }
        private int MobileNo { get; set; }
        private DateTime startMonth { get; set; }
        private DateTime endMonth { get; set; }
        private string PaymentMode { get; set; }
        private string LicensePlateNo { get; set; }
        private int IUNumber { get; set; }
        private string VehicleType { get; set; }
    }
    public class WaitingList
    {
        private string Name { get; set; }

    }

    public class Vehicle
    {
        private string VehicleType { get; set; }
        private string LicensePlateNo { get; set; }
        private int IUNo { get; set; }

    }

    public class ParkingRecord
    {
        private DateTime Entry { get; set; }
        private DateTime Exit { get; set; }
        private int ParkingId { get; set; }
        private double Amount { get; set; }
        public ParkingPass TransferPass() 
        { 
            // Implementation 
            return new ParkingPass(); 
        }
        // Other properties and methods
    }

    public class GantrySystem
    {
        public void PurgeRecord() 
        { 
            // Implementation
        }
        public void CalculateRevenue() 
        {
            // Implementation 
        }
    }

    public class ParkingPass
    {
        private string ParkingStatus { get; set; }
        private double ChargeRate { get; set; }
        private int NumPass { get; set; }
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
    public class DailySeasonPass : ParkingPass
    {
        private double ChargeRate { get; set; }
        // Other properties and methods
    }

    public class MonthlySeasonPass : ParkingPass
    {
        private int NumPassLeft { get; set; }
        private string Status { get; set; }
        public void RefundUnused() 
        { 
            /* Implementation */ 
        }
        // Other properties and methods
    }
    public class ParkingLot
    {
        private int LotNumber { get; set; }
        private string LotType { get; set; }
        // Other properties and methods
    }

    public class Carpark
    {
        private int CarparkId { get; set; }
        private string Description { get; set; }
        private string Location { get; set; }
        public List<ParkingLot> ParkingLots { get; set; }
        // Other properties and methods
    }

    public class FinancialReport
    {
        private double AllVehiclesRevenue { get; set; }
        private double StaffVehiclesRevenue { get; set; }
        private double StudentVehiclesRevenue { get; set; }
        // Other properties and methods
    }
}
