using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class CreateTrainingQuestionRequest : BaseRequest
    {
        public string? TrainingQuestionValue { get; set; }
        public Guid TenantId { get; set; }
    }
}