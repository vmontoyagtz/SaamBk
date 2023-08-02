using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class GetByIdAiRobotCategoryResponse : BaseResponse
    {
        public GetByIdAiRobotCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiRobotCategoryResponse()
        {
        }

        public AiRobotCategoryDto AiRobotCategory { get; set; } = new();
    }
}