namespace Tuple
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string[] firstData = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			string firstName = firstData[0], lastName = firstData[1], adress = firstData[2];

			Tuple<string, string> firstTuple = new Tuple<string, string>($"{firstName} {lastName}", adress);

			string[] secondData = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			string name = secondData[0];
			int litersOfBeer = int.Parse(secondData[1]);

			Tuple<string, int> secondTuple = new Tuple<string, int>(name , litersOfBeer);

			string[] thirdData = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			int num1 = int.Parse(thirdData[0]);	
			double num2 = double.Parse(thirdData[1]);

			Tuple<int, double> thirdTuple = new Tuple<int, double>(num1, num2);


			Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
			Console.WriteLine(thirdTuple);
        }
	}
}
