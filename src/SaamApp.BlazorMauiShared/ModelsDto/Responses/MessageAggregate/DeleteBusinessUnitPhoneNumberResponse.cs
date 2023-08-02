using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class DeleteBusinessUnitPhoneNumberResponse : BaseResponse
    {
        public DeleteBusinessUnitPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitPhoneNumberResponse()
        {
        }
    }
}