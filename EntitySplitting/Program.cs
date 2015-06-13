using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySplitting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EntitySplittingEntities())
            {
                var person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    Phone = "555-555-5555"
                };

                db.People.Add(person);
                db.SaveChanges();

                foreach (var item in db.People)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
