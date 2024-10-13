
using System.Text.RegularExpressions;

internal class Program
{
	static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());
		string pattern = @"@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+";

		for (int i = 0; i < n; i++)
		{
			string text = Console.ReadLine();

			if (Regex.IsMatch(text, pattern))
			{
				string productGroup = "";
				foreach (char ch in text)
				{
					if (char.IsDigit(ch))
					{
						productGroup += ch;
					}
				}

				if (string.IsNullOrEmpty(productGroup))
				{
					productGroup = "00";
				}

				Console.WriteLine($"Product group: {productGroup}");

			}
			else
			{
				Console.WriteLine("Invalid barcode");
			}



		}
	}
}

