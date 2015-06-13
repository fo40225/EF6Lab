using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new Model1Container())
            {
                var prod = new Product()
                {
                    Name = "aaa",
                    Version = new Version()
                    {
                        Major = "7",
                        Minor = "03",
                        CL = "123456",
                        BuildTime = "99999999"
                    }
                };
                db.ProductSet.Add(prod);

                db.SaveChanges();

                var query = db.ProductSet.Where(x => x.Version.Major == "7").Select(x => x.Name);

                foreach (var name in query)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}