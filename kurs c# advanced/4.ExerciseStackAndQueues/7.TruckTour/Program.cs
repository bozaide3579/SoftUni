namespace _07.TruckTour
{
	public static class Program
	{
		public static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			Queue<int[]> stations = new Queue<int[]>();

			for (int i = 0; i < n; i++)
			{
				int[] currentStation = Console.ReadLine().Split().Select(int.Parse).ToArray();
				stations.Enqueue(currentStation);
			}

			for (int i = 0; i < stations.Count; i++)
			{
				if (CanFinishRoute(stations))
				{
					Console.WriteLine(i);
					break;
				}

				stations.Enqueue(stations.Dequeue());
			}

		}

		public static bool CanFinishRoute(Queue<int[]> stations)
		{

			int fuel = 0;
			bool canFinish = true;

			for (int i = 0; i < stations.Count; i++)
			{
				int[] currentStation = stations.Dequeue();

				fuel += currentStation[0] - currentStation[1];
				canFinish = canFinish && fuel >= 0;

				stations.Enqueue(currentStation);
			}

			return canFinish;
		}
	}
}
