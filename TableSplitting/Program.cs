using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSplitting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new SchoolEntities())
            {
                Person person = new Person()
                {
                    FirstName = "Kimberly",
                    LastName = "Morgan",
                    Discriminator = "Instructor",
                };

                person.HireInfo = new HireInfo()
                {
                    HireDate = DateTime.Now
                };

                // Add the new person to the context.
                db.People.Add(person);

                // Insert a row into the Person table.
                db.SaveChanges();

                // Execute a query against the Person table.
                // The query returns columns that map to the Person entity.
                var existingPerson = db.People.FirstOrDefault();

                // Execute a query against the Person table.
                // The query returns columns that map to the Instructor entity.
                var hireInfo = existingPerson.HireInfo;

                Console.WriteLine("{0} was hired on {1}",
                    existingPerson.LastName, hireInfo.HireDate);
            }
        }
    }
}