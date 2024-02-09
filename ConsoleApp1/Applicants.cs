﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Applicants : Observer
	{
		private Subject ppData;
		private string Name { get; set; }
		private string ID { get; set; }
		private string Username { get; set; }
		private string Password { get; set; }
		private int MobileNo { get; set; }
		private string PaymentMode { get; set; }
		private List<Vehicle> vehicles { get; set; }

		public Applicants(Subject pp)
		{
			this.ppData = pp;
			ppData.registerObserver(this);
		}
		public void Update()
		{
			Console.WriteLine("There are monthly passes available!");
		}
	}

}
