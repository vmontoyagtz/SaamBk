using System;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class DeleteEmailAddressTypeResponse : BaseResponse
    {
        public DeleteEmailAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmailAddressTypeResponse()
        {
        }
    }
}