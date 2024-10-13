

int[] ints = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

int lower = ints[0];
int upper = ints[1];

string parity = Console.ReadLine();

Predicate<int> isValid;
if (parity == "even") isValid = x => x % 2 == 0;
else if (parity == "odd") isValid = x => x % 2 != 0;
else isValid = x => false;

List<int> result = new List<int>();
for (int i = lower; i <= upper; i++)
{
	if (isValid(i))
	{
		result.Add(i);
	}
}

Console.WriteLine(string.Join(" ", result));