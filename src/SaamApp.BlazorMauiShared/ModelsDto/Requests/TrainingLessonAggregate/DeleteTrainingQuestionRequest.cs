using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class DeleteTrainingQuestionRequest : BaseRequest
    {
        public Guid TrainingQuestionId { get; set; }
    }
}