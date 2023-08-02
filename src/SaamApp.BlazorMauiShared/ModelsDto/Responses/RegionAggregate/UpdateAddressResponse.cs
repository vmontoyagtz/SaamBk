using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class UpdateAddressResponse : BaseResponse
    {
        public UpdateAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAddressResponse()
        {
        }

        public AddressDto Address { get; set; } = new();
    }
}