using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class UpdateTemplateCategoryRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTemplateCategoryRequest FromDto(TemplateCategoryDto templateCategoryDto)
        {
            return new UpdateTemplateCategoryRequest
            {
                RowId = templateCategoryDto.RowId,
                ComissionId = templateCategoryDto.ComissionId,
                RegionAreaAdvisorCategoryId = templateCategoryDto.RegionAreaAdvisorCategoryId,
                TemplateId = templateCategoryDto.TemplateId,
                TenantId = templateCategoryDto.TenantId
            };
        }
    }
}