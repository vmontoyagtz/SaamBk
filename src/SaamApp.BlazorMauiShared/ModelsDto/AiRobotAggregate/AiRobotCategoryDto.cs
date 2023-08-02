using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiRobotCategoryDto
    {
        public AiRobotCategoryDto() { } // AutoMapper required

        public AiRobotCategoryDto(Guid aiRobotId, Guid comissionId, Guid regionAreaAdvisorCategoryId)
        {
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
        }

        public int RowId { get; set; }

        public AiRobotDto AiRobot { get; set; }

        [Required(ErrorMessage = "Ai Robot is required")]
        public Guid AiRobotId { get; set; }

        public ComissionDto Comission { get; set; }

        [Required(ErrorMessage = "Comission is required")]
        public Guid ComissionId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}