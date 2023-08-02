using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class CreateCustomerAddressResponse : BaseResponse
    {
        public CreateCustomerAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerAddressResponse()
        {
        }

        public CustomerAddressDto CustomerAddress { get; set; } = new();
    }
}