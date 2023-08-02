using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class DeleteTrainingProgressResponse : BaseResponse
    {
        public DeleteTrainingProgressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTrainingProgressResponse()
        {
        }
    }
}