using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class DeleteEmailAddressResponse : BaseResponse
    {
        public DeleteEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmailAddressResponse()
        {
        }
    }
}