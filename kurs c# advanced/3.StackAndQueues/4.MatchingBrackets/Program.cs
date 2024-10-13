using System.Data;

namespace _4.MatchingBrackets
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == '(')
				{
					stack.Push(i);
				}
				else if (input[i] == ')')
				{
					int lastOpenBrackets = stack.Pop();
					string result = input.Substring(lastOpenBrackets, i - lastOpenBrackets + 1);
					Console.WriteLine(result);
				}
			}
		}
	}
}
