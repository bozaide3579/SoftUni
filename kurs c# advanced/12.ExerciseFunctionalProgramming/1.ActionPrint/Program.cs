﻿
Action<string> print = x => Console.WriteLine(x);

string[] values = Console.ReadLine()
	.Split(' ', StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < values.Length; i++)
{
	print(values[i]);
}
		