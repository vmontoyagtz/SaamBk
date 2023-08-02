using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class UpdateTrainingProgressResponse : BaseResponse
    {
        public UpdateTrainingProgressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTrainingProgressResponse()
        {
        }

        public TrainingProgressDto TrainingProgress { get; set; } = new();
    }
}