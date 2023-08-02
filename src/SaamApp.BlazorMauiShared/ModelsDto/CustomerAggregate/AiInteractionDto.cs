using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiInteractionDto
    {
        public AiInteractionDto() { } // AutoMapper required

        public AiInteractionDto(Guid aiInteractionId, Guid aiRobotId, Guid customerId, Guid sessionId, string? question,
            string? answer, DateTime interactionTime, bool isSuccessful)
        {
            AiInteractionId = Guard.Against.NullOrEmpty(aiInteractionId, nameof(aiInteractionId));
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            SessionId = Guard.Against.NullOrEmpty(sessionId, nameof(sessionId));
            Question = question;
            Answer = answer;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            IsSuccessful = Guard.Against.Null(isSuccessful, nameof(isSuccessful));
        }

        public Guid AiInteractionId { get; set; }

        [MaxLength(100)] public string? Question { get; set; }

        [MaxLength(100)] public string? Answer { get; set; }

        [Required(ErrorMessage = "Interaction Time is required")]
        public DateTime InteractionTime { get; set; }

        [Required(ErrorMessage = "Is Successful is required")]
        public bool IsSuccessful { get; set; }

        public AiRobotDto AiRobot { get; set; }

        [Required(ErrorMessage = "Ai Robot is required")]
        public Guid AiRobotId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public UserSessionDto Session { get; set; }

        [Required(ErrorMessage = "Session is required")]
        public Guid SessionId { get; set; }
    }
}