
using System.Xml;

internal class Program
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }


    static void Main()
    {

        List<Person> persons = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();

            string name = arguments[0];
            string id = arguments[1];
            int age = int.Parse(arguments[2]);

            Person foundPerson = persons.FirstOrDefault(x => x.Id == id);

            if (foundPerson != null)
            {
                foundPerson.Age = age;
                foundPerson.Name = name;
            }
            else
            {

                Person person = new Person(name, id, age);
                persons.Add(person);

            }
        }

        var sortPersons = persons.OrderBy(person => person.Age);

        foreach (Person person in sortPersons)
        {
            Console.WriteLine(person.ToString());
        }
    }
}
