using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorApplicantConfiguration
        : IEntityTypeConfiguration<AdvisorApplicant>
    {
        public void Configure(EntityTypeBuilder<AdvisorApplicant> builder)
        {
            builder.ToTable("AdvisorApplicant", "dbo");
            builder.HasKey(t => t.AdvisorApplicantId);
            builder.Property(t => t.AdvisorApplicantId)
                .IsRequired()
                .HasColumnName("AdvisorApplicantId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.YearsOfExperience)
                .IsRequired()
                .HasColumnName("YearsOfExperience")
                .HasColumnType("int");
            builder.Property(t => t.Approved)
                .IsRequired()
                .HasColumnName("Approved")
                .HasColumnType("bit");
            builder.Property(t => t.ApplicantNotes)
                .HasColumnName("ApplicantNotes")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Stage)
                .IsRequired()
                .HasColumnName("Stage")
                .HasColumnType("int");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.AdvisorApplicants)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_AdvisorApplicant_RegionAreaAdvisorCategory");
        }
    }
}