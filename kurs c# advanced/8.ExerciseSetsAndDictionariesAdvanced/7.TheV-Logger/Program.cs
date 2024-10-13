namespace _7.TheV_Logger
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> vloggers = new HashSet<string>();
			Dictionary<string, HashSet<string>> inEdges = new Dictionary<string, HashSet<string>>();
			Dictionary<string, HashSet<string>> outEdges = new Dictionary<string, HashSet<string>>();

			string input;
			while ((input = Console.ReadLine()) != "Statistics")
			{
				string[] commandData = input.Split();

				if (commandData.Length == 4 && commandData[1] == "joined")
				{
					string vloggerName = commandData[0];

					if (vloggers.Add(vloggerName))
					{
						inEdges[vloggerName] = new HashSet<string>();
						outEdges[vloggerName] = new HashSet<string>();
					}
				}
				else if (commandData.Length == 3 && commandData[1] == "followed")
				{
					string sender = commandData[0];
					string reciver = commandData[2];

					if (sender != reciver && vloggers.Contains(sender) && vloggers.Contains(reciver))
					{
						outEdges[sender].Add(reciver);
						inEdges[reciver].Add(sender);
					}
				}
			}

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

			int index = 1;
			foreach (string vlogger in vloggers.OrderByDescending(x => inEdges[x].Count).ThenBy(x => outEdges[x].Count))
			{
                Console.WriteLine($"{index}. {vlogger} : {inEdges[vlogger].Count} followers, {outEdges[vlogger].Count} following");

				if (index == 1)
				{
					foreach (string follower in inEdges[vlogger].OrderBy(x => x))
					{
                        Console.WriteLine($"*  {follower}");
                    }
				}

				index++;
            }
        }
	}
}
