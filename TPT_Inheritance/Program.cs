using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPT_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolEntities())
            {
                foreach (var department in db.Departments)
                {
                    Console.WriteLine("The {0} department has the following courses:",
                                       department.Name);

                    Console.WriteLine("   All courses");
                    foreach (var course in department.Courses)
                    {
                        Console.WriteLine("     {0}", course.Title);
                    }

                    foreach (var course in department.Courses.
                        OfType<OnlineCourse>())
                    {
                        Console.WriteLine("   Online - {0}", course.Title);
                    }

                    foreach (var course in department.Courses.
                        OfType<OnsiteCourse>())
                    {
                        Console.WriteLine("   Onsite - {0}", course.Title);
                    }
                }
            }
        }
    }
}
