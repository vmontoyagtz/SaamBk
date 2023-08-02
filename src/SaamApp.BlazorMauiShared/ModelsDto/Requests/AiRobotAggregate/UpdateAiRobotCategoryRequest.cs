using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class UpdateAiRobotCategoryRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AiRobotId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public static UpdateAiRobotCategoryRequest FromDto(AiRobotCategoryDto aiRobotCategoryDto)
        {
            return new UpdateAiRobotCategoryRequest
            {
                RowId = aiRobotCategoryDto.RowId,
                AiRobotId = aiRobotCategoryDto.AiRobotId,
                ComissionId = aiRobotCategoryDto.ComissionId,
                RegionAreaAdvisorCategoryId = aiRobotCategoryDto.RegionAreaAdvisorCategoryId
            };
        }
    }
}