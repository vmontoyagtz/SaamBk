using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiFeedbackDto
    {
        public AiFeedbackDto() { } // AutoMapper required

        public AiFeedbackDto(Guid aiFeedbackId, Guid customerId, Guid modelId, string? question, string? response,
            bool? userFeedback, Guid aisessionId, DateTime interactionTime)
        {
            AiFeedbackId = Guard.Against.NullOrEmpty(aiFeedbackId, nameof(aiFeedbackId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            UserFeedback = userFeedback;
            AISessionId = Guard.Against.NullOrEmpty(aisessionId, nameof(aisessionId));
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
        }

        public Guid AiFeedbackId { get; set; }

        [Required(ErrorMessage = "Model Id is required")]
        public Guid ModelId { get; set; }

        [MaxLength(100)] public string? Question { get; set; }

        [MaxLength(100)] public string? Response { get; set; }

        public bool? UserFeedback { get; set; }

        [Required(ErrorMessage = "AISession Id is required")]
        public Guid AISessionId { get; set; }

        [Required(ErrorMessage = "Interaction Time is required")]
        public DateTime InteractionTime { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}