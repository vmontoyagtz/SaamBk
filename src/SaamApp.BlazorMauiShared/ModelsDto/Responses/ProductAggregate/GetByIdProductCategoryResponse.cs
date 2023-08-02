using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class GetByIdProductCategoryResponse : BaseResponse
    {
        public GetByIdProductCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdProductCategoryResponse()
        {
        }

        public ProductCategoryDto ProductCategory { get; set; } = new();
    }
}