
namespace _8.BalancedParenthesis
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();

			if (IsBalanced(text))
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
		}

		public static bool IsBalanced(string text)
		{
			Dictionary<char, char> parenthesis = new Dictionary<char, char>()
			{
				['('] = ')',
				['['] = ']',
				['{'] = '}'
			};

			Stack<char> stack = new Stack<char>();
			foreach (char c in text)
			{
				if (parenthesis.ContainsKey(c))
				{
					stack.Push(parenthesis[c]);
				}
				else
				{
					if (stack.Count == 0 || stack.Peek() != c)
					{
						return false;
					}

					stack.Pop();

				}
			}

			return stack.Count == 0;
		}
	}
}
