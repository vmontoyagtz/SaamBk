using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class CreateAddressResponse : BaseResponse
    {
        public CreateAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAddressResponse()
        {
        }

        public AddressDto Address { get; set; } = new();
    }
}