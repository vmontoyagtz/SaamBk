using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class UnansweredConversationConfiguration
        : IEntityTypeConfiguration<UnansweredConversation>
    {
        public void Configure(EntityTypeBuilder<UnansweredConversation> builder)
        {
            builder.ToTable("UnansweredConversation", "dbo");
            builder.HasKey(t => t.UnansweredConversationId);
            builder.Property(t => t.UnansweredConversationId)
                .IsRequired()
                .HasColumnName("UnansweredConversationId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.UnansweredConversationQuestion)
                .IsRequired()
                .HasColumnName("UnansweredConversationQuestion")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UnansweredConversationAnsweredTime)
                .HasColumnName("UnansweredConversationAnsweredTime")
                .HasColumnType("datetime2");
            builder.Property(t => t.Answered)
                .HasColumnName("Answered")
                .HasColumnType("bit");
            builder.Property(t => t.Canceled)
                .HasColumnName("Canceled")
                .HasColumnType("bit");
            builder.Property(t => t.Unanswered)
                .HasColumnName("Unanswered")
                .HasColumnType("bit");
            builder.Property(t => t.AiRobot)
                .HasColumnName("AiRobot")
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
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.InteractionTypeId)
                .IsRequired()
                .HasColumnName("InteractionTypeId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.UnansweredConversations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_UnansweredConversation_Customer");
            builder.HasOne(t => t.InteractionType)
                .WithMany(t => t.UnansweredConversations)
                .HasForeignKey(d => d.InteractionTypeId)
                .HasConstraintName("FK_UnansweredConversation_InteractionType");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.UnansweredConversations)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_UnansweredConversation_RegionAreaAdvisorCategory");
        }
    }
}