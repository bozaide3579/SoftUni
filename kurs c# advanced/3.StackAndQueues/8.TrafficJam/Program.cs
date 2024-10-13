
namespace _8.TrafficJam
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int allCount = 0;
			Queue<string> cars = new Queue<string>();


			string input;
			while ((input = Console.ReadLine()) != "end")
			{
				if (input != "green")
				{
					cars.Enqueue(input);
				}
				else if (input == "green")
				{
					int count = n;
					while (cars.Count > 0 && count > 0)
					{
						Console.WriteLine($"{cars.Dequeue()} passed!");
						count--;
						allCount++;
					}
				}
			}

			Console.WriteLine($"{allCount} cars passed the crossroads.");
		}
	}
}
