using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorLoginDto
    {
        public AdvisorLoginDto() { } // AutoMapper required

        public AdvisorLoginDto(Guid advisorLoginId, Guid advisorId, DateTime advisorLoginDateTime,
            bool advisorLoginStage)
        {
            AdvisorLoginId = Guard.Against.NullOrEmpty(advisorLoginId, nameof(advisorLoginId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            AdvisorLoginDateTime = Guard.Against.OutOfSQLDateRange(advisorLoginDateTime, nameof(advisorLoginDateTime));
            AdvisorLoginStage = Guard.Against.Null(advisorLoginStage, nameof(advisorLoginStage));
        }

        public Guid AdvisorLoginId { get; set; }

        [Required(ErrorMessage = "Advisor Login Date Time is required")]
        public DateTime AdvisorLoginDateTime { get; set; }

        [Required(ErrorMessage = "Advisor Login Stage is required")]
        public bool AdvisorLoginStage { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }
    }
}