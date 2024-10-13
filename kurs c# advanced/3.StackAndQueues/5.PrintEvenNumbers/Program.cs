



int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> queue = new Queue<int>(numbers);

foreach (int number in numbers)
{
	if (number % 2 == 1)
	{
		queue.Dequeue();
	}
	else
	{
		queue.Enqueue(queue.Dequeue());
	}
}

Console.WriteLine(String.Join(", ", queue));
