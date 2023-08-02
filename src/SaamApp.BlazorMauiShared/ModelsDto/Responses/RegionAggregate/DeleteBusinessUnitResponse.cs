using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class DeleteBusinessUnitResponse : BaseResponse
    {
        public DeleteBusinessUnitResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitResponse()
        {
        }
    }
}