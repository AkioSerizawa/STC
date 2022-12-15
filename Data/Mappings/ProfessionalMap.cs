using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STC.Models;

namespace STC.Data.Mappings
{
    public class ProfessionalMap : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("Professional");

            builder.HasKey(x => x.ProfId);
            builder.Property(x => x.ProfId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.ProfName)
                .IsRequired()
                .HasColumnName("ProfName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.ProfCell)
                .HasColumnName("ProfCell")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.ProfJob)
                .HasColumnName("ProfJob")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.ProfConsultation)
                .HasColumnName("ProfConsultation")
                .HasColumnType("BIT");

            builder.Property(x => x.ProfActive)
                .IsRequired()
                .HasColumnName("ProfActive")
                .HasColumnType("BIT");
        }
    }
}