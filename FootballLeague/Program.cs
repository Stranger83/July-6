using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague
{
	class Team
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public BigInteger Goals { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var key = Regex.Escape(Console.ReadLine());
			var allTeams = new List<Team>();
			while (true)
			{
				var line = Console.ReadLine();
				if (line == "final")
				{
					break;
				}
				var teamAndScoreMatch = Regex.Match(line, string.Format(@"^.*(?:{0}(?<team1>[a-zA-Z]*){0}).* .*(?:{0}(?<team2>[a-zA-Z]*){0}).* (?<team1Goals>\d+):(?<team2Goals>\d+).*$", key));
				var team1Goals = BigInteger.Parse(teamAndScoreMatch.Groups["team1Goals"].Value);
				var team2Goals = BigInteger.Parse(teamAndScoreMatch.Groups["team2Goals"].Value);
				var team1Name = string.Join("", teamAndScoreMatch.Groups["team1"].Value.ToUpper().Reverse().ToArray());
				var team2Name = string.Join("", teamAndScoreMatch.Groups["team2"].Value.ToUpper().Reverse().ToArray());
				var team1Score = 0;
				var team2Score = 0;

				if (team1Goals > team2Goals)
				{
					team1Score = 3;
				}
				else if (team2Goals > team1Goals)
				{
					team2Score = 3;
				}
				else if (team1Goals == team2Goals)
				{
					team1Score = 1;
					team2Score = 1;
				}

				var team1 = new Team { Name = team1Name, Goals = team1Goals, Score = team1Score };
				var team2 = new Team { Name = team2Name, Goals = team2Goals, Score = team2Score };

				if (allTeams.Select(x => x.Name).Contains(team1.Name))
				{
					allTeams.First(x => x.Name == team1.Name).Goals += team1Goals;
					allTeams.First(x => x.Name == team1.Name).Score += team1Score;
				}
				else
				{
					allTeams.Add(team1);
				}
				if (allTeams.Select(x => x.Name).Contains(team2.Name))
				{
					allTeams.First(x => x.Name == team2.Name).Goals += team2Goals;
					allTeams.First(x => x.Name == team2.Name).Score += team2Score;
				}
				else
				{
					allTeams.Add(team2);
				}
			}
			Console.WriteLine("League standings:");
			var sortedTeams = allTeams.OrderByDescending(x => x.Score).ThenBy(x => x.Name).ToList();
			for (int i = 0; i < sortedTeams.Count; i++)
			{
				Console.WriteLine($"{i+1}. {sortedTeams[i].Name} {sortedTeams[i].Score}");
			}
			Console.WriteLine("Top 3 scored goals:");
			var sortedByGoals = allTeams.OrderByDescending(x => x.Goals).ThenBy(x => x.Name).Take(3).ToList();
			for (int i = 0; i < sortedByGoals.Count; i++)
			{
				Console.WriteLine($"- {sortedByGoals[i].Name} -> {sortedByGoals[i].Goals}");
			}
		}
	}
}
