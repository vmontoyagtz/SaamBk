using System;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class DeleteAddressResponse : BaseResponse
    {
        public DeleteAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAddressResponse()
        {
        }
    }
}