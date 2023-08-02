using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class DeleteBusinessUnitAddressResponse : BaseResponse
    {
        public DeleteBusinessUnitAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitAddressResponse()
        {
        }
    }
}