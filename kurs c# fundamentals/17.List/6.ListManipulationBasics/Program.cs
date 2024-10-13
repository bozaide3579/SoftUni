

List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

string input;
while ((input = Console.ReadLine()) != "end")
{

    string[] inputParts = input.Split();


    if (inputParts[0] == "Add")
    {
        int numToAdd = int.Parse(inputParts[1]);
        list.Add(numToAdd);
    }
    else if (inputParts[0] == "Remove") 
    { 
        int numToRemove = int.Parse(inputParts[1]);
        list.Remove(numToRemove); 

    }
    else if (inputParts[0] == "RemoveAt")
    {
        int indexToRemove = int.Parse(inputParts[1]);
        list.RemoveAt(indexToRemove);

    }
    else if (inputParts[0] == "Insert")
    {
        int numToInsert = int.Parse(inputParts[1]);  
        int indexToInerst = int.Parse(inputParts[2]);
        list.Insert(indexToInerst, numToInsert);
        
    }



}

Console.WriteLine(string.Join(" ", list));