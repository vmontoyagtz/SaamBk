using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class CreateTrainingQuestionOptionRequest : BaseRequest
    {
        public Guid TrainingQuestionId { get; set; }
        public string TrainingQuestionOptionValue { get; set; }
        public string TrainingQuestionOptionAnswer { get; set; }
        public Guid TenantId { get; set; }
    }
}