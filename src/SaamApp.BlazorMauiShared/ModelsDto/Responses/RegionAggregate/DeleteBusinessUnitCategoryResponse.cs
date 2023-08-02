using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class DeleteBusinessUnitCategoryResponse : BaseResponse
    {
        public DeleteBusinessUnitCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitCategoryResponse()
        {
        }
    }
}