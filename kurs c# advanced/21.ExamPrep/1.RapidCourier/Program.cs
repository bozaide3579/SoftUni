namespace _1.RapidCourier
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> packages = new Stack<int>(Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));
			 
			Queue<int> couriers = new Queue<int>(Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse));

			int totalWeight = 0;

			while (packages.Count > 0 && couriers.Count > 0)
			{
				int package = packages.Pop();
				int courier = couriers.Dequeue();

				if (package <= courier)
				{
					if (package * 2 < courier)
					{
						courier -= package * 2;
						couriers.Enqueue(courier);
					}
					
					totalWeight += package;	
				}
				else
				{
					package -= courier;
					packages.Push(package);
					totalWeight += courier;
				}
			}

			Console.WriteLine($"Total weight: {totalWeight} kg");
			if (couriers.Count == 0 && packages.Count == 0 )
			{
                Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
            }
			else if (couriers.Count == 0 && packages.Count > 0)
		    {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {String.Join(", ", packages)}");
            }
			else if (couriers.Count > 0 && packages.Count == 0)
			{
                Console.WriteLine($"Couriers are still on duty: {String.Join(", ", couriers)} but there are no more packages to deliver.");
            }
        }
	}
}
