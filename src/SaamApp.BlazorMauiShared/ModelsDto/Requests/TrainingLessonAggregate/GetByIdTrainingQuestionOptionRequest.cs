using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class GetByIdTrainingQuestionOptionRequest : BaseRequest
    {
        public Guid TrainingQuestionOptionId { get; set; }
    }
}