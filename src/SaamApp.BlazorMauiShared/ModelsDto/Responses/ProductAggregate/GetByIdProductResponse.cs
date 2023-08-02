using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class GetByIdProductResponse : BaseResponse
    {
        public GetByIdProductResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdProductResponse()
        {
        }

        public ProductDto Product { get; set; } = new();
    }
}