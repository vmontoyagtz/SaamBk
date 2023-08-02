using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class CreateProductCategoryResponse : BaseResponse
    {
        public CreateProductCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateProductCategoryResponse()
        {
        }

        public ProductCategoryDto ProductCategory { get; set; } = new();
    }
}