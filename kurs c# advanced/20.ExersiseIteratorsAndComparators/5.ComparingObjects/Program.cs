using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace _5.ComparingObjects
{
	public class Program
	{
		public static void Main()
		{
			List<Person> people = new List<Person>();

			string input = Console.ReadLine();
			while (input != "END")
			{
				string[] data = input.Split();
				Person currentPerson = new Person(data[0], int.Parse(data[1]), data[2]);

				people.Add(currentPerson);	

				input = Console.ReadLine();
			}

			int n = int.Parse(Console.ReadLine());

			int targetIndex = n - 1;
			int matches = people.Count(x => x.CompareTo(people[n - 1]) == 0);

			if (matches == 1)
			{
                Console.WriteLine("No matches");
            }
			else
			{
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
		}
	}
}
