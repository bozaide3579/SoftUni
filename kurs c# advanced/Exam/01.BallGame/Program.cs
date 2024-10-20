using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;

namespace _01.BallGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> strenght = new Stack<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));
			Queue<int> accuracy = new Queue<int>(Console.ReadLine()
				.Split(" ")
				.Select(int.Parse));

			int goals = 0;
			while (strenght.Count > 0 && accuracy.Count > 0)
			{
				int currentStrenght = strenght.Peek();
				int currentAccuracy = accuracy.Peek();

				int sum = currentStrenght + currentAccuracy;

				if (sum == 100)
				{
					goals++;
					strenght.Pop();
					accuracy.Dequeue();
				}
				else if (sum < 100)
				{
					if (currentStrenght < currentAccuracy)
					{
						strenght.Pop() ;
					}
					else if (currentStrenght > currentAccuracy)
					{
						accuracy.Dequeue() ;
					}
					else
					{
						accuracy.Dequeue();
						strenght.Pop();

						strenght.Push(sum);
					}
				}
				else if (sum > 100)
				{
					strenght.Pop();
					accuracy.Dequeue();

					int updatedStrenght = currentStrenght - 10;
					strenght.Push(updatedStrenght);

					accuracy.Enqueue(currentAccuracy);
				}
			}
			if (goals == 3)
			{
                Console.WriteLine("Paul scored a hat-trick!");
			}
			else if (goals == 0)
			{
                Console.WriteLine("Paul failed to score a single goal.");
            }
			else if (goals > 3)
			{
                Console.WriteLine("Paul performed remarkably well!");
            }
            else if (goals > 0 && goals < 3) 
            {
                Console.WriteLine("Paul failed to make a hat-trick.");
            }

			if (goals > 0)
            Console.WriteLine($"Goals scored: {goals}");

			if (strenght.Count > 0)
			{
                Console.WriteLine($"Strength values left: {string.Join(", ", strenght)}");
            }

			if (accuracy.Count > 0)
			{
				Console.WriteLine($"Accuracy values left: {string.Join(", ", accuracy)}");
			}
        }
	}
}


/*
10 20 30 40 90
20 70 20 30 60
*/