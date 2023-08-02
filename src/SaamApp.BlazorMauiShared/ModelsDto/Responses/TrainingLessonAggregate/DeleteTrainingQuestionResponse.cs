using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class DeleteTrainingQuestionResponse : BaseResponse
    {
        public DeleteTrainingQuestionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTrainingQuestionResponse()
        {
        }
    }
}