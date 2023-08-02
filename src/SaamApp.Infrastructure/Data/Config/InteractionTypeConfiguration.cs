using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class InteractionTypeConfiguration
        : IEntityTypeConfiguration<InteractionType>
    {
        public void Configure(EntityTypeBuilder<InteractionType> builder)
        {
            builder.ToTable("InteractionType", "dbo");
            builder.HasKey(t => t.InteractionTypeId);
            builder.Property(t => t.InteractionTypeId)
                .IsRequired()
                .HasColumnName("InteractionTypeId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.InteractionTypeName)
                .IsRequired()
                .HasColumnName("InteractionTypeName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.InteractionDescription)
                .HasColumnName("InteractionDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}