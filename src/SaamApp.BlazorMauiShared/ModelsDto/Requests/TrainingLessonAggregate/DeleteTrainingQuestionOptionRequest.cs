using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class DeleteTrainingQuestionOptionRequest : BaseRequest
    {
        public Guid TrainingQuestionOptionId { get; set; }
    }
}