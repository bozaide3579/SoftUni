using OldestFamilyMember;

int n = int.Parse(Console.ReadLine());

Family family = new Family();

for (int i = 0; i < n; i++)
{
	string[] data = Console.ReadLine()
		.Split(' ', StringSplitOptions.RemoveEmptyEntries);

	Person currentMember = new Person(data[0], int.Parse(data[1]));
	family.AddMember(currentMember);
}

Person oldestMember = family.GetOldestMember();
Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");




/*
5
Steve 10
Christopher 15
Annie 4
Ivan 35
Maria 34
*/