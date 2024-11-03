namespace BorderControl
{
	public class Program
	{
		public static void Main()
		{
			List<IIdentifiable> entities = new List<IIdentifiable>();

			string input = Console.ReadLine()!;
			while (input != "End")
			{
				string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if (data.Length == 2)
				{
					entities.Add(new Robot(data[0], data[1]));
				}
				else if (data.Length == 3)
				{
					entities.Add(new Citizen(data[0], int.Parse(data[1]), data[2]));
				}

				input = Console.ReadLine()!;
			}

			string fakeSuffix = Console.ReadLine()!;

			foreach (IIdentifiable entity in entities)
			{
				if (entity.Id.EndsWith(fakeSuffix))
				{
                    Console.WriteLine(entity.Id);
                }
			}
		}
	}
}
