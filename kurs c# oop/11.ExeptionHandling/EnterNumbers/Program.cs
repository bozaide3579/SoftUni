using System.Threading.Channels;

namespace EnterNumbers
{
	internal class Program
	{
		static void Main()
		{
			int start = 1;
			int end = 100;
			int counter = 0;
			int num = 0;
			int[] numbers = new int[10];

			while (counter < 10)
			{
				try
				{
					num = ReadNumbers(start, end);
					start = num;
					numbers[counter] = num;
					counter++;
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid Number!");
				}
				catch (ArgumentException)
				{
					Console.WriteLine($"Your number is not in range {start} - 100!");
				}
			}

			Console.WriteLine(string.Join(", ", numbers));
		}

		public static int ReadNumbers(int start, int end)
		{
			int num = int.Parse(Console.ReadLine());

			if (num <= start || num >= end)
			{
				throw new ArgumentException($"Your number is not in range {start} - 100!");
			}

			return num;

		}
	}
}
