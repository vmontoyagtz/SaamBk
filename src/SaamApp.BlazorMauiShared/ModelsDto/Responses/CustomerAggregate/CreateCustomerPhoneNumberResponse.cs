using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class CreateCustomerPhoneNumberResponse : BaseResponse
    {
        public CreateCustomerPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerPhoneNumberResponse()
        {
        }

        public CustomerPhoneNumberDto CustomerPhoneNumber { get; set; } = new();
    }
}