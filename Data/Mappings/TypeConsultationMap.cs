using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STC.Models;

namespace STC.Data.Mappings
{
    public class TypeConsultationMap : IEntityTypeConfiguration<TypeConsultation>
    {
        public void Configure(EntityTypeBuilder<TypeConsultation> builder)
        {
            builder.ToTable("TypeConsultation");

            builder.HasKey(x => x.TypeId);
            builder.Property(x => x.TypeId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.TypeName)
                .IsRequired()
                .HasColumnName("TypeName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.TypePrice)
                .IsRequired()
                .HasColumnName("TypePrice")
                .HasColumnType("DECIMAL")
                .HasPrecision(18, 3);

            builder.Property(x => x.TypeActive)
                .IsRequired()
                .HasColumnName("TypeActive")
                .HasColumnType("BIT");
        }
    }
}