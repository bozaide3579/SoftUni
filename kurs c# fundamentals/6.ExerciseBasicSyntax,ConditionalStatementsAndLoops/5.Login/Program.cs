

string username = Console.ReadLine();

char[] stringArray = username.ToCharArray();
Array.Reverse(stringArray);
string password = new string(stringArray);
int attempts = 4;

while (attempts > 0)
{
    attempts--;
    string typedPass = Console.ReadLine();

    if (password == typedPass)
    {
        Console.WriteLine($"User {username} logged in.");
        break;
    }
    else if (password != typedPass)
    {
        if (attempts == 0)
        {
            Console.WriteLine($"User {username} blocked!");
            break;
        }

        Console.WriteLine($"Incorrect password. Try again.");
    }
    
    
}
