

List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

List<int> mergedList = new List<int>();

int count = list1.Count;

if (count < list2.Count)
{
    count = list2.Count;
}

for (int i = 0; i < count; i++)
{
    if (i < list1.Count)
    {
        mergedList.Add(list1[i]);
    }

    if (i < list2.Count)
    {
        mergedList.Add(list2[i]);
    }
}

Console.WriteLine(String.Join(" ", mergedList));