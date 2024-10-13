using System.Runtime.CompilerServices;

namespace DefiningClasses;

public class StartUp
{
	public static void Main()
	{
		Person p1 = new Person();
		p1.Name = "Peter";
		p1.Age = 20;

		Person p2 = new Person { Name = "Gerorge", Age = 18 };

		Person p3 = new Person("Jose", 43);
	}
}
