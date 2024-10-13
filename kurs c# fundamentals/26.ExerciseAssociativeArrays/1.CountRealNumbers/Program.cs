
internal class Program
{

   
    static void Main(string[] args)
    {
        List<double> nums = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToList();

        SortedDictionary<double, int> numbersCounts = new SortedDictionary<double, int>();

        for (int i = 0; i < nums.Count; i++)
        {
            if (!numbersCounts.ContainsKey(nums[i]))
            {
                numbersCounts.Add(nums[i], 0);
            }

            numbersCounts[nums[i]]++;
        }

        foreach (var num in numbersCounts) 
        {
            Console.WriteLine($"{num.Key} -> {num.Value}");
        }
    }
}
