

internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] commands = input.Split();

            if (commands[0] == "swap")
            {
                int index1 = int.Parse(commands[1]);
                int index2 = int.Parse(commands[2]);

                int temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;


            }
            else if (commands[0] == "multiply")
            {
                int index1 = int.Parse(commands[1]);
                int index2 = int.Parse(commands[2]);

                array[index1] = array[index1] * array[index2];


            }
            else if (commands[0] == "decrease")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i]--;
                }
            }
        }

        Console.WriteLine(string.Join(", ", array));
    }   
}