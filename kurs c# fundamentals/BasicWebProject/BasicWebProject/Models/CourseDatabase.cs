namespace BasicWebProject.Models
{
    public class CourseDatabase
    {

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            for (int i = 0; i <= 10; i++)
            {
                courses.Add(new Course($"Course N-{i}"));
            }

            return courses;
        }
    }
}
