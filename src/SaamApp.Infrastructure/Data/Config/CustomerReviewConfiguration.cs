using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerReviewConfiguration
        : IEntityTypeConfiguration<CustomerReview>
    {
        public void Configure(EntityTypeBuilder<CustomerReview> builder)
        {
            builder.ToTable("CustomerReview", "dbo");
            builder.HasKey(t => t.CustomerReviewId);
            builder.Property(t => t.CustomerReviewId)
                .IsRequired()
                .HasColumnName("CustomerReviewId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Rating)
                .IsRequired()
                .HasColumnName("Rating")
                .HasColumnType("int");
            builder.Property(t => t.ReviewText)
                .HasColumnName("ReviewText")
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
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.CustomerReviews)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_CustomerReview_Advisor");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerReviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerReview_Customer");
        }
    }
}