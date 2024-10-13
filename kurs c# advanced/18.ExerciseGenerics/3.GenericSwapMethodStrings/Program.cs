using System.Threading.Channels;

namespace _3.GenericSwapMethodStrings
{
	public class Program
	{
		public static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			List<Box<string>> list = new List<Box<string>>(capacity: n);
			for (int i = 0; i < n; i++)
			{
				string currentLine = Console.ReadLine();
				list.Add(new Box<string>(currentLine));
			}

			int[] swapIndices = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
			Swap(list, swapIndices[0], swapIndices[1]);

			foreach(Box<string> box in list)
			{
                Console.WriteLine(box);
            }
		}

		private static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
		{
			T swapValue = list[firstIndex];
			list[firstIndex] = list[secondIndex];
			list[secondIndex] = swapValue;
		}

		
	}
}
