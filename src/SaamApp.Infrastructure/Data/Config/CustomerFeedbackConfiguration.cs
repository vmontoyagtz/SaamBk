using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerFeedbackConfiguration
        : IEntityTypeConfiguration<CustomerFeedback>
    {
        public void Configure(EntityTypeBuilder<CustomerFeedback> builder)
        {
            builder.ToTable("CustomerFeedback", "dbo");
            builder.HasKey(t => t.FeedbackId);
            builder.Property(t => t.FeedbackId)
                .IsRequired()
                .HasColumnName("FeedbackId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.FeedbackDate)
                .IsRequired()
                .HasColumnName("FeedbackDate")
                .HasColumnType("datetime2");
            builder.Property(t => t.FeedbackContent)
                .IsRequired()
                .HasColumnName("FeedbackContent")
                .HasColumnType("nvarchar(max)");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerFeedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerFeedback_Customer");
        }
    }
}