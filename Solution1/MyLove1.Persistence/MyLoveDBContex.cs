using Microsoft.EntityFrameworkCore;

namespace MyLove1.Persistence
{
    public class MyLoveDBContex : DbContext
    {
        public MyLoveDBContex(DbContextOptions<MyLoveDBContex> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyLoveDBContex).Assembly);
            modelBuilder.HasDefaultSchema("MyLove");
        }
    }
}
