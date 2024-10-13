
using System.Xml;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> result = new List<int>();


        double sumOfIndex = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sumOfIndex += list[i];
        }
        double avgNum = sumOfIndex / (double)list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] > avgNum)
            {
                result.Add(list[i]);
            }
        }

        result.Sort();
        result.Reverse();

        if (result.Count == 0)
        {
            Console.WriteLine("No");
        }
        else 
        {
            int count = result.Count;
            if (count > 5)
            {
                count = 5;
            }

            for (int i = 0; i < count; i++)
            {
                
                    Console.Write(result[i] + " ");
                
            }
        }
    }
}


/*5 2 3 4 -10 30 40 50 20 50 60 60 51*/