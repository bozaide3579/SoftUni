namespace DateModifier;

public class Program
{
	public static void Main()
	{
		string first = Console.ReadLine();
		string second = Console.ReadLine();

		int diff = DateModifier.CalculateDiff(first, second);
        Console.WriteLine(diff);
    }
}

