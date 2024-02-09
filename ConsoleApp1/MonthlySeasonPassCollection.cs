﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class MonthlySeasonPassCollection : Subject
	{
		private List<Observer> observers;
		private int numPassLeft { get; set; } = 5;
		public int NumPassLeft { get; set; } = 5;

		private List<Applicants> waitingList { get; set; }

		public MonthlySeasonPassCollection()
		{
			observers = new List<Observer>(); 
		}

		// add to waiting list
        public void registerObserver(Observer o)
		{
			observers.Add(o);
		}

		// remove from waiting list
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
			Console.WriteLine("Notified");
		}

		public void RefundUnused()
		{
            Console.WriteLine("Refund processed for unused full months.");
            /* Implementation */
        }
		
	
	}
}
