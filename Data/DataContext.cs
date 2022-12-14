using Microsoft.EntityFrameworkCore;
using STC.Data.Mappings;
using STC.Models;

namespace STC.Data
{
    public class DataContext : DbContext
    {
        #region DbSet

        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=STC;User ID=sa;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}