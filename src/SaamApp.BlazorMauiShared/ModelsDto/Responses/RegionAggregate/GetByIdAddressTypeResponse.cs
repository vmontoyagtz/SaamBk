using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class GetByIdAddressTypeResponse : BaseResponse
    {
        public GetByIdAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAddressTypeResponse()
        {
        }

        public AddressTypeDto AddressType { get; set; } = new();
    }
}