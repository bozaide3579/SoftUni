
using System.Threading.Channels;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        int shotCount = 0;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            int index = int.Parse(input);   

            if (index >= 0 && index < list.Count)
            {
                if (list[index] != -1)
                {
                    int targetValue = list[index];
                    list[index] = -1;
                    shotCount++;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != -1)
                        {
                            if (list[i] <= targetValue)
                            {
                                list[i] += targetValue;
                            }
                            else
                            {
                                list[i] -= targetValue;
                            }
                        }
                    }

                }




            }



        }

        Console.WriteLine($"Shot targets: {shotCount} -> {string.Join(" ", list)}");




    }
}
