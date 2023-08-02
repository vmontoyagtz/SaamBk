using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.Data.Config
{
    public class AdvisorRatingConfiguration
        : IEntityTypeConfiguration<AdvisorRating>
    {
        public void Configure(EntityTypeBuilder<AdvisorRating> builder)
        {
            builder.ToTable("AdvisorRating", "dbo");
            builder.HasKey(t => t.RowId);
            builder.Property(t => t.RowId)
                .IsRequired()
                .HasColumnName("RowId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AdvisorRatingFeedback)
                .HasColumnName("AdvisorRatingFeedback")
                .HasColumnType("nvarchar(max)");
            builder.Property(t => t.AdvisorRatingRate)
                .IsRequired()
                .HasColumnName("AdvisorRatingRate")
                .HasColumnType("int");
            builder.Property(t => t.AdvisorRatingDate)
                .IsRequired()
                .HasColumnName("AdvisorRatingDate")
                .HasColumnType("datetime2");
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
            builder.Property(t => t.RatingReasonId)
                .IsRequired()
                .HasColumnName("RatingReasonId")
                .HasColumnType("uniqueidentifier");
            builder.HasOne(t => t.Advisor)
                .WithMany(t => t.AdvisorRatings)
                .HasForeignKey(d => d.AdvisorId)
                .HasConstraintName("FK_AdvisorRating_Advisor");
            builder.HasOne(t => t.Conversation)
                .WithMany(t => t.AdvisorRatings)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("FK_AdvisorRating_Conversation");
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.AdvisorRatings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_AdvisorRating_Customer");
            builder.HasOne(t => t.RatingReason)
                .WithMany(t => t.AdvisorRatings)
                .HasForeignKey(d => d.RatingReasonId)
                .HasConstraintName("FK_AdvisorRating_RatingReason");
        }
    }
}