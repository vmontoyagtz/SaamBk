using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class UpdateProductCategoryRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid ProductId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateProductCategoryRequest FromDto(ProductCategoryDto productCategoryDto)
        {
            return new UpdateProductCategoryRequest
            {
                RowId = productCategoryDto.RowId,
                ComissionId = productCategoryDto.ComissionId,
                ProductId = productCategoryDto.ProductId,
                RegionAreaAdvisorCategoryId = productCategoryDto.RegionAreaAdvisorCategoryId,
                TenantId = productCategoryDto.TenantId
            };
        }
    }
}