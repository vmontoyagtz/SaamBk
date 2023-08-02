using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class UpdateCustomerAddressResponse : BaseResponse
    {
        public UpdateCustomerAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerAddressResponse()
        {
        }

        public CustomerAddressDto CustomerAddress { get; set; } = new();
    }
}