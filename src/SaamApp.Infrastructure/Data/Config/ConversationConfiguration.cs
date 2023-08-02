using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ConversationConfiguration
        : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversation", "dbo");
            builder.HasKey(t => t.ConversationId);
            builder.Property(t => t.ConversationId)
                .IsRequired()
                .HasColumnName("ConversationId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.ReconnectConversationId)
                .IsRequired()
                .HasColumnName("ReconnectConversationId")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ConversationSumTimeInSecs)
                .IsRequired()
                .HasColumnName("ConversationSumTimeInSecs")
                .HasColumnType("int");
            builder.Property(t => t.ConversationSumSpent)
                .IsRequired()
                .HasColumnName("ConversationSumSpent")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.LostSignalCustomer)
                .HasColumnName("LostSignalCustomer")
                .HasColumnType("bit");
            builder.Property(t => t.LostSignalAdvisor)
                .HasColumnName("LostSignalAdvisor")
                .HasColumnType("bit");
            builder.Property(t => t.CanceledByCustomer)
                .HasColumnName("CanceledByCustomer")
                .HasColumnType("bit");
            builder.Property(t => t.CanceledByAdvisor)
                .HasColumnName("CanceledByAdvisor")
                .HasColumnType("bit");
            builder.Property(t => t.EndedByNoBalance)
                .HasColumnName("EndedByNoBalance")
                .HasColumnType("bit");
            builder.Property(t => t.StillActive)
                .HasColumnName("StillActive")
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
            builder.Property(t => t.InteractionTypeId)
                .IsRequired()
                .HasColumnName("InteractionTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.UnansweredConversationId)
                .IsRequired()
                .HasColumnName("UnansweredConversationId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.InteractionType)
                .WithMany(t => t.Conversations)
                .HasForeignKey(d => d.InteractionTypeId)
                .HasConstraintName("FK_Conversation_InteractionType");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.Conversations)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_Conversation_RegionAreaAdvisorCategory");
            builder.HasOne(t => t.UnansweredConversation)
                .WithMany(t => t.Conversations)
                .HasForeignKey(d => d.UnansweredConversationId)
                .HasConstraintName("FK_Conversation_UnansweredConversation");
        }
    }
}