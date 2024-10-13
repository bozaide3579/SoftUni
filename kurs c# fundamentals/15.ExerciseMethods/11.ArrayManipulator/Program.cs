
using System.Security.Authentication;

class Program
{
    static void Main()
    {

        int[] nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] commandArgs = input.Split();
            int count;
            string type;

            switch (commandArgs[0])
            {
                case "exchange":
                    int index = int.Parse(commandArgs[1]);
                    nums = ExchangeElements(nums, index);
                    break;
                case "max":
                    type = commandArgs[1];
                    PrintMaxIndex(nums, type);
                    break;
                case "min":
                    type = commandArgs[1];
                    PrintMinIndex(nums, type);
                    break;
                case "first":
                    count = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    PrintFirstElements(nums, count, type);
                    break;
                case "last":
                    count = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    PrintLastElements(nums, count, type);
                    break;

            }

        }

        Console.WriteLine($"[{string.Join(", ", nums)}]");
    }

    static int[] ExchangeElements(int[] nums, int index)
    {
        if (CheckIndexOutOfRange(nums, index))
        {
            Console.WriteLine("Invalid index");
            return nums;
        }

        int[] changedArray = new int[nums.Length];
        int changedArrayIndex = 0;

        for (int i = index + 1; i <= nums.Length - 1; i++)
        {
            changedArray[changedArrayIndex++] = nums[i];
        }

        for (int i = 0; i < index; i++)
        {
            changedArray[changedArrayIndex++] = nums[i];
        }


        return changedArray;
    }

    static void PrintMaxIndex(int[] nums, string type)
    {
        int maxIndex = -1;
        int maxNum = int.MinValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (IsOddOrEven(type, num))
            {
                if (num >= maxNum)
                {
                    maxNum = num;
                    maxIndex = i;
                }
            }
        }

        if (maxIndex != -1)
        {
            Console.WriteLine(maxIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }

    }

    static void PrintMinIndex(int[] nums, string type)
    {
        int minIndex = -1;
        int minNum = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (IsOddOrEven(type, num))
            {
                if (num <= minNum)
                {
                    minNum = num;
                    minIndex = i;
                }
            }
        }

        if (minIndex != -1)
        {
            Console.WriteLine(minIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    static void PrintFirstElements(int[] nums, int count, string type)
    {

        if (count > nums.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }
        string firstElements = "";
        int elementsCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (IsOddOrEven(type, num))
            {
                elementsCount++;
                firstElements += $"{num}, ";
                if (elementsCount >= count)
                {
                    break;
                }
            }

        }


        Console.WriteLine($"[{firstElements.TrimEnd(' ', ',')}]");
    }

    static void PrintLastElements(int[] nums, int count, string type)
    {

        if (count > nums.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }
        string lastElements = "";
        int elementsCount = 0;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int num = nums[i];
            if (IsOddOrEven(type, num))
            {
                elementsCount++;
                lastElements = $"{num}, " + lastElements;
                if (elementsCount >= count)
                {
                    break;
                }
            }

        }


        Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
    }

    static bool IsOddOrEven(string type, int num)
    {
        return (type == "even" && num % 2 == 0) ||
                (type == "odd" && num % 2 != 0);
    }

    static bool CheckIndexOutOfRange(int[] nums, int index)
    {
        return index < 0 || index >= nums.Length - 1;
    }

}