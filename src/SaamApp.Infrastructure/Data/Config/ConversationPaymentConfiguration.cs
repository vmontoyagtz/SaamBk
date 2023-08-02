using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class ConversationPaymentConfiguration
        : IEntityTypeConfiguration<ConversationPayment>
    {
        public void Configure(EntityTypeBuilder<ConversationPayment> builder)
        {
            builder.ToTable("ConversationPayment", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorPaymentId)
                .IsRequired()
                .HasColumnName("AdvisorPaymentId")
                .HasColumnType("uniqueidentifier");
            builder.Property(t => t.ConversationPaymentStage)
                .HasColumnName("ConversationPaymentStage")
                .HasColumnType("bit");
            builder.Property(t => t.ConversationId)
                .IsRequired()
                .HasColumnName("ConversationId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Conversation)
                .WithMany(t => t.ConversationPayments)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("FK_ConversationPayment_Conversation");
        }
    }
}