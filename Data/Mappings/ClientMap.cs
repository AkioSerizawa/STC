using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STC.Models;

namespace STC.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.CliId);
            builder.Property(x => x.CliId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.CliName)
                .IsRequired()
                .HasColumnName("CliName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliNameMother)
                .HasColumnName("CliNameMother")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliNameFather)
                .HasColumnName("CliNameFather")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliBirthDate)
                .HasColumnName("CliBirthDate")
                .HasColumnType("DATETIME");

            builder.Property(x => x.CliAddressStreet)
                .HasColumnName("CliAddressStreet")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliAddressNeighborhood)
                .HasColumnName("CliAddressNeighborhood")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliAddressFull)
                .HasColumnName("CliAddressFull")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliAddressNumber)
                .HasColumnName("CliAddressNumber")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliAddressCity)
                .HasColumnName("CliAddressCity")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliSchool)
                .HasColumnName("CliSchool")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliSchoolGrade)
                .HasColumnName("CliSchoolGrade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliSchoolCity)
                .HasColumnName("CliSchoolCity")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliSchoolState)
                .HasColumnName("CliSchoolState")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CliPhoneNumber)
                .HasColumnName("CliPhoneNumber")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(16);

            builder.Property(x => x.CliPhoneCell)
                .HasColumnName("CliPhoneCell")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(16);

            builder.Property(x => x.CliNote)
                .HasColumnName("CliNote")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.CliActive)
                .IsRequired()
                .HasColumnName("CliActive")
                .HasColumnType("BIT");
        }
    }
}