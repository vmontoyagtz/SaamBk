using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class ListProductResponse : BaseResponse
    {
        public ListProductResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListProductResponse()
        {
        }

        public List<ProductDto> Products { get; set; } = new();

        public int Count { get; set; }
    }
}