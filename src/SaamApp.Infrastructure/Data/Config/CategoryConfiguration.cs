using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");
            builder.HasKey(t => t.CategoryId);
            builder.Property(t => t.CategoryId)
                .IsRequired()
                .HasColumnName("CategoryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CategoryName)
                .IsRequired()
                .HasColumnName("CategoryName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CategoryDescription)
                .HasColumnName("CategoryDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CategoryImage)
                .IsRequired()
                .HasColumnName("CategoryImage")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.CategoryStage)
                .IsRequired()
                .HasColumnName("CategoryStage")
                .HasColumnType("int");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}