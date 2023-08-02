using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AiRobotCategoryConfiguration
        : IEntityTypeConfiguration<AiRobotCategory>
    {
        public void Configure(EntityTypeBuilder<AiRobotCategory> builder)
        {
            builder.ToTable("AiRobotCategory", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ComissionId)
                .IsRequired()
                .HasColumnName("ComissionId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.AiRobotId)
                .IsRequired()
                .HasColumnName("AiRobotId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.AiRobot)
                .WithMany(t => t.AiRobotCategories)
                .HasForeignKey(d => d.AiRobotId)
                .HasConstraintName("FK_AiRobotCategory_AiRobot");
            builder.HasOne(t => t.Comission)
                .WithMany(t => t.AiRobotCategories)
                .HasForeignKey(d => d.ComissionId)
                .HasConstraintName("FK_AiRobotCategory_Comission");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.AiRobotCategories)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_AiRobotCategory_RegionAreaAdvisorCategory");
        }
    }
}