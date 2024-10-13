
using System;

internal class Program
{

    class Student
    {
        public string Name;
        public List<double> Grades;

        public Student(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public override string ToString()
        {
            return $"{Name} -> {Grades.Average():f2}";
        }
    }

    static void Main()
    {

        Dictionary<string, Student> studentDic = new Dictionary<string, Student>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {

            string name = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!studentDic.ContainsKey(name))
            {
                studentDic.Add(name, new Student(name));
            }

            studentDic[name].Grades.Add(grade);


        }

        var filterdStudents = studentDic.Where(pair => pair.Value.Grades.Average() >= 4.5);

        foreach (var studentPair in filterdStudents)
        {
            Console.WriteLine(studentPair.Value.ToString());
        }
    }
}
