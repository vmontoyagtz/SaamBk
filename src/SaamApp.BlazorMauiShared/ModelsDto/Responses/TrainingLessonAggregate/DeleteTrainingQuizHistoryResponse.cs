using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuizHistory
{
    public class DeleteTrainingQuizHistoryResponse : BaseResponse
    {
        public DeleteTrainingQuizHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTrainingQuizHistoryResponse()
        {
        }
    }
}