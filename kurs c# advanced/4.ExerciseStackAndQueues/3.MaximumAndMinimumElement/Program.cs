namespace _3.MaximumAndMinimumElement
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Stack<int> stack = new Stack<int>();
			Stack<int> stack2 = new Stack<int>();
			for (int i = 0; i < n; i++)
			{
				int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int code = query[0];

				if (code == 1)
				{
					int number = query[1];
					stack.Push(number);
				}
				else if (code == 2)
				{
					stack.Pop();
				}
				else if (code == 3 && stack.Count > 0)
				{
					int max = int.MinValue;

					while (stack.Count > 0)
					{
						int current = stack.Pop();
						stack2.Push(current);

						if (current > max)
						{
							max = current;
						}
					}

					while (stack2.Count > 0)
					{
						stack.Push(stack2.Pop());
					}

                    Console.WriteLine(max);

                }
				else if (code == 4 && stack.Count > 0)
				{
					int min = int.MaxValue;

					while (stack.Count > 0)
					{
						int current = stack.Pop();
						stack2.Push(current);

						if (current < min)
						{
							min = current;
						}
					}

					while (stack2.Count > 0)
					{
						stack.Push(stack2.Pop());
					}

					Console.WriteLine(min);
				}
			}

            Console.WriteLine(string.Join(", ", stack));
        }
	}
}
