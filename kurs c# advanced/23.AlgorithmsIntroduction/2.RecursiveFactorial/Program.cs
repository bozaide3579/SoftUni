


Console.WriteLine(Factorial(5));



int Factorial(int n)
{
	if (n == 1)
	{
		return 1;
	}


	int nMinsumOneFact = Factorial(n - 1);

	return n * nMinsumOneFact;
}