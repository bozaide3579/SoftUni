
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {

        string encryptedMessage = Console.ReadLine();

        StringBuilder sb = new StringBuilder(encryptedMessage);

        string input;
        while((input = Console.ReadLine()) != "Decode")
        {
            string[] arguments = input.Split("|");
            string command = arguments[0];

            if (command == "Move")
            {
                int n = int.Parse(arguments[1]);

                for (int i = 0; i < n; i++)
                {
                    char firstChar = sb[0];

                    sb.Append(firstChar);
                    sb.Remove(0, 1);
                }
            }
            else if (command == "Insert")
            {
                int index = int.Parse(arguments[1]);
                string value = arguments[2];

                sb.Insert(index, value);
            }
            else if (command == "ChangeAll")
            {
                string oldvalue = arguments[1];
                string newValue = arguments[2];

                sb.Replace(oldvalue, newValue);
            }
        }

        Console.WriteLine($"The decrypted message is: {sb}");


    }
}
