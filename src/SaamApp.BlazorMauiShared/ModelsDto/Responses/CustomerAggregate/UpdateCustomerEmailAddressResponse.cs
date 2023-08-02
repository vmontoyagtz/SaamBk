using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class UpdateCustomerEmailAddressResponse : BaseResponse
    {
        public UpdateCustomerEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerEmailAddressResponse()
        {
        }

        public CustomerEmailAddressDto CustomerEmailAddress { get; set; } = new();
    }
}