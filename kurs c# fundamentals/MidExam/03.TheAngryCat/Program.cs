
internal class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split(",").Select(int.Parse).ToList();
        int entry = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();


        int entryValue = list[entry];

        int leftDamage = 0;
        for (int i = 0; i < entry; i++)
        {
            if ((type == "cheap" && list[i] < entryValue) ||
                (type == "expensive" && list[i] >= entryValue))
            {
                leftDamage += list[i];
            }
        }

        int rightDamage = 0;
        for (int i = entry + 1; i < list.Count; i++)
        {
            if ((type == "cheap" && list[i] < entryValue) ||
                (type == "expensive" && list[i] >= entryValue))
            {
                rightDamage += list[i];
            }
        }

        if (leftDamage >= rightDamage)
        {
            Console.WriteLine($"Left - {leftDamage}");
        }
        else
        {
            Console.WriteLine($"Right - {rightDamage}");
        }

    }
}
