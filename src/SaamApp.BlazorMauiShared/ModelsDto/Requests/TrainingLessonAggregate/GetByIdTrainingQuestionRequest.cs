using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class GetByIdTrainingQuestionRequest : BaseRequest
    {
        public Guid TrainingQuestionId { get; set; }
    }
}