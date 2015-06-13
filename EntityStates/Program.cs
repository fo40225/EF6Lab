using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityStates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Update without load
            using (var db = new BlogEntities())
            {
                var existBlog = new BlogSet()
                {
                    Id = 3,
                    Name = "kk"
                };

                db.BlogSets.Attach(existBlog);
                db.Entry(existBlog).Property(x => x.Name).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}