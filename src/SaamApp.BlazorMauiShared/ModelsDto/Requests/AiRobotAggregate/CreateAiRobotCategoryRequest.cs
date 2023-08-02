using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class CreateAiRobotCategoryRequest : BaseRequest
    {
        public Guid AiRobotId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}