using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class RatingReasonDto
    {
        public RatingReasonDto() { } // AutoMapper required

        public RatingReasonDto(Guid ratingReasonId, string ratingReasonDescription)
        {
            RatingReasonId = Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            RatingReasonDescription =
                Guard.Against.NullOrWhiteSpace(ratingReasonDescription, nameof(ratingReasonDescription));
        }

        public Guid RatingReasonId { get; set; }

        [Required(ErrorMessage = "Rating Reason Description is required")]
        [MaxLength(100)]
        public string RatingReasonDescription { get; set; }

        public List<AdvisorRatingDto> AdvisorRatings { get; set; } = new();
    }
}