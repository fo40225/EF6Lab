using System;
using System.Collections.Generic;
using System.Data.Entity; // important
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Eagerly Loading
            using (var db = new BlogEntities())
            {
                // Load all blogs and related PostSets
                var blogs1 = db.BlogSets
                                      .Include(b => b.PostSets)
                                      .ToList();

                // Load one blogs and its related PostSets
                var blog1 = db.BlogSets
                                    .Where(b => b.Name == "ADO.NET Blog")
                                    .Include(b => b.PostSets)
                                    .FirstOrDefault();

                // Load all blogs and related PostSets
                // using a string to specify the relationship
                var blogs2 = db.BlogSets
                                      .Include("PostSets")
                                      .ToList();

                // Load one blog and its related PostSets
                // using a string to specify the relationship
                var blog2 = db.BlogSets
                                    .Where(b => b.Name == "ADO.NET Blog")
                                    .Include("PostSets")
                                    .FirstOrDefault();
            }

            using (var db = new BlogEntities())
            {
                // Turn off lazy loading for all entities
                db.Configuration.LazyLoadingEnabled = false;

                //Explicitly Loading
                var post = db.PostSets.Find(2);

                // Load the blog related to a given post
                db.Entry(post).Reference(p => p.BlogSet).Load();

                // Load the blog related to a given post using a string
                db.Entry(post).Reference("BlogSet").Load();

                var blog = db.BlogSets.Find(1);

                // Load the PostSets related to a given blog
                db.Entry(blog).Collection(p => p.PostSets).Load();

                // Load the PostSets related to a given blog
                // using a string to specify the relationship
                db.Entry(blog).Collection("PostSets").Load();

                // Load the posts with the 'entity-framework' tag related to a given blog
                db.Entry(blog)
                    .Collection(b => b.PostSets)
                    .Query()
                    .Where(p => p.Content.Contains("entity-framework"))
                    .Load();

                // Load the posts related to a given blog
                // using a string to specify the relationship
                db.Entry(blog)
                    .Collection("PostSets")
                    .Query()
                    .Load();
            }
        }
    }
}