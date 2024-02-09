using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class MonthlySeasonPassCollection : Subject
	{
		private List<Observer> observers;
		private int NumPassLeft { get; set; }
		private List<Applicants> waitingList { get; set; }

		public MonthlySeasonPassCollection()
		{
			observers = new List<Observer>(); 
		}
        public void registerObserver(Observer o)
		{
			observers.Add(o);
		}
		public void removeObserver(Observer o)
		{
			observers.Remove(o);
		}
		public void notifyObservers()
		{
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
		public void availablePass()
		{
            notifyObservers();
		}
		public void RefundUnused()
		{
            Console.WriteLine("Refund processed for unused full months.");
            /* Implementation */
        }
		// Other properties and methods
	}
}
