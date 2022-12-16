using Microsoft.EntityFrameworkCore;
using STC.Data.Mappings;
using STC.Models;

namespace STC.Data
{
    public class DataContext : DbContext
    {
        #region DbSet

        public DbSet<Client> Client { get; set; }
        public DbSet<Professional> Professional { get; set; }
        public DbSet<TypeConsultation> TypeConsultation { get; set; }
        public DbSet<User> User { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=STC;User ID=sa;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ProfessionalMap());
            modelBuilder.ApplyConfiguration(new TypeConsultationMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}