using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class DeletePhoneNumberResponse : BaseResponse
    {
        public DeletePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePhoneNumberResponse()
        {
        }
    }
}