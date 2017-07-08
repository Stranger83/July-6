using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
	class Program
	{
		static void Main(string[] args)
		{
			var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			while (true)
			{
				var line = Console.ReadLine().ToLower();
				if (line == "end")
				{
					break;
				}
				var tokens = line.Split(' ');
				var command = tokens[0];
				ProcessCommand(command, tokens, arr);
			}
			Console.WriteLine("[{0}]", string.Join(", ", arr));
		}

		private static void ProcessCommand(string command, string[] tokens, int[] arr)
		{
			if (command == "exchange")
			{
				var index = int.Parse(tokens[1]);
				if (index < 0 || index > arr.Length - 1)
				{
					Console.WriteLine("Invalid index");
					return;
				}
				Exchange(command, index, arr);
			}
			else if (command == "max" || command == "min")
			{
				CalcMaxOrMinEvenOrOdd(command, tokens, arr);
			}
			else if (command == "first" || command == "last")
			{
				var count = int.Parse(tokens[1]);
				if (count > arr.Length || count < 0)
				{
					Console.WriteLine("Invalid count");
					return;
				}
				CalcFirstOrLastEvenOrOdd(command, tokens, arr);
			}
		}

		private static void CalcFirstOrLastEvenOrOdd(string command, string[] tokens, int[] arr)
		{
			var count = int.Parse(tokens[1]);
			var everOrOdd = tokens[2];
			if (command == "first" && everOrOdd == "even")
			{
				var resultFirstEven = new List<int>();
				int i = 0;
				while (resultFirstEven.Count < count && i < arr.Length)
				{
					if (arr[i] % 2 == 0)
					{
						resultFirstEven.Add(arr[i]);
					}
					i++;
				}
				Console.WriteLine("[{0}]", string.Join(", ", resultFirstEven));
			} else if (command == "first" && everOrOdd == "odd")
			{
				var resultFirstOdd = new List<int>();
				int i = 0;
				while (resultFirstOdd.Count < count && i < arr.Length)
				{
					if (arr[i] % 2 != 0)
					{
						resultFirstOdd.Add(arr[i]);
					}
					i++;
				}
				Console.WriteLine("[{0}]", string.Join(", ", resultFirstOdd));
			}
			else if (command == "last" && everOrOdd == "odd")
			{
				var resultLastOdd = new List<int>();
				int i = arr.Length - 1;
				while (resultLastOdd.Count < count && i >= 0)
				{
					if (arr[i] % 2 != 0)
					{
						resultLastOdd.Add(arr[i]);
					}
					i--;
				}
				resultLastOdd.Reverse();
				Console.WriteLine("[{0}]", string.Join(", ", resultLastOdd));
			}
			else if (command == "last" && everOrOdd == "even")
			{
				var resultLastEven = new List<int>();
				int i = arr.Length - 1;
				while (resultLastEven.Count < count && i >= 0)
				{
					if (arr[i] % 2 == 0)
					{
						resultLastEven.Add(arr[i]);
					}
					i--;
				}
				resultLastEven.Reverse();
				Console.WriteLine("[{0}]", string.Join(", ", resultLastEven));
			}
		}

		private static void CalcMaxOrMinEvenOrOdd(string command, string[] tokens, int[] arr)
		{
			var minEvenIndex = -1;
			var minEven = int.MaxValue;
			var minOddIndex = -1;
			var minOdd = int.MaxValue;
			var maxEvenIndex = -1;
			var maxEven = int.MinValue;
			var maxOddIndex = -1;
			var maxOdd = int.MinValue;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] % 2 == 0 && arr[i] >= maxEven)
				{
					maxEven = arr[i];
					maxEvenIndex = i;
				}
				else if (arr[i] % 2 != 0 && arr[i] >= maxOdd)
				{
					maxOdd = arr[i];
					maxOddIndex = i;
				}
				if (arr[i] % 2 == 0 && arr[i] <= minEven)
				{
					minEven = arr[i];
					minEvenIndex = i;
				}
				else if (arr[i] % 2 != 0 && arr[i] <= minOdd)
				{
					minOdd = arr[i];
					minOddIndex = i;
				}
			}
			var evenOrOdd = tokens[1];
			if (command == "max" && evenOrOdd == "even")
			{
				if (maxEvenIndex < 0)
				{
					Console.WriteLine("No matches");
					return;
				}
				Console.WriteLine(maxEvenIndex);
			} else if (command == "max" && evenOrOdd == "odd")
			{
				if (maxOddIndex < 0)
				{
					Console.WriteLine("No matches");
					return;
				}
				Console.WriteLine(maxOddIndex);
			}
			else if (command == "min" && evenOrOdd == "even")
			{
				if (minEvenIndex < 0)
				{
					Console.WriteLine("No matches");
					return;
				}
				Console.WriteLine(minEvenIndex);
			}else if(command == "min" && evenOrOdd == "odd")
			{
				if (minOddIndex < 0)
				{
					Console.WriteLine("No matches");
					return;
				}
				Console.WriteLine(minOddIndex);
			}
		}
	
		private static void Exchange(string command, int index, int[] arr)
		{
			var firstPart = arr.Take(index + 1).ToArray();
			var secondPart = arr.Skip(index + 1).ToArray();
			List<int> result = new List<int>();
			result.AddRange(secondPart);
			result.AddRange(firstPart);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = result[i];
			}
		}
	}
}
