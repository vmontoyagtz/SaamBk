using System;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class DeleteProductResponse : BaseResponse
    {
        public DeleteProductResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteProductResponse()
        {
        }
    }
}