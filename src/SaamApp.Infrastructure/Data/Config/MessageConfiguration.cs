using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class MessageConfiguration
        : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message", "dbo");
            builder.HasKey(t => t.MessageId);
            builder.Property(t => t.MessageId)
                .IsRequired()
                .HasColumnName("MessageId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.MessageContent)
                .IsRequired()
                .HasColumnName("MessageContent")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.RegionAreaAdvisorCategoryId)
                .IsRequired()
                .HasColumnName("RegionAreaAdvisorCategoryId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.MessageDetailTimeInSecs)
                .IsRequired()
                .HasColumnName("MessageDetailTimeInSecs")
                .HasColumnType("int");
            builder.Property(t => t.MessageDetailSpent)
                .IsRequired()
                .HasColumnName("MessageDetailSpent")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.TemplatetId)
                .IsRequired()
                .HasColumnName("TemplatetId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ReplyToMessageId)
                .IsRequired()
                .HasColumnName("ReplyToMessageId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.SentByAdvisor)
                .IsRequired()
                .HasColumnName("SentByAdvisor")
                .HasColumnType("bit");
            builder.Property(t => t.SentByCustomer)
                .IsRequired()
                .HasColumnName("SentByCustomer")
                .HasColumnType("bit");
            builder.Property(t => t.HasBeenReadByCustomer)
                .IsRequired()
                .HasColumnName("HasBeenReadByCustomer")
                .HasColumnType("bit");
            builder.Property(t => t.HasBeenReadByAdvisor)
                .IsRequired()
                .HasColumnName("HasBeenReadByAdvisor")
                .HasColumnType("bit");
            builder.Property(t => t.ReadByCustomerAt)
                .HasColumnName("ReadByCustomerAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.ReadByAdvisorAt)
                .HasColumnName("ReadByAdvisorAt")
                .HasColumnType("datetime2");
            builder.Property(t => t.HasAttachments)
                .IsRequired()
                .HasColumnName("HasAttachments")
                .HasColumnType("bit");
            builder.Property(t => t.AiRobot)
                .IsRequired()
                .HasColumnName("AiRobot")
                .HasColumnType("bit");
            builder.Property(t => t.IsChat)
                .IsRequired()
                .HasColumnName("IsChat")
                .HasColumnType("bit");
            builder.Property(t => t.IsVoiceCall)
                .IsRequired()
                .HasColumnName("IsVoiceCall")
                .HasColumnType("bit");
            builder.Property(t => t.IsVideoCall)
                .IsRequired()
                .HasColumnName("IsVideoCall")
                .HasColumnType("bit");
            builder.Property(t => t.IsVoiceNote)
                .IsRequired()
                .HasColumnName("IsVoiceNote")
                .HasColumnType("bit");
            builder.Property(t => t.VoiceNoteApproved)
                .HasColumnName("VoiceNoteApproved")
                .HasColumnType("bit");
            builder.Property(t => t.VoiceNoteSize)
                .HasColumnName("VoiceNoteSize")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.LowBalance)
                .HasColumnName("LowBalance")
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
            builder.Property(t => t.AdvisorId)
                .IsRequired()
                .HasColumnName("AdvisorId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ConversationId)
                .IsRequired()
                .HasColumnName("ConversationId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.InteractionTypeId)
                .IsRequired()
                .HasColumnName("InteractionTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.MessageTypeId)
                .IsRequired()
                .HasColumnName("MessageTypeId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ProductId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_Message_Advisor");
            builder.HasOne(t => t.Conversation)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("FK_Message_Conversation");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Message_Customer");
            builder.HasOne(t => t.InteractionType)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.InteractionTypeId)
                .HasConstraintName("FK_Message_InteractionType");
            builder.HasOne(t => t.MessageType)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.MessageTypeId)
                .HasConstraintName("FK_Message_MessageType");
            builder.HasOne(t => t.Product)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Message_Product");
            builder.HasOne(t => t.RegionAreaAdvisorCategory)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.RegionAreaAdvisorCategoryId)
                .HasConstraintName("FK_Message_RegionAreaAdvisorCategory");
        }
    }
}