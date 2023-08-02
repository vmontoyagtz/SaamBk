using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class CreateTrainingProgressRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid TrainingLessonId { get; set; }
        public decimal TrainingProgressPercentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}