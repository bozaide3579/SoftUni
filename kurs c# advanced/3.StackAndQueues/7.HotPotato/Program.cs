namespace _7.HotPotato
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split();

			int count = int.Parse(Console.ReadLine());

			Queue<string> kids = new Queue<string>(input);

			while (kids.Count > 1)
			{
				for (int i = 0; i < count - 1; i++)
				{
					kids.Enqueue(kids.Dequeue());
				}

				Console.WriteLine($"Removed {kids.Dequeue()}");
			}

			Console.WriteLine($"Last is {kids.Dequeue()}");
		}
	}
}