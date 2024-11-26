using Microsoft.EntityFrameworkCore;
using WaterLevels.Models;

namespace WaterLevels.Database
{
    public class WaterLevelContext : DbContext
    {
        public DbSet<WaterLevelRecord> WaterLevels { get; set; }

        public WaterLevelContext(DbContextOptions<WaterLevelContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            string connStr = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=Waters;Integrated Security=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connStr);

            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WaterLevelRecord>()
               .Property(d => d.Date)
               .IsRequired();

            modelBuilder.Entity<WaterLevelRecord>()
                .Property(d => d.Value)
                .IsRequired();
        }

    }
}
