using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class TaxInformationConfiguration
        : IEntityTypeConfiguration<TaxInformation>
    {
        public void Configure(EntityTypeBuilder<TaxInformation> builder)
        {
            builder.ToTable("TaxInformation", "dbo");
            builder.HasKey(t => t.TaxInformationId);
            builder.Property(t => t.TaxInformationId)
                .IsRequired()
                .HasColumnName("TaxInformationId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.BusinessTypeId)
                .IsRequired()
                .HasColumnName("BusinessTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TaxInformationBusinessName)
                .HasColumnName("TaxInformationBusinessName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TaxInformationCommercialName)
                .HasColumnName("TaxInformationCommercialName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TaxInformationRegistrationId)
                .IsRequired()
                .HasColumnName("TaxInformationRegistrationId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TaxInformationBusinessIndustry)
                .HasColumnName("TaxInformationBusinessIndustry")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.BusinessUnitId)
                .IsRequired()
                .HasColumnName("BusinessUnitId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TaxpayerTypeId)
                .IsRequired()
                .HasColumnName("TaxpayerTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.TaxInformations)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_TaxInformation_BusinessUnit");
            builder.HasOne(t => t.TaxpayerType)
                .WithMany(t => t.TaxInformations)
                .HasForeignKey(d => d.TaxpayerTypeId)
                .HasConstraintName("FK_TaxInformation_TaxpayerType");
        }
    }
}