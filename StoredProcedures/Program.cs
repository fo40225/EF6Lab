using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new SchoolEntities())
            {
                // Specify the Student ID.
                int studentId = 2;

                // Call GetStudentGrades and iterate through the returned collection.
                foreach (var grade in db.GetStudentGrades(studentId))
                {
                    Console.WriteLine("StudentID: {0}", studentId);
                    Console.WriteLine("Student grade: " + grade.Grade);
                }

                // Call GetDepartmentName.
                // Declare the name variable that will contain the value returned by the output parameter.
                ObjectParameter name = new ObjectParameter("Name", typeof(String));
                db.GetDepartmentName(1, name);
                Console.WriteLine("The department name is {0}", name.Value);

                // Use Stored Procedures to CRUD
                var insResults = db.InsertPerson("Martin", "Robyn", DateTime.Now, null, "Instructor");
                int pid = 0;
                foreach (var result in insResults)
                {
                    pid = result.Value;
                    Console.WriteLine("New Preson ID: {0}", pid.ToString());
                }

                int updResult = db.UpdatePerson(pid, "aaa", "aaa", DateTime.Now.AddDays(1), null, "Instructor");
                Console.WriteLine(updResult.ToString());

                int delResult = db.DeletePerson(pid);
                Console.WriteLine(delResult);

                var newInstructor = new Person
                {
                    FirstName = "Robyn",
                    LastName = "Martin",
                    HireDate = DateTime.Now,
                    Discriminator = "Instructor"
                };

                // Use LINQ to entities to CRUD
                // Add the new object to the db.
                db.People.Add(newInstructor);

                Console.WriteLine("Added {0} {1} to the db.",
                    newInstructor.FirstName, newInstructor.LastName);

                Console.WriteLine("Before SaveChanges, the PersonID is: {0}",
                    newInstructor.PersonID);

                // SaveChanges will call the InsertPerson sproc.
                // The PersonID property will be assigned the value
                // returned by the sproc.
                db.SaveChanges();

                Console.WriteLine("After SaveChanges, the PersonID is: {0}",
                    newInstructor.PersonID);

                // Modify the object and call SaveChanges.
                // This time, the UpdatePerson will be called.
                newInstructor.FirstName = "Rachel";
                db.SaveChanges();

                // Remove the object from the db and call SaveChanges.
                // The DeletePerson sproc will be called.
                db.People.Remove(newInstructor);
                db.SaveChanges();

                Person deletedInstructor = db.People.
                    Where(p => p.PersonID == newInstructor.PersonID).
                    FirstOrDefault();

                if (deletedInstructor == null)
                    Console.WriteLine("A person with PersonID {0} was deleted.",
                        newInstructor.PersonID);
            }
        }
    }
}