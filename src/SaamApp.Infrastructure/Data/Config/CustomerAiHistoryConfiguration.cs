using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class CustomerAiHistoryConfiguration
        : IEntityTypeConfiguration<CustomerAiHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerAiHistory> builder)
        {
            builder.ToTable("CustomerAiHistory", "dbo");
            builder.HasKey(t => t.CustomerAiHistoryId);
            builder.Property(t => t.CustomerAiHistoryId)
                .IsRequired()
                .HasColumnName("CustomerAiHistoryId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ModelId)
                .IsRequired()
                .HasColumnName("ModelId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.Question)
                .HasColumnName("Question")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.Response)
                .HasColumnName("Response")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.InteractionTime)
                .IsRequired()
                .HasColumnName("InteractionTime")
                .HasColumnType("datetime");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerAiHistories)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAiHistory_Customer");
        }
    }
}