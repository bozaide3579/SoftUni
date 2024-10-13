
internal class Program
{

    class Student
    {
        public string FirstName;
        public string LastName;
        public string Age;
        public string Town;

        public Student(string firstName, string lastName, string age, string town)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Town = town;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] arguments = input.Split();

            string firstName = arguments[0];
            string lastName = arguments[1];
            string age = arguments[2];
            string town = arguments[3];

            Student existingStudent = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (existingStudent != null)
            {
                existingStudent.Age = age;
                existingStudent.Town = town;
            }
            else
            {
                Student student = new Student(firstName, lastName, age, town);
                students.Add(student);

            }

        }

        string townInput = Console.ReadLine();


        List<Student> filteredStudents = students.Where(s => s.Town == townInput).ToList();

        foreach (Student student in filteredStudents)
        {
            Console.WriteLine(student.ToString());
        }
    }
}
