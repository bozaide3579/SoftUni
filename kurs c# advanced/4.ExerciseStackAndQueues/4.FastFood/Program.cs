namespace _4.FastFood
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int food = int.Parse(Console.ReadLine());
			Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

			int biggestOrder = 0;
			for (int i = 0; i < orders.Count; i++)
			{
				int current = orders.Dequeue();

				if (current > biggestOrder)
				{
					biggestOrder = current;
				}

				orders.Enqueue(current);
			}

			while (orders.Count > 0 && food >= orders.Peek())
			{
					food -= orders.Dequeue();
			}

            Console.WriteLine(biggestOrder);

            if (orders.Count == 0)
			{
                Console.WriteLine("Orders complete");
            }
			else
			{
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
		}
	}
}
