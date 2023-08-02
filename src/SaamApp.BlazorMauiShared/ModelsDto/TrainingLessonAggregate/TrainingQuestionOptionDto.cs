using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TrainingQuestionOptionDto
    {
        public TrainingQuestionOptionDto() { } // AutoMapper required

        public TrainingQuestionOptionDto(Guid trainingQuestionOptionId, Guid trainingQuestionId,
            string trainingQuestionOptionValue, string trainingQuestionOptionAnswer, Guid tenantId)
        {
            TrainingQuestionOptionId =
                Guard.Against.NullOrEmpty(trainingQuestionOptionId, nameof(trainingQuestionOptionId));
            TrainingQuestionId = Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            TrainingQuestionOptionValue =
                Guard.Against.NullOrWhiteSpace(trainingQuestionOptionValue, nameof(trainingQuestionOptionValue));
            TrainingQuestionOptionAnswer =
                Guard.Against.NullOrWhiteSpace(trainingQuestionOptionAnswer, nameof(trainingQuestionOptionAnswer));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TrainingQuestionOptionId { get; set; }

        [Required(ErrorMessage = "Training Question Option Value is required")]
        [MaxLength(100)]
        public string TrainingQuestionOptionValue { get; set; }

        [Required(ErrorMessage = "Training Question Option Answer is required")]
        [MaxLength(100)]
        public string TrainingQuestionOptionAnswer { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public TrainingQuestionDto TrainingQuestion { get; set; }

        [Required(ErrorMessage = "Training Question is required")]
        public Guid TrainingQuestionId { get; set; }
    }
}