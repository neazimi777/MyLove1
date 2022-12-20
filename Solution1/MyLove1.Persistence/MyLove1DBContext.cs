using Microsoft.EntityFrameworkCore;
using MyLove1.Domain;

namespace MyLove1.Persistence
{
    public class MyLove1DBContext : DbContext
    {
      public DbSet<User> User { get; set; }
        public MyLove1DBContext(DbContextOptions<MyLove1DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyLove1DBContext).Assembly);
            modelBuilder.HasDefaultSchema("MyLove");
        }
    }
}
