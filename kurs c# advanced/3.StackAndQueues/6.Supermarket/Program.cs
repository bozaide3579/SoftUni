namespace _6.Supermarket
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<string> queue = new Queue<string>();


			string input;
			while ((input = Console.ReadLine()) != "End")
			{
				if (input != "Paid")
				{
					queue.Enqueue(input);
				}
				else
				{
					while (queue.Count > 0)
					{
						Console.WriteLine(queue.Dequeue());
					}
				}
			}

			Console.WriteLine($"{queue.Count} people remaining.");
		}
	}
}
