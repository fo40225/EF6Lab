namespace CodeFirstFromDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
        }

        public virtual DbSet<Blog> Blogs
        {
            get;
            set;
        }
        public virtual DbSet<Post> Posts
        {
            get;
            set;
        }
        public virtual DbSet<User> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
