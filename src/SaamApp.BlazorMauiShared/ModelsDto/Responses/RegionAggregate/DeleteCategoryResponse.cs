using System;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class DeleteCategoryResponse : BaseResponse
    {
        public DeleteCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCategoryResponse()
        {
        }
    }
}