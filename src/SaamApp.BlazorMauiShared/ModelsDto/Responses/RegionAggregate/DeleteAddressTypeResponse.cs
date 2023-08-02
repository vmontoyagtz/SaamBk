using System;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class DeleteAddressTypeResponse : BaseResponse
    {
        public DeleteAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAddressTypeResponse()
        {
        }
    }
}