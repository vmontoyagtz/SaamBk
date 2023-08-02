using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class RegionAreaAdvisorCategoryDto
    {
        public RegionAreaAdvisorCategoryDto() { } // AutoMapper required

        public RegionAreaAdvisorCategoryDto(Guid regionAreaAdvisorCategoryId, Guid advisorId, Guid areaId,
            Guid categoryId, Guid regionId)
        {
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            AreaId = Guard.Against.NullOrEmpty(areaId, nameof(areaId));
            CategoryId = Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
        }

        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public AreaDto Area { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public Guid AreaId { get; set; }

        public CategoryDto Category { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryId { get; set; }

        public RegionDto Region { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public Guid RegionId { get; set; }

        public List<AdvisorApplicantDto> AdvisorApplicants { get; set; } = new();
        public List<AiAreaExpertiseDto> AiAreaExpertises { get; set; } = new();
        public List<AiRobotCategoryDto> AiRobotCategories { get; set; } = new();
        public List<BusinessUnitCategoryDto> BusinessUnitCategories { get; set; } = new();
        public List<ComissionDto> Comissions { get; set; } = new();
        public List<ConversationDto> Conversations { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
        public List<ProductCategoryDto> ProductCategories { get; set; } = new();
        public List<TemplateCategoryDto> TemplateCategories { get; set; } = new();
        public List<UnansweredConversationDto> UnansweredConversations { get; set; } = new();
    }
}