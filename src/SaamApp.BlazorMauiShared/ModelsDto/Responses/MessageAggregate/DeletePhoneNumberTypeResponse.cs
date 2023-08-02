using System;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class DeletePhoneNumberTypeResponse : BaseResponse
    {
        public DeletePhoneNumberTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePhoneNumberTypeResponse()
        {
        }
    }
}