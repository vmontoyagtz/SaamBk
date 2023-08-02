using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class CreateAiRobotCategoryResponse : BaseResponse
    {
        public CreateAiRobotCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiRobotCategoryResponse()
        {
        }

        public AiRobotCategoryDto AiRobotCategory { get; set; } = new();
    }
}