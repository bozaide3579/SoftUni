namespace _10.Crossroads
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int greenLight = int.Parse(Console.ReadLine());
			int freeWindow = int.Parse(Console.ReadLine());

			Queue<string> queue = new Queue<string>();

			bool hadCrash = false;
			int passedCars = 0;

			string input = Console.ReadLine();
			while (input != "END")
			{
				if (input == "green")
				{
					int remaningTime = greenLight;
					while (!hadCrash && queue.Count > 0 && remaningTime > 0)
					{
						string currentCar = queue.Dequeue();
						remaningTime -= currentCar.Length;

						if (remaningTime < 0 && Math.Abs(remaningTime) > freeWindow)
						{
							int offset = freeWindow + remaningTime;
							char crashPosition = currentCar[currentCar.Length + offset];

							hadCrash = true;
							Console.WriteLine("A crash happened!");
							Console.WriteLine($"{currentCar} was hit at {crashPosition}.");


						}
						else
						{
							passedCars++;
						}
					}

					if (hadCrash)
					{
						break;
					}
				}
				else
				{
					queue.Enqueue(input);
				}

				input = Console.ReadLine();
			}

			if (!hadCrash)
			{
				Console.WriteLine("Everyone is safe.");
				Console.WriteLine($"{passedCars} total cars passed the crossroads.");
			}
		}
	}
}
