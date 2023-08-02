using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class UpdateProductCategoryResponse : BaseResponse
    {
        public UpdateProductCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateProductCategoryResponse()
        {
        }

        public ProductCategoryDto ProductCategory { get; set; } = new();
    }
}