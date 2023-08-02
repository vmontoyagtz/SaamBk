using System;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class DeleteProductCategoryResponse : BaseResponse
    {
        public DeleteProductCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteProductCategoryResponse()
        {
        }
    }
}