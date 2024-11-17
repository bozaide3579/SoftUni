namespace SquareRoot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				int n = int.Parse(Console.ReadLine());

				if (n < 0)
				{
					Console.WriteLine("Invalid number.");
				}
				else
				{
					double squareRoot = Math.Sqrt(n);
					Console.WriteLine(squareRoot);
				}

			}
			catch (ArgumentNullException ex)
			{
				throw;
			}
			finally
			{
                Console.WriteLine("Goodbye.");
            }
		}
	}
}
