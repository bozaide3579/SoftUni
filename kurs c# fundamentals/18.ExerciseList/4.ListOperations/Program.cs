using System;
/*
 1 23 29 18 43 21 20

Add 5

Remove 5

Shift left 3

Shift left 1

End
 */
class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commands = input.Split();
            if (commands[0] == "Add")
            {
                numbers.Add(int.Parse(commands[1]));
            }
            else if (commands[0] == "Insert")
            {
                int num = int.Parse(commands[1]);
                int insertIndex = int.Parse(commands[2]);
                if (IsValidIndex(insertIndex, numbers.Count -1))
                {
                    numbers.Insert(insertIndex, num);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (commands[0] == "Remove")
            {
                int removeIndex = int.Parse(commands[1]);
                if (IsValidIndex(removeIndex, numbers.Count - 1))
                {
                    numbers.RemoveAt(removeIndex);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (commands[0] == "Shift" && commands[1] == "left")
            {
               int count = int.Parse(commands[2]);
                count %= numbers.Count;
                List<int> shifted = numbers.GetRange(0, count);
                numbers.RemoveRange(0, count);
                numbers.InsertRange(numbers.Count, shifted);
            }
            else if (commands[0] == "Shift" && commands[1] == "right")
            {
                int count = int.Parse(commands[2]);
                count %= numbers.Count;
                List<int> shifted = numbers.GetRange(numbers.Count - count, count);
                numbers.RemoveRange(numbers.Count - count, count);
                numbers.InsertRange(0, shifted);
            }

        }

        Console.WriteLine(string.Join(" ", numbers));

    }

    static bool IsValidIndex(int insertIndex, int lastIndex)
    {
        return insertIndex >= 0 && insertIndex <= lastIndex;
    }

}

