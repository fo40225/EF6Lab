using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolEntities())
            {
                Console.WriteLine("All people:");
                foreach (var person in db.People)
                {
                    Console.WriteLine("    {0} {1}", person.FirstName, person.LastName);
                }

                Console.WriteLine("Instructors only: ");
                foreach (var person in db.People.OfType<Instructor>())
                {
                    Console.WriteLine("    {0} {1}", person.FirstName, person.LastName);
                }

                Console.WriteLine("Students only: ");
                foreach (var person in db.People.OfType<Student>())
                {
                    Console.WriteLine("    {0} {1}", person.FirstName, person.LastName);
                }
            }
        }
    }
}
