using System;
using System.Collections.Generic;
using System.Data.Entity; // AsNoTracking
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var aLotOfBlogs = new List<BlogSet>();
            using (var db = new BlogEntities())
            {
                try
                {
                    // Disabling automatic detection of changes for bulk insert.
                    db.Configuration.AutoDetectChangesEnabled = false;

                    // Make many calls in a loop
                    foreach (var blog in aLotOfBlogs)
                    {
                        db.BlogSet.Add(blog);
                    }
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }

                // AsNoTracking query for large numbers of entities in read-only scenarios.
                // Query for all blogs without tracking them
                var blogs1 = db.BlogSet.AsNoTracking();

                // Query for some blogs without tracking them
                var blogs2 = db.BlogSet
                                    .Where(b => b.Name.Contains(".NET"))
                                    .AsNoTracking()
                                    .ToList();
            }
        }
    }
}