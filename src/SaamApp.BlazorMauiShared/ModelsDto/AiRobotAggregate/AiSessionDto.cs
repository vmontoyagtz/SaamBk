using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiSessionDto
    {
        public AiSessionDto() { } // AutoMapper required

        public AiSessionDto(Guid aiSessionId, Guid customerId, DateTime startTime, DateTime? endTime,
            int numberOfInteractions)
        {
            AiSessionId = Guard.Against.NullOrEmpty(aiSessionId, nameof(aiSessionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            StartTime = Guard.Against.OutOfSQLDateRange(startTime, nameof(startTime));
            EndTime = endTime;
            NumberOfInteractions = Guard.Against.NegativeOrZero(numberOfInteractions, nameof(numberOfInteractions));
        }

        public Guid AiSessionId { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Number Of Interaction is required")]
        public int NumberOfInteractions { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}