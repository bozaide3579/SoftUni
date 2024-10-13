
internal class Program
{
    static void Main(string[] args)
    {
        List<string> list = Console.ReadLine().Split("!").ToList();

        string input;
        while ((input = Console.ReadLine()) != "Go Shopping!")
        {
            string[] commands = input.Split();

            if (commands[0] == "Urgent")
            {
                string item = commands[1];
                if (!list.Contains(item))
                {
                    list.Insert(0, item);
                }
               
            }
            else if (commands[0] == "Unnecessary")
            {
                string item = commands[1];
                if (list.Contains(item))
                {
                    list.RemoveAt(list.IndexOf(item));
                }
            }
            else if (commands[0] == "Correct")
            {
                string oldItem = commands[1];
                string newItem = commands[2];
                if (list.Contains(oldItem))
                {
                    int index = list.IndexOf(oldItem);
                    list[index] = newItem;
                }

            }
            else if (commands[0] == "Rearrange")
            {
                string item = commands[1];
                if (list.Contains(item))
                {
                    list.RemoveAt(list.IndexOf(item));
                    list.Add(item);
                }

            }
        }
        Console.WriteLine(string.Join(", ", list));
    }
}
