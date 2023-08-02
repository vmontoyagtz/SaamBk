using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class CreateAddressTypeResponse : BaseResponse
    {
        public CreateAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAddressTypeResponse()
        {
        }

        public AddressTypeDto AddressType { get; set; } = new();
    }
}