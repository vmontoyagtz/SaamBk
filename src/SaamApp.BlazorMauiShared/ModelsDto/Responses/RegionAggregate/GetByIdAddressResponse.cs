using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class GetByIdAddressResponse : BaseResponse
    {
        public GetByIdAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAddressResponse()
        {
        }

        public AddressDto Address { get; set; } = new();
    }
}