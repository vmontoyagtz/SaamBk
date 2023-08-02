using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class UpdateAddressTypeResponse : BaseResponse
    {
        public UpdateAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAddressTypeResponse()
        {
        }

        public AddressTypeDto AddressType { get; set; } = new();
    }
}