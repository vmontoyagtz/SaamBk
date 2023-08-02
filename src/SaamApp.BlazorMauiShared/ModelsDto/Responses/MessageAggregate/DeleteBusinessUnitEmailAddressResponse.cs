using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class DeleteBusinessUnitEmailAddressResponse : BaseResponse
    {
        public DeleteBusinessUnitEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitEmailAddressResponse()
        {
        }
    }
}