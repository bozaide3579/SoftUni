namespace _3.SimpleCalculator
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			string[] splitted = input.Split(" ");
			Stack<string> stack = new Stack<string>(splitted.Reverse());
			int result = int.Parse(stack.Pop());

			while (stack.Count > 0)
			{
				char znak = char.Parse(stack.Pop());
				int num = int.Parse(stack.Pop());

				if (znak == '-')
				{
					result -= num;
				}
				else if (znak == '+')
				{
					result += num;
				}
			}

			Console.WriteLine(result);
		}
	}
}
