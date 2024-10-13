
/*
 
3
Arnoldii<->4
Woodii<->7
Welwitschia<->2
Rate: Woodii - 10
Rate: Welwitschia - 7
Rate: Arnoldii - 3
Rate: Woodii - 5
Update: Woodii - 5
Reset: Arnoldii
Exhibition

 */


internal class Program
{

    class Plant
    {
        public string Name;
        public int Rarity;
        public List<double> Ratings;

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<double>();
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

        for (int i = 0; i < n; i++)
        {
            string[] plantInfo = Console.ReadLine().Split("<->");

            string name = plantInfo[0];
            int rarity = int.Parse(plantInfo[1]);

            if (plants.ContainsKey(name))
            {
                plants[name].Rarity = rarity;
            }
            else
            {
                plants[name] = new Plant(name, rarity);
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "Exhibition")
        {
            string[] splittedInput = input.Split(": ");
            string[] parameters = splittedInput[1].Split(" - ");

            string name = parameters[0];

            if (!plants.ContainsKey(name))
            {
                Console.WriteLine("error");
            }
            else
            {
                if (splittedInput[0] == "Rate")
                {
                    double rating = double.Parse(parameters[1]);

                    plants[name].Ratings.Add(rating);

                }
                else if (splittedInput[0] == "Update")
                {
                    int rarity = int.Parse(parameters[1]);

                    plants[name].Rarity = rarity;
                }
                else if (splittedInput[0] == "Reset")
                {
                    plants[name].Ratings.Clear();
                }
            }
        }

        Console.WriteLine("Plants for the exhibition:");
        foreach (var plant in plants.Values)
        {
            double average = plant.Ratings.Count > 0 ? plant.Ratings.Average() : 0;
            Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {average:f2}");
        }
       
    }
}
