using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class ListProductCategoryResponse : BaseResponse
    {
        public ListProductCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListProductCategoryResponse()
        {
        }

        public List<ProductCategoryDto> ProductCategories { get; set; } = new();

        public int Count { get; set; }
    }
}