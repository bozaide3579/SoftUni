
using OpinionPoll;

int n = int.Parse(Console.ReadLine());

Person[] people = new Person[n];
for (int i = 0; i < n; i++)
{
	string[] data = Console.ReadLine()
		.Split(' ', StringSplitOptions.RemoveEmptyEntries);
	people[i] = new Person(data[0], int.Parse(data[1]));
}

foreach (Person person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}


    /*
    5
	Niki 33
	Yord 88
	Teo 22
	Lily 44
	Stan 11
	*/