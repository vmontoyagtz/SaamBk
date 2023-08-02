using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class UpdateAiRobotCategoryResponse : BaseResponse
    {
        public UpdateAiRobotCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiRobotCategoryResponse()
        {
        }

        public AiRobotCategoryDto AiRobotCategory { get; set; } = new();
    }
}