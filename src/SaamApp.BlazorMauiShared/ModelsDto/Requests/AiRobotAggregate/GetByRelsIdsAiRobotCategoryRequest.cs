using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class GetByRelsIdsAiRobotCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid AiRobotId { get; set; }
    }
}