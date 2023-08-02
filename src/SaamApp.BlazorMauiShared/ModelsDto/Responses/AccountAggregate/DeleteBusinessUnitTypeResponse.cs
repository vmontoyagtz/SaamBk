using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class DeleteBusinessUnitTypeResponse : BaseResponse
    {
        public DeleteBusinessUnitTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitTypeResponse()
        {
        }
    }
}