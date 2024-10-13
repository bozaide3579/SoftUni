namespace _7.ParkingLot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> cars = new HashSet<string>();

			string input;
			while ((input = Console.ReadLine()) != "END")
			{
				string[] splitted = input.Split(", ");
				string direction = splitted[0];
				string car = splitted[1];

				if (direction == "IN")
				{
					cars.Add(car);
				}
				else if (direction == "OUT")
				{
					cars.Remove(car);
				}

			}

			if (cars.Count > 0)
			{
				foreach (string car in cars)
				{
					Console.WriteLine(car);
				}
			}
			else
			{
				Console.WriteLine("Parking Lot is Empty");
			}
		}
	}
}
