

using System.Xml;

List<int> list = Console.ReadLine().Split()
    .Select(int.Parse)
    .ToList();

List<int> res = new List<int>();

for (int i = 0; i < list.Count/2; i++)
{
    res.Add(list[i] + list[list.Count - 1 - i]);
}

if (list.Count % 2 == 1)
{
    res.Add(list[list.Count/2]);
}

Console.WriteLine(String.Join(" ", res)); 