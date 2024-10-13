
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        string pass = Console.ReadLine();

        StringBuilder newPass = new StringBuilder();

        for(int i = 0; i < pass.Length; i++)
        {
            newPass.Append((char)(pass[i] + 3));
        }

        Console.WriteLine(newPass);
    }
}
