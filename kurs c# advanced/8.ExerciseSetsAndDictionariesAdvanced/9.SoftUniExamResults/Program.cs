namespace _9.SoftUniExamResults
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> bannedUsers = new HashSet<string>();
			Dictionary<string, int> maxPointsByUser = new Dictionary<string, int>();
			Dictionary<string, int> submissionsCountByLanguage = new Dictionary<string, int>();


			string input = Console.ReadLine();
			while (input != "exam finished")
			{
				string[] commandData = input.Split('-');

				if (commandData.Length == 3)
				{
					string username = commandData[0];
					string programingLanguage = commandData[1];
					int points = int.Parse(commandData[2]);

					if (!maxPointsByUser.ContainsKey(username) || maxPointsByUser[username] < points)
					{
						maxPointsByUser[username] = points;
					}

					if (!submissionsCountByLanguage.ContainsKey(programingLanguage))
					{
						submissionsCountByLanguage[programingLanguage] = 0;
					}

					submissionsCountByLanguage[programingLanguage]++;
				}
				else if (commandData.Length == 2 && commandData[1] == "banned")
				{
					string username = commandData[0];
					bannedUsers.Add(username);
				}


				input = Console.ReadLine();
			}

			Console.WriteLine("Results:");

			foreach (var (username, maxPoints) in maxPointsByUser
				.Where(x => !bannedUsers.Contains(x.Key))
				.OrderByDescending(x => x.Value)
				.ThenBy(x => x.Key))
			{
				Console.WriteLine($"{username} | {maxPoints}");
			}

			Console.WriteLine("Submissions:");

			foreach (var (programmingLanguage, submissionsCount) in submissionsCountByLanguage
				.OrderByDescending(x => x.Value)
				.ThenBy(x => x.Key))
			{
				Console.WriteLine($"{programmingLanguage} - {submissionsCount}");
			}

		}
	}
}
