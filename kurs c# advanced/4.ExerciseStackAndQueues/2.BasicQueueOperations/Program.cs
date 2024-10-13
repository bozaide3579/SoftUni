namespace _2.BasicQueueOperations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = input[0];
			int s = input[1];
			int x = input[2];

			int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

			Queue<int> queue = new Queue<int>();	

			for (int i = 0; i < n; i++)
			{
				queue.Enqueue(data[i]);
			}
			
			for (int i = 0; i < s; i++)
			{
				queue.Dequeue();
			}

			if (queue.Count == 0)
			{
				Console.WriteLine(0);
			}
			else
			{
				bool isFound = false;
				int min = int.MaxValue;

				while (queue.Count > 0)
				{
					int current = queue.Dequeue();

					if (current == x)
					{
						isFound = true;
					}

					if (current < min)
					{
						min = current;
					}
				}

				if (isFound)
				{
					Console.WriteLine("true");
				}
				else
				{
                    Console.WriteLine(min);
                }
			}
		}
	}
}
