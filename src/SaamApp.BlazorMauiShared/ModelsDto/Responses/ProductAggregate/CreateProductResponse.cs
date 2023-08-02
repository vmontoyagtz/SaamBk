using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class CreateProductResponse : BaseResponse
    {
        public CreateProductResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateProductResponse()
        {
        }

        public ProductDto Product { get; set; } = new();
    }
}