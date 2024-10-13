using System.Formats.Asn1;

namespace _8.SoftUniParty
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> regular = new HashSet<string>();
			HashSet<string> vip = new HashSet<string>();

			string input;
			while ((input = Console.ReadLine()) != "PARTY")
			{
				if (char.IsDigit(input[0]))
				{
					vip.Add(input);
				}
				else
				{
					regular.Add(input);
				}
			}

			while ((input = Console.ReadLine()) != "END")
			{
				if (vip.Contains(input))
				{
					vip.Remove(input);
				}
				else if (regular.Contains(input))
				{
					regular.Remove(input);
				}
			}

			Console.WriteLine(vip.Count + regular.Count);

			foreach (string v in vip)
			{
				Console.WriteLine(v);
			}

			foreach (string r in regular)
			{
				Console.WriteLine(r);
			}

		}
	}
}
