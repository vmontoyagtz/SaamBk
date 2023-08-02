using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorConfiguration
        : IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {
            builder.ToTable("Advisor", "dbo");
            builder.HasKey(t => t.AdvisorId);
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AdvisorFirstName)
                .IsRequired()
                .HasColumnName("AdvisorFirstName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorLastName)
                .IsRequired()
                .HasColumnName("AdvisorLastName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorNote)
                .HasColumnName("AdvisorNote")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorTitle)
                .IsRequired()
                .HasColumnName("AdvisorTitle")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorJsonResume)
                .IsRequired()
                .HasColumnName("AdvisorJsonResume")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.IsNaturalPerson)
                .IsRequired()
                .HasColumnName("IsNaturalPerson")
                .HasColumnType("bit");
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
            builder.Property(t => t.GenderId)
                .IsRequired()
                .HasColumnName("GenderId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.PaymentFrequencyId)
                .IsRequired()
                .HasColumnName("PaymentFrequencyId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.TaxInformationId)
                .IsRequired()
                .HasColumnName("TaxInformationId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.BusinessUnit)
                .WithMany(t => t.Advisors)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_Advisor_BusinessUnit");
            builder.HasOne(t => t.Gender)
                .WithMany(t => t.Advisors)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Advisor_Gender");
            builder.HasOne(t => t.PaymentFrequency)
                .WithMany(t => t.Advisors)
                .HasForeignKey(d => d.PaymentFrequencyId)
                .HasConstraintName("FK_Advisor_PaymentFrequency");
            builder.HasOne(t => t.TaxInformation)
                .WithMany(t => t.Advisors)
                .HasForeignKey(d => d.TaxInformationId)
                .HasConstraintName("FK_Advisor_TaxInformation");
        }
    }
}