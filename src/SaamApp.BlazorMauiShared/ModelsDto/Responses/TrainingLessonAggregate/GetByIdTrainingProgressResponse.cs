using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class GetByIdTrainingProgressResponse : BaseResponse
    {
        public GetByIdTrainingProgressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTrainingProgressResponse()
        {
        }

        public TrainingProgressDto TrainingProgress { get; set; } = new();
    }
}