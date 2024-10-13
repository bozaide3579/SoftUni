using BasicWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebProject.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Course()
        {
            CourseDatabase courseDatabase = new CourseDatabase();

            List<Course> courses = courseDatabase.GetCourses();

            return View(courses);
        }
    }
}
