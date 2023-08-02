using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ConversationStageConfiguration
        : IEntityTypeConfiguration<ConversationStage>
    {
        public void Configure(EntityTypeBuilder<ConversationStage> builder)
        {
            builder.ToTable("ConversationStage", "dbo");
            builder.HasKey(t => t.ConversationStageId);
            builder.Property(t => t.ConversationStageId)
                .IsRequired()
                .HasColumnName("ConversationStageId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ConversationStageName)
                .HasColumnName("ConversationStageName")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.ConversationDescription)
                .IsRequired()
                .HasColumnName("ConversationDescription")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.TenantId)
                .IsRequired()
                .HasColumnName("TenantId")
                .HasColumnType("uniqueidentifier");
        }
    }
}