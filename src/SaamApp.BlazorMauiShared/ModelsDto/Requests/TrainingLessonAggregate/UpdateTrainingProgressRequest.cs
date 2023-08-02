using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class UpdateTrainingProgressRequest : BaseRequest
    {
        public Guid TrainingProgressId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid TrainingLessonId { get; set; }
        public decimal TrainingProgressPercentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTrainingProgressRequest FromDto(TrainingProgressDto trainingProgressDto)
        {
            return new UpdateTrainingProgressRequest
            {
                TrainingProgressId = trainingProgressDto.TrainingProgressId,
                AdvisorId = trainingProgressDto.AdvisorId,
                TrainingLessonId = trainingProgressDto.TrainingLessonId,
                TrainingProgressPercentage = trainingProgressDto.TrainingProgressPercentage,
                CreatedAt = trainingProgressDto.CreatedAt,
                CreatedBy = trainingProgressDto.CreatedBy,
                UpdatedAt = trainingProgressDto.UpdatedAt,
                UpdatedBy = trainingProgressDto.UpdatedBy,
                IsDeleted = trainingProgressDto.IsDeleted,
                TenantId = trainingProgressDto.TenantId
            };
        }
    }
}