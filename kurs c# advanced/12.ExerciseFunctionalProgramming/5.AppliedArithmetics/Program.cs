
Action<int[], Func<int, int>> changeAllElements = (arr, changeFunc) =>
{
	for (int i = 0; i < arr.Length; i++)
	{
		arr[i] = changeFunc(arr[i]);
	}
};

Dictionary<string, Action<int[]>> operations = new Dictionary<string, Action<int[]>>
{
	["add"] = arr => changeAllElements(arr, x => x + 1),
	["subtract"] = arr => changeAllElements(arr, x => x - 1),
	["multiply"] = arr => changeAllElements(arr, x => 2 * x),
	["print"] = arr => Console.WriteLine(string.Join(' ', arr)),
};

int[] numbers = Console.ReadLine()
	.Split(' ', StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

string command = Console.ReadLine();
while (command != "end")
{
	Action<int[]> currentOperation = operations[command];
	currentOperation(numbers);


	command = Console.ReadLine();
}



