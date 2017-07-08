using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDessert
{
	class Program
	{
		static void Main(string[] args)
		{
			var moneyAvailable = decimal.Parse(Console.ReadLine());
			var guests = int.Parse(Console.ReadLine());
			var bananaPrice = decimal.Parse(Console.ReadLine());
			var eggPrice = decimal.Parse(Console.ReadLine());
			var berriesPrice = decimal.Parse(Console.ReadLine());

			int portions = (int)Math.Ceiling(guests / 6.00);

			var bananasNeeded = portions * 2;
			var eggsNeeded = portions * 4;
			decimal berriesNeeded = (decimal)(portions * 0.2);

			decimal moneyNeeded = bananasNeeded * bananaPrice + eggsNeeded * eggPrice +
				berriesNeeded * berriesPrice;
			if (moneyAvailable >= moneyNeeded)
			{
				Console.WriteLine($"Ivancho has enough money - it would cost {moneyNeeded:f2}lv.");
			}
			else
			{
				Console.WriteLine($"Ivancho will have to withdraw money - he will need {(moneyNeeded - moneyAvailable):f2}lv more.");
			}
		}
	}
}
