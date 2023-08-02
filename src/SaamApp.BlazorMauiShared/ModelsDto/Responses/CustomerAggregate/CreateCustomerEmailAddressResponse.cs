using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class CreateCustomerEmailAddressResponse : BaseResponse
    {
        public CreateCustomerEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerEmailAddressResponse()
        {
        }

        public CustomerEmailAddressDto CustomerEmailAddress { get; set; } = new();
    }
}