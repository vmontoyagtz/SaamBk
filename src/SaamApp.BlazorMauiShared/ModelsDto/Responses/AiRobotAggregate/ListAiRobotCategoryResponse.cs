using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class ListAiRobotCategoryResponse : BaseResponse
    {
        public ListAiRobotCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiRobotCategoryResponse()
        {
        }

        public List<AiRobotCategoryDto> AiRobotCategories { get; set; } = new();

        public int Count { get; set; }
    }
}