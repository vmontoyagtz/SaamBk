using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class BusinessUnitTypeConfiguration
        : IEntityTypeConfiguration<BusinessUnitType>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitType> builder)
        {
            builder.ToTable("BusinessUnitType", "dbo");
            builder.HasKey(t => t.BusinessUnitTypeId);
            builder.Property(t => t.BusinessUnitTypeId)
                .IsRequired()
                .HasColumnName("BusinessUnitTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BusinessUnitTypeName)
                .IsRequired()
                .HasColumnName("BusinessUnitTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.BusinessUnitTypeDescription)
                .HasColumnName("BusinessUnitTypeDescription")
                .HasColumnType("nvarchar(max)");
        }
    }
}