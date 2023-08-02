using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class UpdateCustomerPhoneNumberResponse : BaseResponse
    {
        public UpdateCustomerPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerPhoneNumberResponse()
        {
        }

        public CustomerPhoneNumberDto CustomerPhoneNumber { get; set; } = new();
    }
}