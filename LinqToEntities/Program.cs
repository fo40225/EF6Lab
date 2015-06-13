using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEntities
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new SchoolEntities())
            {
                // Query for all Person with names starting with B
                var people = db.People.Where(x => x.FirstName.StartsWith("B"));

                // Query for the Person named Roger
                var person = db.People.Where(b => b.FirstName == "Roger").FirstOrDefault();

                // Will hit the database
                var person2 = db.People.Find(3);

                // Will return the same instance without hitting the database
                var person2Again = db.People.Find(3);

                db.People.Add(new Person
                {
                    PersonID = -1
                });

                // Will find the new person even though it does not exist in the database
                var newPerson = db.People.Find(-1);
            }
        }
    }
}