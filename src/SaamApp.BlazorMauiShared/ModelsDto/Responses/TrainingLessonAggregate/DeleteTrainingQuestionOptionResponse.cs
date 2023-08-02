using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class DeleteTrainingQuestionOptionResponse : BaseResponse
    {
        public DeleteTrainingQuestionOptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTrainingQuestionOptionResponse()
        {
        }
    }
}