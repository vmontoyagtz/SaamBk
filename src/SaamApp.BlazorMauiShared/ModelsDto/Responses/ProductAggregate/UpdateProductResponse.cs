using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class UpdateProductResponse : BaseResponse
    {
        public UpdateProductResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateProductResponse()
        {
        }

        public ProductDto Product { get; set; } = new();
    }
}