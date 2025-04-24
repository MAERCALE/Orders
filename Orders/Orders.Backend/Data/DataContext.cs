using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entites;

namespace Orders.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> conection) : base(conection)

        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Country> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name ).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        }
    }
}