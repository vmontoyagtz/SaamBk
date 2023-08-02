using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class UpdateCategoryRequest : BaseRequest
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public int CategoryStage { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateCategoryRequest FromDto(CategoryDto categoryDto)
        {
            return new UpdateCategoryRequest
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName,
                CategoryDescription = categoryDto.CategoryDescription,
                CategoryImage = categoryDto.CategoryImage,
                CategoryStage = categoryDto.CategoryStage,
                TenantId = categoryDto.TenantId
            };
        }
    }
}