using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicMessages
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				var encryptedMsg = Console.ReadLine();
				if (encryptedMsg == "Over!")
				{
					break;
				}
				var msgLength = int.Parse(Console.ReadLine());
				var patternForMsg = @"^\d+(?<msg>[a-zA-Z]+)[^a-zA-Z]*$";
				var match = Regex.Match(encryptedMsg, patternForMsg);
				if (!match.Success)
				{
					continue;
				}
				if (match.Groups["msg"].Length != msgLength)
				{
					continue;
				}
				var msg = match.Groups["msg"].Value;
				var indexes = new List<int>();
				for (int i = 0; i < encryptedMsg.Length; i++)
				{
					if (Char.IsDigit(encryptedMsg[i]))
					{
						indexes.Add(int.Parse(encryptedMsg[i].ToString()));
					}
				}
				var sb = new StringBuilder();
				for (int i = 0; i < indexes.Count; i++)
				{
					if (indexes[i] >= 0 && indexes[i] < msg.Length)
					{
						sb.Append(msg[indexes[i]]);
					}
					else
					{
						sb.Append(" ");
					}
				}
				Console.WriteLine($"{msg} == {string.Join("", sb)}");
			}
		}
	}
}
