using System.Threading.Channels;

namespace _2.StackSum
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

			Stack<int> stack = new Stack<int>(numbers);

			string input;
			while ((input = Console.ReadLine()).ToLower() != "end")
			{
				string[] splittedInput = input.Split();
				string command = splittedInput[0].ToLower();

				if (command == "add")
				{
					int n1 = int.Parse(splittedInput[1]);
					int n2 = int.Parse(splittedInput[2]);
					stack.Push(n1);
					stack.Push(n2);
				}

				if (command == "remove")
				{
					int n1 = int.Parse(splittedInput[1]);
					if (n1 <= stack.Count)
					{
						for (int i = 0; i < n1; i++)
						{
							stack.Pop();
						}
					}
				}
			}

			Console.WriteLine($"Sum: {stack.Sum()}");
		}
	}
}
