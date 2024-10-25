

int[] array = new int[] { 1, 2, 3, 4, 5, 6};
Console.WriteLine(Sum(array));

int Sum(int[] array, int index = 0)
{
	if (index >= array.Length)
	{
		return 0;
	}

	int sum = array[index] + Sum(array, index + 1);

	return sum;
}

