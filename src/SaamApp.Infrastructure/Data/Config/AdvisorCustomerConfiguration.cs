using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorCustomerConfiguration
        : IEntityTypeConfiguration<AdvisorCustomer>
    {
        public void Configure(EntityTypeBuilder<AdvisorCustomer> builder)
        {
            builder.ToTable("AdvisorCustomer", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorCustomers)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorCustomer_Advisor");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AdvisorCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AdvisorCustomer_Customer");
        }
    }
}